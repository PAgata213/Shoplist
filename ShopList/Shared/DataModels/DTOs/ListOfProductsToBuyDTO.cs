using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.DTOs
{
  public class ListOfProductsToBuyDTO
  {
    public int Id { get; set; }
    public string ListName { get; set; }
    public virtual ICollection<ProductDTO> ProductsToBuy { get; set; }
  }
}
