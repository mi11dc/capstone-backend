using System;
using System.Collections.Generic;
using System.Text;

namespace SLH.Common
{
    public class BaseSqlConstant
    {
        /// <summary>
        /// The identifier
        /// </summary>
        public const string ID = "@Id";

        /// <summary>
        /// The varchar maximum size
        /// </summary>
        public const int VARCHARMAXSIZE = 8000;

        /// <summary>
        /// The code
        /// </summary>
        public const string CODE = "@Code";

        /// <summary>
        /// The message
        /// </summary>
        public const string MESSAGE = "@Message";

        /// <summary>
        /// The pageno
        /// </summary>
        public const string LIMIT = "@Limit";

        /// <summary>
        /// The pagesize
        /// </summary>
        public const string OFFSET = "@Offset";

        /// <summary>
        /// The sortorder
        /// </summary>
        public const string SORTORDER = "@SortOrder";

        /// <summary>
        /// The sortby
        /// </summary>
        public const string SORTBY = "@SortBy";
    }
}
