using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.ShopList
{
  public class ShopBrand : EntityModel
  {
    [Required]
    [StringLength(100)]
    public string ShopBrandName { get; set; }
  }
}
