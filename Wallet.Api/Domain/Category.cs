using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Api.Domain;

public class Category: Entity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public CategoryNature CategoryNature { get; set; }
    public ICollection<Category> SubCategories { get; set; } = new List<Category>();
    [ForeignKey("Category")]
    public int ParentCategoryId { get; set; }
    public Category ParentCategory { get; set; }
}

public enum CategoryNature
{
    None = 0,
    Must = 1,
    Need = 2,
    Want = 3,
}