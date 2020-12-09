namespace Catman.Education.WebApi.DataTransferObjects.Pagination
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class PaginatedDto<TResource>
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }
        
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }
        
        [JsonPropertyName("pagesCount")]
        public int PagesCount { get; set; }
        
        [JsonPropertyName("items")]
        public ICollection<TResource> Items { get; set; }
    }
}
