using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace MagtifunAPI
{
    public class MagtifunHelper
    {
        private string cookie;
        private const string LOGIN_URL = "http://www.magtifun.ge/index.php?page=11&lang=ge";
        private const string SEND_URL = "http://www.magtifun.ge/scripts/sms_send.php";
        private const string BODY_PARAM = "message_body";
        private const string RECIPIENTS_PARAM = " recipients";
        private const string USER_PARAM = "user";
        private const string PASSWORD_PARAM= "password";
        /// <summary>
        /// Creates new instance of MagtifunHelper to send messages, get contacts, get remaining messages etc.
        /// </summary>
        /// <param name="mobileNumber">Mobile number which is used as Magtifun user login</param>
        /// <param name="password">Magtifun user password</param>
        public MagtifunHelper(string mobileNumber, string password)
        {
            MobileNumber = mobileNumber;
            MagtiFunPassword = password;
        }

        /// <summary>
        /// MagtiFun account mobile number
        /// </summary> 
        public string MobileNumber { get; set; }
        /// <summary>
        /// Magtifun account password
        /// </summary>
        public string MagtiFunPassword { get; set; }
        /// <summary>
        /// Sends SMS and returns response code
        /// </summary> 
        /// <param name="recipient">Recipient number who will receive the message</param>
        /// <param name="messageText">Text to be sent</param>
        public string SendSMS(string recipient, string messageText)
        {
            var cookieHeader = LogIn();

            using (var handler = new HttpClientHandler { UseCookies = false })
            using (var client = new HttpClient(handler))
            {
                var message = new HttpRequestMessage(HttpMethod.Post,SEND_URL)
                {
                    Content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>(BODY_PARAM, messageText),
                        new KeyValuePair<string, string>(RECIPIENTS_PARAM, recipient)
                    })
                };
                message.Headers.Add("Cookie", cookieHeader);
                var result = client.SendAsync(message).Result;
                var responseCode = result.Content.ReadAsStringAsync().Result;
                return responseCode;
            }
        }
        /// <summary>
        /// Returns remaining messages on current MagtiFun account or -1 if user is not logged in
        /// </summary>
        /// <returns>
        /// Number of remaining messages
        /// </returns>
        public int GetRemainingMessages()
        {
            var cookieHeader = LogIn();
            string text;

            using (var handler = new HttpClientHandler { UseCookies = false })
            using (var client = new HttpClient(handler))
            {
                var message = new HttpRequestMessage(HttpMethod.Post, LOGIN_URL);
                message.Headers.Add("Cookie", cookieHeader);
                var result = client.SendAsync(message);
                text = result.Result.Content.ReadAsStringAsync().Result;
            }

            if (!text.Contains("xxlarge dark english"))
                 return -1;
            var index1 = text.IndexOf("xxlarge dark english", StringComparison.Ordinal);
            var index2 = text.IndexOf("კრედიტი", StringComparison.Ordinal);
            var substring1 = text.Substring(index1, index2 - index1);
            var substring2 = substring1.IndexOf(">", StringComparison.Ordinal);
            var substring3 = substring1.IndexOf("<", StringComparison.Ordinal);
            var numberOfMessages = substring1.Substring(substring2 + 1, substring3 - substring2 - 1);
            return Convert.ToInt32(numberOfMessages);
        }

        private string LogIn()
        {
            if (!string.IsNullOrWhiteSpace(cookie))
            {
                return cookie;
            }

            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                  new KeyValuePair<string, string>(USER_PARAM, MobileNumber),
                  new KeyValuePair<string, string>(PASSWORD_PARAM, MagtiFunPassword)
                });

                var result = client.PostAsync(LOGIN_URL, content).Result;
                cookie = result.Headers.FirstOrDefault(x => x.Key == "Set-Cookie").Value?.FirstOrDefault();
                return cookie;
            }
        }
    }
}
