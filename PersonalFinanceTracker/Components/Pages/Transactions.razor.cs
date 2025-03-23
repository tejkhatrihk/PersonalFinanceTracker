using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Data.Models;

namespace PersonalFinanceTracker.Components.Pages;
public partial class Transactions : ComponentBase
{
    [Inject]
    public FinanceDbContext DbContext { get; set; } = default!;
    private List<Transaction> transactions = [];

    protected override async Task OnInitializedAsync()
    {
        transactions = await DbContext.Transactions
            .Include(c=>c.Category)
            .OrderByDescending(a => a.Date)
            .ToListAsync().ConfigureAwait(true);
    }
}
