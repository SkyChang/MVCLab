using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCLab.Web.Models
{
    public class Customer
    {
        [DisplayName("ID")]
        public string ID {get; set;}

        [DisplayName("PW")]
        public string PW {get; set;}

        [DisplayName("性別")]
        public string Sex {get; set;}

        [DisplayName("地區")]
        public string Add {get;set;}

        [DisplayName("是否年滿18")]
        public bool Year18 {get;set;}

        [DisplayName("備註")]
        public string Note { get; set;}

        public string Hide { get; set;}

    }
}