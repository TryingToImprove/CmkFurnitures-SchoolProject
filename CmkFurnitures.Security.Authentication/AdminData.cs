using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CmkFurnitures.Security.Authentication
{
    public class AdminData
    {
        private const string Delimeter = "||||||";

        public int AdminId { get; set; }
        public string UserName { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsSystemUser { get; set; }

        public override string ToString()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}", Delimeter, this.AdminId, this.UserName, this.FirstName, this.LastName, this.IsSystemUser);
        }

        internal static bool TryParse(string data, out AdminData adminData)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException("data");
            }

            adminData = null;

            string[] segments = data.Split(new string[] { Delimeter }, StringSplitOptions.RemoveEmptyEntries);
            if (segments.Length != 5)
            {
                return false;
            }

            adminData = new AdminData()
            {
                AdminId = int.Parse(segments[0]),
                UserName = segments[1],
                FirstName = segments[2],
                LastName = segments[3],
                IsSystemUser = bool.Parse(segments[4])
            };

            return true;
        }
    }
}
