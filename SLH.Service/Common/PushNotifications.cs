using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SLH.Service.Common
{
    public class PushNotifications
    {
        public static void SendNotification(string title, string body, int type, long? primaryKey, List<string> deviceIds)
        {
            try
            {
                dynamic data = new ExpandoObject();


                if (deviceIds.Count > 0)
                {
                    IDictionary<string, object> tempObject2 = data;
                    tempObject2.Add("registration_ids", deviceIds);
                }
                else
                {
                    IDictionary<string, object> tempObject = data;
                    tempObject.Add("to", deviceIds.First());
                }

                object data1;

                data1 = new
                {
                    title,
                    body,
                    type,
                    primaryKey
                };

                IDictionary<string, object> tempObject1 = data;
                tempObject1.Add("notification", data1);
                tempObject1.Add("data", data1);

                var json = JsonConvert.SerializeObject(data);
                Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);

                string ServerApiKey = AppSettings.ServerApiKey;
                string SenderId = AppSettings.SenderId;

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", ServerApiKey));

                tRequest.Headers.Add(string.Format("Sender: id={0}", SenderId));

                tRequest.ContentLength = byteArray.Length;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                String sResponseFromServer = tReader.ReadToEnd();

                tReader.Close();
                dataStream.Close();
                tResponse.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
