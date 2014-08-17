using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//NameSpace必須和Customer一樣
namespace MVCLab.Domain.CRM
{
    [MetadataType(typeof(CustomerMetaData))]
    public partial class Customer
    {

        //必須為Cusomter可存取的範圍
        private class CustomerMetaData
        {
            [Required]
            [DisplayName("UserName")]
            public string UserName { get; set; }

            [DisplayName("PW")]
            public string PW { get; set; }

            [DisplayName("性別")]
            public string Sex { get; set; }

            [DisplayName("地區")]
            public string Add { get; set; }

            [DisplayName("是否年滿18")]
            public bool Year18 { get; set; }

            [DisplayName("備註")]
            public string Note { get; set; }


            //[NotMapped]
            //public string Note2 { get; set; }

        }
    }

    
}
