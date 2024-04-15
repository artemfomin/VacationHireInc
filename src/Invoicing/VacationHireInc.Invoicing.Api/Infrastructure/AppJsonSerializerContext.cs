using System.Text.Json.Serialization;
using VacationHireInc.Invoicing.Api.Models;

namespace VacationHireInc.Invoicing.Api.Infrastructure;

[JsonSerializable(typeof(Invoice[]))]
[JsonSerializable(typeof(Invoice))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}