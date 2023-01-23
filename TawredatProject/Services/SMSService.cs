
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net;
using System.Web;

namespace TawredatProject.Services
{
  
    public class SMSService : ISMSService
    {
         public void Main(String[] args)
        {
            String sendingResult;
            String username = "chamclinics";
            String apiKey = "31b01279bf48a7bc3d40b497adcfa409466eb30a";
            String numbers = "96654737249900"; // in a comma seperated list
            String message = HttpUtility.UrlEncode("test test agin ");
            String sender = HttpUtility.UrlEncode("Cham Clinic");

            sendingResult = Send(apiKey, username, numbers, message, sender);

            Console.WriteLine(sendingResult);
        }


        public string Send(String apiKey, String username, String numbers, String message, String sender)
        {
            String result;
            username = "966544140910";
            String sendUrl = "https://www.mora-sa.com/api/v1/sendsms?api_key=" + apiKey + "&username=" + username + "&message=" + message + "&sender=" + sender + "&numbers=" + numbers + "&response=text";

            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(sendUrl);
            ((HttpWebRequest)objRequest).ServicePoint.BindIPEndPointDelegate += (servicePoint, remoteEndPoint, retryCount) => {
                Console.WriteLine("BindIPEndpoint called");
                return new IPEndPoint(IPAddress.Parse("212.93.191.190"), 443);
            };
            objRequest.Method = "GET";
            objRequest.ContentType = "application/x-www-form-urlencoded";

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }

            return result;
        }
    }
}