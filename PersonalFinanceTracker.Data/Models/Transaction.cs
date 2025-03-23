using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.Data.Models;
public class Transaction
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Amount is required")]
    public decimal Amount { get; set; }
    [Required(ErrorMessage ="Date is required")]
    public DateTime? Date { get; set; } = null;
    [Required(ErrorMessage = "Description is required")]
    public string? Description { get; set; } = default!;
}
