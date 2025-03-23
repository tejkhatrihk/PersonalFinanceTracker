using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.Data.Models;
public class Transaction
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Amount is required")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Date is required")]
    public DateTime? Date { get; set; } = null;
    [Required(ErrorMessage = "Description is required")]
    [MaxLength(100)]
    public string? Description { get; set; } = default!;
    public int CategoryId { get; set; }
    public Category? Category { get; set; }= default!;
}
