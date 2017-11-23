using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Foreignkey
{
    public class SystemicIssuesForinKey
    {
        public int SystemicIssuesID { get; set; }
        public string ClientName { get; set; }
        public string CourtsNumber { get; set; }
        public int? UserID { get; set; }

    }
}