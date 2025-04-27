using System.ComponentModel.DataAnnotations;

namespace TP2_Articles.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string CustomerName { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public float TotalAmount { get; set; }
    }
}
