using VacationHireInc.Rental.Presentation.Api.Configuration;

WebApplication.CreateSlimBuilder(args)
    .ConfigureServices()
    .Build()
    .ConfigureApplication()
    .ConfigureApi()
    .Run();


