namespace Desafio1.Pagination
{
    public class PageList<T> : List<T> where T : class
    {

        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalCount;

        public PageList(List<T> itens, int count , int pageNumber, int pageSize)
        {

            CurrentPage = pageNumber;
            TotalCount = count;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((count)/(double)pageSize);

            AddRange(itens);
        }

        public static PageList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var itens = source.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
            return new PageList<T>(itens, count, pageNumber, pageSize);
        }

    }
}
