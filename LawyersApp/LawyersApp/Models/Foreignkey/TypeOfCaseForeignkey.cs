using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Foreignkey
{
    public class TypeOfCaseForeignkey
    {

        public int TypeOfCaseID { get; set; }
        public string TypeOfCase { get; set; }
        public int IssuesTypeID { get; set; }
    }
}