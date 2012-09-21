using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Web;
using System.Threading;

namespace CmkFurnitures.Security.Authentication
{
    public class CustomFormsAuthentication : ICustomFormsAuthentication
    {
        public void SignIn(int adminId, string userName, string firstName, string lastName, bool isSystemUser, System.Web.HttpResponseBase httpResponseBase)
        {
            AdminData adminData = new AdminData
            {
                AdminId = adminId,
                UserName = userName,
                LastName = lastName,
                FirstName = firstName,
                IsSystemUser = isSystemUser
            };

            string encodedTicket = FormsAuthentication.Encrypt(
                new FormsAuthenticationTicket(
                    version: 1,
                    name: userName,
                    issueDate: DateTime.UtcNow,
                    expiration: DateTime.UtcNow.Add(FormsAuthentication.Timeout),
                    isPersistent: true,
                    userData: adminData.ToString())
            );

            HttpCookie httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encodedTicket);
            httpResponseBase.Cookies.Add(httpCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public void AuthenticateRequestDecryptCustomFormsAuthenticationTicket(HttpContext httpContext)
        {
            AdminData adminData;

            string formsCookieName = FormsAuthentication.FormsCookieName;
            HttpCookie httpCookie = httpContext.Request.Cookies[(String.IsNullOrWhiteSpace(formsCookieName)) ? Guid.NewGuid().ToString() : formsCookieName];

            if (httpCookie == null)
            {
                adminData = new AdminData();
            }
            else
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(httpCookie.Value);

                if (!AdminData.TryParse(ticket.UserData, out adminData))
                {
                    adminData = new AdminData();
                }

                CustomPrincipal principal = new CustomPrincipal(new CustomIdentity(adminData.AdminId, adminData.UserName, adminData.FirstName, adminData.LastName, adminData.IsSystemUser), null);
                httpContext.User = principal;
                Thread.CurrentPrincipal = principal;
            }
        }
    }
}
