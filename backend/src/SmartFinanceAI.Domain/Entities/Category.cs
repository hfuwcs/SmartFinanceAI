using SmartFinanceAI.Domain.Common;

public class Category: BaseEntity
{
    public string Name { get; set; } = default!;
    public string Icon { get; set; } = default!;
    public Guid? ParentCategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public List<Category> SubCategories { get; set; } = new List<Category>();
}