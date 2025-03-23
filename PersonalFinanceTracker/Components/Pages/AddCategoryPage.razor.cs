namespace PersonalFinanceTracker.Components.Pages;

public partial class AddCategoryPage
{
    private Categories? categoriesComponent;
    private async Task HandleCategoryAdded()
    {
        // Refresh the Categories component when a new category is added
        if (categoriesComponent != null)
        {
            await categoriesComponent.RefreshCategories();
        }
    }
}
