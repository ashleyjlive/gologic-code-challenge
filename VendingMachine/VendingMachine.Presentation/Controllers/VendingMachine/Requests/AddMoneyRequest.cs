using System.ComponentModel.DataAnnotations;

namespace VendingMachine.Presentation.Controllers.VendingMachine.Requests
{
    public class AddMoneyRequest
    {
        [Required]
        public decimal Amount { get; set; }
    }
}
