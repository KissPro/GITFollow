using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_service.Mail
{
    public class MailTemplate
    {
        public static string Email_Confirm_Success = "<p>Dear {0}</br></br></p>" +
       "<p>You created ProfomaInvoice successfully.</br></br></p>" +
       "<p>Your request ID:  <strong>{1}</strong></br></br></p>" +
       "<p>Please use this id for your strip at Fushan Technology Vietnam</br></br></p>" +
       "<p>From FIH with love!</p>";
    }
}
