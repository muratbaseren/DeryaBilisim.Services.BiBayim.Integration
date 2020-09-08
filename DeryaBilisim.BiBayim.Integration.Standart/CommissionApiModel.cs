using System.ComponentModel.DataAnnotations;

namespace DeryaBilisim.BiBayim.Integration.Standart
{
    public partial class CommissionApiModel
    {
        [Required]
        public string ReferalCode { get; set; }

        [Required]
        public string ProductId { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}