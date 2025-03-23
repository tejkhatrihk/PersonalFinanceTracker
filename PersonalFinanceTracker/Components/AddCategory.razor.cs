using Microsoft.AspNetCore.Components;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Data.Models;

namespace PersonalFinanceTracker.Components;

public partial class AddCategory
{
    [Parameter] public EventCallback OnCategoryAdded { get; set; }
    private Category category = new() { Name = "" };
    [Inject] public FinanceDbContext DbContext { get; set; } = default!;
    [Inject] public NavigationManager Navigation { get; set; } = default!;
    [Inject] public ILogger<AddCategory> Logger { get; set; } = default!;

    private async Task HandleValidSubmit(Microsoft.AspNetCore.Components.Forms.EditContext args)
    {
        var validationMessages = args.GetValidationMessages();
        if (validationMessages.Any())
        {
            Logger.LogWarning("Validation failed for {EventName}. Name: {Name}"
                , "HandleValidSubmit", category.Name);
        }
        else
        {
            try
            {
                await SaveCategory(category);
                await OnCategoryAdded.InvokeAsync().ConfigureAwait(false);
                category = new() { Name = "" };
            }
            catch (Exception)
            {
                Logger.LogError("Error in {EventName}. Name: {Name}"
                    , "HandleValidSubmit", category.Name);
            }

        }
    }

    private async Task SaveCategory(Category category)
    {
        DbContext.Categories.Add(category);
        await DbContext.SaveChangesAsync().ConfigureAwait(false);
        await Task.CompletedTask; 
    }
}
