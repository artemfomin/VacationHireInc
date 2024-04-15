using System.Text.Json.Serialization;
using VacationHireInc.Invoicing.Api.Configuration;

WebApplication.CreateSlimBuilder(args)
    .ConfigureServices()
    .Build()
    .ConfigureApplication()
    .ConfigureApi()
    .Run();

