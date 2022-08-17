using ShopList.Shared.DataModels.ShopList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.DTOs
{
  public class ShopDTO
  {
    public int Id { get; set; }

    [StringLength(50, ErrorMessage = "Adres jest za długi")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Adres jest wymagany")]
    public string Address { get; set; }

    [StringLength(6, ErrorMessage = "Kod pocztowy jest za długi")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Kod pocztowy jest wymagany")]
    public string ZipCode { get; set; }

    [StringLength(50, ErrorMessage = "Nazwa miasta jest za długa")]
    [Required(AllowEmptyStrings = false, ErrorMessage = "Miasto jest wymagane")]
    public string City { get; set; }

    [Required(ErrorMessage = "Nie wybrano Nazwy sklepu")]
    [Range(1, int.MaxValue, ErrorMessage = "Nie wybrano Nazwy sklepu")]
    public int ShopBrandId { get; set; }
  }
}
