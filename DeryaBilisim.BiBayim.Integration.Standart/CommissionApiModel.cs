using System.ComponentModel.DataAnnotations;

namespace DeryaBilisim.BiBayim.Integration.Standart
{
    public partial class CommissionApiModel
    {
        [Required]
        public string ReferalCode { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string OrderNo { get; set; }
        public string Description { get; set; }
    }
}