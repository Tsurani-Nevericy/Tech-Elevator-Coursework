using System.ComponentModel.DataAnnotations;

namespace VndrMVC
{
    public class RestockViewModel
    {
        [Required]
        [Display(Name = "Quantity")]
        public int Qty { get; set; }
    }
}
