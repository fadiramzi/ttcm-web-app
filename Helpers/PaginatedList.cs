using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace ttcm_mvc.Helpers
{
    public class PaginatedList<T>where T : class
    {
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public bool HasPrevPage()
        {
            return PageIndex > 1;
        }
        public bool HasNextPage()
        {
            return PageIndex < TotalPages;
        }

        //public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> query, int pageIndex, int pageSize)
        //{
        //    var count = await query.CountAsync();
        //    var items = await query.Skip((pageIndex - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    return new PaginatedList<T>(items,count, pageIndex, pageSize);
        //}
    }
}
