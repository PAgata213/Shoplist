using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.ShopList
{
  public class Shop : EntityModel
  {
    [Required(ErrorMessage = "Adres sklepu jest wymagany")]
    [StringLength(50)]
    public string Address { get; set; } = string.Empty;

    [Required(ErrorMessage = "Kod pocztowy sklepu jest wymagany")]
    [StringLength(6)]
    public string ZipCode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Miasto jest wymagane")]
    [StringLength(50)]
    public string City { get; set; } = string.Empty;

    [ForeignKey(nameof(ShopBrandId))]
    public virtual ShopBrand ShopBrand { get; set; }

    [Required(ErrorMessage = "Test")]
    public int ShopBrandId { get; set; }
  }
}
