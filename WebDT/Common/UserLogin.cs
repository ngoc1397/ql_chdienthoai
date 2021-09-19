using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDT.Common
{
    [Serializable]
    public class UserLogin
    {
        public string UserName { get; set; }
        public int UserID { get; set; }
        public string DisplayName { get; set; }
    }
}