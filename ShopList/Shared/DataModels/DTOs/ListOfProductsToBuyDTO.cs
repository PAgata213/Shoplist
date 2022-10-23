using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.DTOs
{
  public class ListOfProductsToBuyDTO
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "Shop list name is Required")]
    [MaxLength(50)]
    public string ListName { get; set; }

    public virtual ICollection<ProductToBuyDTO> ProductsToBuy { get; set; }
  }
}
