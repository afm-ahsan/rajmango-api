namespace RajMango.Application.DTOs
{
    public class PagedAndSortedDto
    {
        public string Filter { get; set; }
        public int SkipCount { get; set; } = 0;
        public int MaxResultCount { get; set; } = 25;
    }
}
