using System.ComponentModel.DataAnnotations;

namespace productASP.Models;

public class Product
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Product name is required")]
    [StringLength(100, ErrorMessage = "Product name cannot exceed 100 characters")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Price is required")]
    [Range(typeof(decimal), "0", "1000000", ErrorMessage = "Price must be a non-negative number")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Quantity is required")]
    [Range(typeof(int), "0", "1000000", ErrorMessage = "Quantity must be a non-negative number")]
    public int Quantity { get; set; }
}