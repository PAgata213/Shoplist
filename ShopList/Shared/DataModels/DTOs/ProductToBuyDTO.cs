using ShopList.Shared.DataModels.ShopList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.DTOs
{
  public class ProductToBuyDTO
  {
    public int Id { get; set; }

    [Required]
    public double Amount { get; set; }

    public int ProductId { get; set; }

    public ProductDTO Product { get; set; }
  }
}
