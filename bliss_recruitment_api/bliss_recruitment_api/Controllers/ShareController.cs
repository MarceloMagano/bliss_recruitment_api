using System;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web.Http;

namespace bliss_recruitment_api.Controllers
{
    public class ShareController : ApiController
    {
        /// <summary>
        /// Share Url via Email
        /// </summary>
        /// <param name="destination_email"></param>
        /// <param name="content_url"></param>
        /// <returns></returns>
        // POST: api/Share?destination_email={destination_email}&content_url={content_url}
        public IHttpActionResult PostShare(string destination_email, string content_url)
        {
            //to send using google smtp it is necessary to change google account security options to allow or you get this message:
            // The SMTP server requires a secure connection or the client was not authenticated. The server response was: 5.5.1 Authentication Required.

            //for test purpose the Send() will save a file to the C:\ directory

            // !!!!!!!! - IMPORTANT - !!!!!!!!
            //TO SAVE THE FILE IS NECESSARY FOR VS TO BE RUNNING AS ADMINISTRATOR

            MailMessage mail = new MailMessage(ConfigurationManager.AppSettings["email"], destination_email);
            SmtpClient client = new SmtpClient()
            {
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = "C:\\"
            };

            mail.Subject = string.Format("HELLO from {0}", destination_email);
            mail.Body = string.Format("Your friend {0} want you to check out this Url: {1}", destination_email, content_url);

            client.Send(mail);

            return Ok("Email Sent");
        }
    }
}
