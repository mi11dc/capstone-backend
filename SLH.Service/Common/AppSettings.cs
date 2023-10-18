using System;
using System.Collections.Generic;
using System.Text;

namespace SLH.Service.Common
{
    public class AppSettings
    {
        public static string SqlConnectionString { get; set; }
        public static string EncyptionKey { get; set; }
        public static string Secret { get; set; }
        public static int Expires { get; set; }
        public static string ServerApiKey { get; set; }
        public static string SenderId { get; set; }
        public static string SMTPmail { get; set; }
        public static string SMTPPort { get; set; }
        public static string MailFrom { get; set; }
        public static string SMTPUserName { get; set; }
        public static string SMTPPassword { get; set; }
        public static bool EnableSsl { get; set; }
        public static decimal DiscountPer { get; set; }
        public static decimal TransactionFee { get; set; }
        public static string StripePublishableKey { get; set; }
        public static string StripeSecretKey { get; set; }
        public static string StripePriceId { get; set; }
        public static Formats Formates { get; set; }
        public static NotificationStrings NotificationStrings { get; set; }
        public static FCMNotificationCred FCMNotificationCred { get; set; }
    }

    public class Formats
    {
        public string DateFormat { get; set; }
        public string DateFormat1 { get; set; }
        public string DateTimeFormat { get; set; }
        public string DateTimeFormat1 { get; set; }
    }

    public class NotificationStrings
    {
        public string CreateBookingTitle { get; set; }
        public string AcceptBookingTitle { get; set; }
        public string DeclineBookingTitle { get; set; }
        public string RealterPaidBookingTitle { get; set; }
        public string OrderPaymentTitle { get; set; }
        public string UpdateDropboxBookingTitle { get; set; }
        public string ComplateBookingTitle { get; set; }
        public string CancelBookingTitle { get; set; }
        public string RefundBookingTitle { get; set; }
        public string TicketResponseTitle { get; set; }
        public string TicketCloseTitle { get; set; }
    }

    public class FCMNotificationCred
    {
        public static string ServerKey { get; set; }
        public static string SenderId { get; set; }
    }
}
