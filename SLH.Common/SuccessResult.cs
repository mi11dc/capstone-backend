using System;
using System.Collections.Generic;
using System.Text;

namespace SLH.Common
{
    public class SuccessResult<T>
        where T : class
    {
        public SuccessResult(ApiResult<T> apiResult)
        {
            this.Code = apiResult.Code;
            this.Message = new List<string> { apiResult.Message };
            this.Item = apiResult.Item;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public List<string> Message { get; set; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>
        /// The item.
        /// </value>
        public T Item { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public int Code { get; set; }
    }
}
