using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopList.Shared.DataModels.ShopList;

namespace ShopList.Shared.DataModels.DTOs
{
	public class ProductPricingDTO
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Wybranie produktu jest wymagane")]
		public int ProductId { get; set; }

		[Required(ErrorMessage = "Wybranie sklepu jest wymagane")]
		public int ShopId { get; set; }

		[Required(ErrorMessage = "Podanie ceny jest wymagane")]
		public double Price { get; set; }
	}
}
