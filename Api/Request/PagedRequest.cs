using Api;

namespace Api.Request;

public abstract class PagedRequest
{
    public int PageNumber { get; set; } = Configuration.DefaultPageSize;
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
}