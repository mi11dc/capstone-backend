using System.ComponentModel.DataAnnotations;

namespace SLH.Common
{
    public class BaseSearchEntity
    {
        private int? pageNo = null;
        private int? pageSize = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSearchEntity"/> class.
        /// </summary>
        public BaseSearchEntity()
        {
        }

        /// <summary>
        /// Gets or sets the page no.
        /// </summary>
        /// <value>
        /// The page no.
        /// </value>
        [Range(1, int.MaxValue)]
        public int? PageNo
        {
            get
            {
                return this.pageNo ?? BaseConstant.MinPage;
            }

            set
            {
                this.pageNo = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        [Range(1, int.MaxValue)]
        public int? PageSize
        {
            get
            {
                return this.pageSize ?? BaseConstant.MinPageSize;
            }

            set
            {
                this.pageSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>
        /// The sort order.
        /// </value>
        public string SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the sort by.
        /// </summary>
        /// <value>
        /// The sort by.
        /// </value>
        public string SortBy { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <returns>the offset.</returns>
        public int? GetOffset()
        {
            return (this.PageNo - 1) * this.GetLimit();
        }

        /// <summary>
        /// Gets the offset oracle.
        /// </summary>
        /// <returns>the offset.</returns>
        public int? GetOffsetOracle()
        {
            return this.PageNo;
        }

        /// <summary>
        /// Gets the limit.
        /// </summary>
        /// <returns>the limit.</returns>
        public int? GetLimit()
        {
            return this.PageSize;
        }
    }
}
