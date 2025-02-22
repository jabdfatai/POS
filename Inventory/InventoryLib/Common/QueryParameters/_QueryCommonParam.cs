using System;
using System.Collections.Generic;
using System.Text;

namespace Common.QueryParameters
{
    public class QueryCommonParam
    {
        const int maxPageSize = 50;

        /// <summary>
        /// Page number for pagination
        /// </summary>
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        public DateTime? dtcreatedfrom { get; set; }

        public DateTime? dtcreatedto { get; set; }

        /// <summary>
        /// page size for pagination
        /// </summary>
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
