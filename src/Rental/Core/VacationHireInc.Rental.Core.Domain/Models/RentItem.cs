using VacationHireInc.Rental.Core.Domain.Enums;

namespace VacationHireInc.Rental.Core.Domain.Models;

/// <summary>
/// This decorator class improves extensibility
/// of rentable items variety. Any entity with IRentable
/// and IEntity interfaces are eligible for rent
/// </summary>
/// <typeparam name="TKey">Subject primary key type</typeparam>
/// <typeparam name="TModel">Rent subject</typeparam>
public class RentItem<TModel> : RentItem
    where TModel : class, IEntity, IRentable
{
    public RentItem() { }
    
    public TModel? RentSubject { get; set; }

    public RentItem(TModel? subject)
    {
        if (subject is null)
            throw new ArgumentNullException("Rent subject should not be null");
        
        RentSubject = subject;
        QualifiedTypeName = typeof(TModel).FullName;
        SubjectId = subject.Id;
    }
}

public class  RentItem : IEntity
{
    public Guid Id { get; set; }
    public string? QualifiedTypeName { get; set; }
    public Guid SubjectId { get; set; }
    
    public double RentCost { get; set; }
    public BillingPeriods BillingPeriod { get; set; }

    public static RentItem<TModel> ToQualifiedType<TKey, TModel>()
        where TModel : class, IEntity, IRentable
    {
        return null;
    }
}