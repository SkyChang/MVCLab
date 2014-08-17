using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCLab.Domain.CRM
{
    public partial class Customer
    {
        public int ID { get; set; }

        public string UserName {get; set;}

        public string PW {get; set;}

        public string Sex {get; set;}

         [DisplayName("地區")]
        public string Add {get;set;}

        public bool Year18 {get;set;}

        public string Note { get; set;}

        public string Hide { get; set;}

    }
}