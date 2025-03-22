namespace PersonalFinanceTracker.Data.Models;
public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime? Date { get; set; } = null;
    public string? Description { get; set; } = default!;
}
