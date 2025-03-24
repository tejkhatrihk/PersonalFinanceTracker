using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Data.Models;

namespace PersonalFinanceTracker.Components.Pages;
public partial class Transactions : ComponentBase
{
    [Inject]
    public FinanceDbContext DbContext { get; set; } = default!;
    private IEnumerable<Transaction> transactions = [];

    protected override async Task OnInitializedAsync()
    {
        transactions = await DbContext.Transactions
            .Include(c => c.Category)
            .OrderByDescending(a => a.Date).ToListAsync().ConfigureAwait(false);
    }

    private async Task<GridDataProviderResult<Transaction>> TransactionDataProvider(GridDataProviderRequest<Transaction> request)
    {
        if (transactions is null)
            transactions = await GetTransactions().ConfigureAwait(false);

        return request.ApplyTo(transactions);
    }

    private async Task<IEnumerable<Transaction>> GetTransactions()
    {
        return await DbContext.Transactions
            .Include(c => c.Category)
            .OrderByDescending(a => a.Date).ToListAsync().ConfigureAwait(false);
    }
}
