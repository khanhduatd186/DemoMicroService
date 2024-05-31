using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;

namespace DemoMicroService.ProductService.Products;

public class ProductCreateDto : ExtensibleObject
{
    [Required]
    [StringLength(ProductConsts.NameMaxLength)]
    public string Name { get; set; } = default!;

    [Required]
    public float Price { get; set; }
}
