using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Data.Models;
using System.Security.Claims;

namespace PersonalFinanceTracker.Components.Pages;

public partial class AddTransaction
{
    private Transaction transaction = new();
    [Inject]
    public FinanceDbContext DbContext { get; set; } = default!;

    [Inject]
    public AuthenticationStateProvider AuthStateProvider { get; set; } = default!;

    [Inject]
    public NavigationManager Navigation { get; set; } = default!;

    private async Task HandleValidSubmit()
    {
        DbContext.Transactions.Add(transaction);
        await DbContext.SaveChangesAsync();

        transaction = new();
        Navigation.NavigateTo("/transactions");
    }
}
