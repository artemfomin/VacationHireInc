using System.Text.Json.Serialization;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Presentation.Api.Infrastructure;

[JsonSerializable(typeof(Todo[]))]
[JsonSerializable(typeof(IList<RentItem<Sedan>>))]
[JsonSerializable(typeof(IList<RentItem<Minivan>>))]
[JsonSerializable(typeof(IList<RentItem<Truck>>))]
[JsonSerializable(typeof(RentItem<Sedan>))]
[JsonSerializable(typeof(RentItem<Minivan>))]
[JsonSerializable(typeof(RentItem<Truck>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}