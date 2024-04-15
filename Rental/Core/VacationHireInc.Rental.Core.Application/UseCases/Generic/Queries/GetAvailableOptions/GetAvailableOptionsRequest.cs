﻿using VacationHireInc.Rental.Core.Application.Core.MediatR.Types;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Domain;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application.UseCases.Cars.GetAvailableOptions;

public class GetAvailableOptionsRequest<TModel> : IQuery<Result<IList<RentItem<TModel>>>>
    where TModel : class, IEntity, IRentable
{
    
}
