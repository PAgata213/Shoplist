using ShopList.Shared.DataModels.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.ShopList
{
  public class Product : EntityModel
  {
    [Required]
    [StringLength(50)]
    public string ProductName { get; set; }

    [StringLength(250)]
    public string? Description { get; set; }
    public virtual ICollection<ProductToBuy> ProductsToBuy { get; set; }
  }
}
