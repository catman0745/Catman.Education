namespace Catman.Education.Application.Pagination
{
    using System.Collections.Generic;

    public class Paginated<TResource> : PaginationInfo
    {
        public int PagesCount { get; }
        
        public ICollection<TResource> Items { get; }

        public int Count => Items.Count;

        public Paginated(ICollection<TResource> items, int pagesCount, PaginationInfo paginationInfo)
        {
            PageNumber = paginationInfo.PageNumber;
            PageSize = paginationInfo.PageSize;
            Items = items;
            PagesCount = pagesCount;
        }
    }
}
