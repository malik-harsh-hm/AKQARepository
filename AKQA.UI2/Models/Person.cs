using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AKQA.UI2.Models
{
    public class Person
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Name")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Amount")]
        [DataType(DataType.Currency)]
        public decimal DecimalAmount { get; set; }

        public string StringAmount { get; set; }
    }
}