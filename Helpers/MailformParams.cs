namespace marcore.api.Helpers
{
    public class MailformParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }

        public string MinId { get; set; } = "";
        public string MaxId { get; set; } = "zzzzzz";
        /*  public string OrderBy { get; set; } */
    }
}