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
    public string ProductName { get; set; }

    public string? Description { get; set; }
  }
}
