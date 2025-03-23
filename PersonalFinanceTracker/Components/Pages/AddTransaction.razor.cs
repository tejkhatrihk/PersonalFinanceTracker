using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Data.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PersonalFinanceTracker.Components.Pages;

public partial class AddTransaction
{
    private Transaction transaction = new();
    [Inject] public FinanceDbContext DbContext { get; set; } = default!;
    [Inject] public NavigationManager Navigation { get; set; } = default!;
    [Inject] public ILogger<AddTransaction> Logger { get; set; } = default!;

    private IEnumerable<Category> categories = [];

    protected async override Task OnInitializedAsync()
    {
        transaction.Date = DateTime.Now;
        categories = await DbContext.Categories.ToListAsync().ConfigureAwait(false);

        await base.OnInitializedAsync().ConfigureAwait(false);
    }

    private async Task HandleValidSubmit(Microsoft.AspNetCore.Components.Forms.EditContext args)
    {
        var validationMessages = args.GetValidationMessages();

        if (validationMessages.Any())
        {
            Logger.LogWarning("Validation failed for {EventName}. Amount: {Amount}, Date: {Date}, Description: {Description}"
                , "HandleValidSubmit", transaction.Amount, transaction.Date, transaction.Description);
        }
        else
        {
            try
            {
                DbContext.Transactions.Add(transaction);
                await DbContext.SaveChangesAsync().ConfigureAwait(false);
                transaction = new();
            }
            catch (Exception)
            {
                Logger.LogError("Error in {EventName}. Amount: {Amount}, Date: {Date}, Description: {Description}"
                    , "HandleValidSubmit", transaction.Amount, transaction.Date, transaction.Description);
            }

            Navigation.NavigateTo("/transactions");
        }
    }
}
