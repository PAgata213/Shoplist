using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopList.Shared.DataModels.Authentication
{
  public class AuthenticatedUserModel
  {
    public string AccessToken { get; set; }
    public string UserName { get; set; }
    public string ErrorMessage { get; set; }
  }
}
