using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.HTTP
{
  public class Response<T> where T : class
  {
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccessStatusCode
    {
      get { return ((int)StatusCode >= 200) && ((int)StatusCode <= 299); }
    }

    public string ErrorMessage { get; set; } = string.Empty;

    public T? DataModel { get; set; }
  }
}
