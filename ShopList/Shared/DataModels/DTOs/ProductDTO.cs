using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.DTOs
{
  public class ProductDTO
  {
    [Required(ErrorMessage = "Nazwa produktu nie może być pusta!")]
    public string ProductName { get; set; }

    public string? Description { get; set; }
  }
}
