using Microsoft.AspNetCore.Identity;

namespace ShopList.Shared.DataModels.Authentication
{
  public class IdentityUserModel : IdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
