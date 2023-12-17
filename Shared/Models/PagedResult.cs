using System.Text.Json.Serialization;

namespace Resumade.Shared.Models;

public class PagedResult<T>
{
    public PagedResult()
    {
        Items = new List<T>();
    }
    
    [JsonPropertyName("items")]
    public IList<T> Items { get; set; }
    
    [JsonPropertyName("pageNumber")]
    public int PageNumber { get; set; }
    
    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }
    
    [JsonPropertyName("totalPages")]
    public int TotalPages { get; set; }
    
    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; }
}