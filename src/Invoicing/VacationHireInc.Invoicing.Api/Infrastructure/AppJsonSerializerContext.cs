using System.Text.Json.Serialization;
using VacationHireInc.Invoicing.Api.Core.Result;
using VacationHireInc.Invoicing.Api.Models;

namespace VacationHireInc.Invoicing.Api.Infrastructure;

[JsonSerializable(typeof(Invoice[]))]
[JsonSerializable(typeof(Invoice))]
[JsonSerializable(typeof(Result<IList<Invoice>>))]
[JsonSerializable(typeof(Result<List<Invoice>>))]
[JsonSerializable(typeof(Result<Invoice>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}