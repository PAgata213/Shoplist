using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.ShopList
{
  public class ProductToBuy : EntityModel
  {
    [Required]
    public double Amount { get; set; }

    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }
    public virtual ICollection<ListOfProductsToBuy> ListsOfProductsToBuy { get; set; }
  }
}
