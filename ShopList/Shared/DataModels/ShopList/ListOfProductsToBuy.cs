using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.ShopList
{
  public class ListOfProductsToBuy : EntityModel
  {
    [Required]
    [MaxLength(50)]
    public string ListName { get; set; }

    public virtual ICollection<ProductToBuy> ProductsToBuy { get; set; }
  }
}
