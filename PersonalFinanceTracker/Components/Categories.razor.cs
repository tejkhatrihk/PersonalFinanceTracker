using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PersonalFinanceTracker.Data;
using PersonalFinanceTracker.Data.Models;

namespace PersonalFinanceTracker.Components;
public partial class Categories
{
    private List<Category> categories = new();
    [Inject] public FinanceDbContext DbContext { get; set; } = default!;
    protected override async Task OnInitializedAsync()
    {
        await LoadCategories();
    }

    public async Task RefreshCategories()
    {
        await LoadCategories();
    }

    private async Task LoadCategories()
    {
        categories = await DbContext.Categories.ToListAsync().ConfigureAwait(true);
        StateHasChanged();
    }

    
}
