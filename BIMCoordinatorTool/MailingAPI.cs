using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;

namespace BIMCoordinatorTool
{
    public class MailingApi
    {
        public ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2007_SP1);

        public void serviceSetup()
        {
            service.Credentials = new WebCredentials("frte@cowi.com", "Apk4pm5123");

            service.TraceEnabled = true;
            service.TraceFlags = TraceFlags.All;

            service.AutodiscoverUrl("frte@cowi.com", RedirectionUrlValidationCallback);
        }

        public void readMail()
        {
            FindItemsResults<Item> findResults = service.FindItems(WellKnownFolderName.Inbox, new ItemView(10));

            var mails = findResults.Items;

            foreach (var mail in mails)
            {
                mail.Load();
                string mailMessage = mail.Body.Text;

            }
        }

        public void SendMail()
        {
            EmailMessage email = new EmailMessage(service);

            email.ToRecipients.Add("frederik.t91@gmail.com");

            email.Subject = "HelloWorld";
            email.Body = new MessageBody("This is the first email I've sent by using the EWS Managed API");

            email.Send();
        }

        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;

            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            return result;
        }
    }
}
