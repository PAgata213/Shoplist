using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.ShopList
{
  public class Shop : EntityModel
  {
    [Required]
    [StringLength(50)]
    public string Address { get; set; }

    [Required]
    [StringLength(6)]
    public string ZipCode { get; set; }

    [Required]
    [StringLength(50)]
    public string City { get; set; }

    [Required]
    public ShopBrand ShopBrand { get; set; }
  }
}
