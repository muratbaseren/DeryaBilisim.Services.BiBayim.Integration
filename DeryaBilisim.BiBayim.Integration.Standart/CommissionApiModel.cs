using System;
using System.ComponentModel.DataAnnotations;

namespace DeryaBilisim.BiBayim.Integration.Standart
{
    public partial class CommissionApiModel
    {
        [Required]
        public string ReferalCode { get; set; }

        [Required] // ProductPrice
        public decimal Price { get; set; }

        [Required]
        public string Barcode { get; set; }

        [Required]
        public string ProductCode { get; set; }

        public string OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Description { get; set; }
    }
}