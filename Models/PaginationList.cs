namespace ttcm_mvc.Models
{
    public class PaginationList<T>
    {
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginationList(List<T> list,int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            Items = list;
            // Calculate TotalPages
            TotalPages = (int) Math.Ceiling(count/(double)pageSize);// ex: if total 23, pageSize:5, Pages? 23/5 = 4.21 =>5
        }


    }
}
