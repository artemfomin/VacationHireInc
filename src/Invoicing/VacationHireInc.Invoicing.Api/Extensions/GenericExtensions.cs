using System.Collections;
using System.Reflection;
using System.Text.Json;

namespace VacationHireInc.Invoicing.Api.Extensions;

public static class GenericExtensions
{
    public static void TraverseUpdate<T>(this T destination, T source) where T : class
    {
        var visited = new HashSet<object>();

        if (source == null || destination == null)
            throw new ArgumentNullException();

        TraverseUpdateInternal(destination, source, visited);

        visited.Clear();
    }

    public static T DeepCopy<T>(this T source)
    {
        var json = JsonSerializer.Serialize(source);
        return JsonSerializer.Deserialize<T>(json);
    }

    private static void TraverseUpdateInternal<T>(T destination, T source, HashSet<object> visited) where T : class
    {
        foreach (var propInfo in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (!propInfo.CanRead || !propInfo.CanWrite)
                continue;

            if (IsCollectionProperty<T>(propInfo))
            {
                UpdateCollectionProperty(destination, source, visited, propInfo);
            }
            else if (propInfo.PropertyType.IsClass && propInfo.PropertyType != typeof(string))
            {
                UpdateChildObject(destination, source, visited, propInfo);
            }
            else
            {
                var value = propInfo.GetValue(source, null);
                propInfo.SetValue(destination, value, null);
            }
        }
    }

    private static bool IsCollectionProperty<T>(PropertyInfo propInfo) where T : class
    {
        return typeof(IEnumerable).IsAssignableFrom(propInfo.PropertyType) && propInfo.PropertyType != typeof(string);
    }

    private static void UpdateCollectionProperty<T>(T destination, T source, HashSet<object> visited, PropertyInfo propInfo)
        where T : class
    {
        var destinationCollection = propInfo.GetValue(destination) as IEnumerable;
        var sourceCollection = propInfo.GetValue(source) as IEnumerable;

        if (destinationCollection != null && sourceCollection != null)
        {
            UpdateChildProperty<T>(visited, destinationCollection, sourceCollection);
        }
    }

    private static void UpdateChildProperty<T>(HashSet<object> visited, IEnumerable destinationCollection,
        IEnumerable sourceCollection) where T : class
    {
        var destinationEnumerator = destinationCollection.GetEnumerator();
        var sourceEnumerator = sourceCollection.GetEnumerator();
        while (destinationEnumerator.MoveNext() && sourceEnumerator.MoveNext())
        {
            if (sourceEnumerator.Current is null 
                || destinationEnumerator.Current is null 
                || visited.Contains(sourceEnumerator.Current)) continue;
            
            visited.Add(sourceEnumerator.Current);
            TraverseUpdateInternal(destinationEnumerator.Current, sourceEnumerator.Current, visited);
        }
    }

    private static void UpdateChildObject<T>(T destination, T source, HashSet<object> visited, PropertyInfo propInfo)
        where T : class
    {
        var destinationChild = propInfo.GetValue(destination);
        var sourceChild = propInfo.GetValue(source);

        if (destinationChild != null && sourceChild != null)
        {
            if (!visited.Contains(sourceChild))
            {
                visited.Add(sourceChild);
                TraverseUpdateInternal(destinationChild, sourceChild, visited);
            }
        }
    }
}
