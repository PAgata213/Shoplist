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
		public int ProductId { get; set; }
		public int ShopId { get; set; }
		public double Price { get; set; }
	}
}
