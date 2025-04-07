namespace Basis.Domain.Common
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = [];
        public int Count { get; set; }
        public int AmountPages { get; set; }
        public PagedResult(List<T> items, int count, int limit)
        {
            Items = items;
            Count = count;
            AmountPages = (int)Math.Ceiling(count / (double)limit);
        }
    }
}
