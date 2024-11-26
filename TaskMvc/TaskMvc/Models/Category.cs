using TaskMvc.ViewModel.ProductVM;
using TaskMvc.Models;
namespace TaskMvc.Models;
public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    public IEnumerable<Product>? Products { get; set; }
}