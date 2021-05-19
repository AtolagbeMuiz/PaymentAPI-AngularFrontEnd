using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PaymentID {get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string CardNumber { get; set; }

        //Format "mm/yy"
        [Column(TypeName = "nvarchar(5)")]
        public string ExpiryDate { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string CVV { get; set; }
    }
}
