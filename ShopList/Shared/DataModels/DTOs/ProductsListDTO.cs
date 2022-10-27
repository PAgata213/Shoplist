using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.DTOs
{
    public class ListTransferDTO<T>
    {
        public IEnumerable<T> List { get; set; }
    }
}
