using MediatR;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Application.UseCases.Cars.AddOption;
using VacationHireInc.Rental.Core.Application.UseCases.Cars.GetAvailableOptions;
using VacationHireInc.Rental.Core.Application.UseCases.Cars.GetOption;
using VacationHireInc.Rental.Core.Application.UseCases.Cars.PlaceRentOrder;
using VacationHireInc.Rental.Core.Application.UseCases.Generic.Commands.CloseRentOrder;
using VacationHireInc.Rental.Core.Domain;
using VacationHireInc.Rental.Core.Domain.Models;
using VacationHireInc.Rental.Presentation.Api.Infrastructure.ApiExceptionHandling.Core;

namespace VacationHireInc.Rental.Presentation.Api.Configuration;

internal static class ApiConfiguration
{
    internal static WebApplication ConfigureApi(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        
        var carsApi = app.MapGroup("/cars");
        
        carsApi.MapStandardAssetGroup<Sedan>("/sedans");
        carsApi.MapStandardAssetGroup<Minivan>("/minivans");
        carsApi.MapStandardAssetGroup<Truck>("/trucks");

        var ordersApi = app.MapGroup("/orders");
        ordersApi.MapPost("/",
            async (HttpContext http, PlaceRentOrderRequest req) =>
                await http.MapMediatorRequest(req));
        ordersApi.MapPut("/",
            async (HttpContext http, Guid id, CloseRentOrderRequest req) =>
                await http.MapMediatorRequest(req));
        
        return app;
    }

    private static void MapStandardAssetGroup<TModel>(this RouteGroupBuilder api, string prefix)
        where TModel : class, IEntity, IRentable
    {
        var groupApi = api.MapGroup(prefix);
        groupApi.MapGet("/", handler: async (HttpContext http) => 
            await http.MapMediatorRequest<GetAvailableOptionsRequest<TModel>, IList<RentItem<TModel>>>(new()));
        groupApi.MapGet("/{id}", async (HttpContext http, Guid id) =>
            await http.MapMediatorRequest(new GetOptionRequest<TModel> { RentItemId = id }));
        groupApi.MapPost("/", handler: async (HttpContext http, RentItem<TModel> asset) => 
            await http.MapMediatorRequest<AddOptionRequest<TModel>>(new(asset)));
    }
    
    private static async Task<IResult> MapMediatorRequest<TRequest, TResponse>(this HttpContext http, TRequest request)
        where TRequest : class, IRequest<Result<TResponse>>
    {
        var mediator = http.RequestServices.GetRequiredService<IMediator>();
        var result = await mediator.Send(request);

        return result.Failed 
            ? Results.BadRequest(result.Errors.Select(x => x.Message)) 
            : Results.Ok(result.Payload);
    }
    
    
    private static async Task<IResult> MapMediatorRequest<TRequest>(this HttpContext http, TRequest request)
        where TRequest : class, IRequest<Result>
    {
        var mediator = http.RequestServices.GetRequiredService<IMediator>();
        var result = await mediator.Send(request);

        return result.Failed 
            ? Results.BadRequest(result.Errors.Select(x => x.Message)) 
            : Results.Ok();
    }
    
    
}