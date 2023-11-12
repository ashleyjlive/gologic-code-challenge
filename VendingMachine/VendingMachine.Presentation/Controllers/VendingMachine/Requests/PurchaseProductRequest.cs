using System.ComponentModel.DataAnnotations;

namespace VendingMachine.Presentation.Controllers.VendingMachine.Requests
{
    public class PurchaseProductRequest
    {
        [Required]
        public Guid SlotId { get; set; }
    }
}
