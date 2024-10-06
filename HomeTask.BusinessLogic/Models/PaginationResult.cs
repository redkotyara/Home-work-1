using System.Collections.Generic;

namespace HomeTask.BusinessLogic.Models
{
    public class PaginationResult<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int PageNumber { get; set; }

        public int TotalItems { get; set; }

        public int PageSize { get; set; }
    }
}