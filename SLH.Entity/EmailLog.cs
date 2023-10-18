using System;
using System.Collections.Generic;
using System.Text;

namespace SLH.Entity
{
    public class EmailLog
    {
        public EmailLog()
        {

        }

        public EmailLog(EmailParams emailParams, bool isSuccess, string message)
        {
            this.EmailParams = emailParams;
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        public EmailParams EmailParams { get; set; }

        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
