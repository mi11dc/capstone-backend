﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Common
{
    /// <summary>
    /// Class ApiResult
    /// </summary>
    /// <typeparam name="T">Item class</typeparam>
    public class ApiResult<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

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

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid()
        {
            IEnumerable<T> enumerable = this.Item as IEnumerable<T>;

            if (enumerable != null && enumerable.Any())
            {
                return true;
            }

            return this.Item != null;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is success status code.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is success status code]; otherwise, <c>false</c>.
        /// </returns>
        /// <value>
        ///   <c>true</c> if this instance is success status code; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuccessStatusCode()
        {
            return this.Code >= 200 && this.Code <= 299;
        }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <returns>returns code.</returns>
        public int GetCode()
        {
            return this.Code;
        }

        /// <summary>
        /// Sets the code.
        /// </summary>
        /// <param name="code">The code.</param>
        public void SetCode(int code)
        {
            this.Code = code;
        }

    }
}
