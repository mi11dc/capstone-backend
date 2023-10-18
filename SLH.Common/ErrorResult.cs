using System;
using System.Collections.Generic;
using System.Text;

namespace SLH.Common
{
    public class ErrorResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult"/> class.
        /// </summary>
        public ErrorResult()
        {
            this.Message = new List<string>();
        }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        public List<string> Message { get; set; }
    }
}
