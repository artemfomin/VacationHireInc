namespace VacationHireInc.Invoicing.Api.Core.Pagination;

public class PaginationOptions
{
    public bool Enabled { get; set; }
    public uint PageSize { get; set; }
    public uint PageNumber { get; set; }
    public bool EmptyOrDisabled => !Enabled || PageSize == 0 || PageNumber == 0;
}