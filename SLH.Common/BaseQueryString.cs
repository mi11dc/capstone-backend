using System;
using System.Collections.Generic;
using System.Text;

namespace SLH.Common
{
    public class BaseQueryString
    {
        /// <summary>
        /// Gets or sets the page no.
        /// </summary>
        /// <value>
        /// The page no.
        /// </value>
        public int? PageNo { get; set; }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int? PageSize { get; set; }

        /// <summary>
        /// Gets or sets the sort by.
        /// </summary>
        /// <value>
        /// The sort by.
        /// </value>
        public string SortBy { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public string SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the total count.
        /// </summary>
        /// <value>
        /// The total count.
        /// </value>
        public int? TotalCount { get; set; }
    }
}
