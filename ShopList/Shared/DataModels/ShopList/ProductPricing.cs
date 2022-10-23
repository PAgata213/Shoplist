using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.ShopList
{
  public class ProductPricing : EntityModel
  {
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }

    public int ShopId { get; set; }
    [ForeignKey(nameof(ShopId))]
    public virtual Shop Shop { get; set; }

    [Required]
    public double Price { get; set; }
  }
}
