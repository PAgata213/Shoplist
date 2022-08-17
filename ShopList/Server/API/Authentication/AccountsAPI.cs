using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopList.Shared.DataModels.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopList.Server.API.Authentication
{
  public static class AccountsAPI
  {
    public static void RegisterAccountsAPI(this WebApplication app)
    {
      app.MapPost(ShopList.Shared.APIAdressess.RegisterUser, RegisterUser);
      app.MapPost(ShopList.Shared.APIAdressess.LoginUser, LoginUser);
    }

    private static async Task<IResult> RegisterUser(UserManager<IdentityUserModel> userManager, RegistrationUserDTO userForRegistration)
    {
      if (userForRegistration == null)
      {
        return TypedResults.BadRequest();
      }
      var existingUser = await userManager.FindByEmailAsync(userForRegistration.Email);
      if (existingUser != null)
      {
        return TypedResults.BadRequest();
      }

      var user = new IdentityUserModel
      {
        Email = userForRegistration.Email,
        UserName = userForRegistration.Email
      };

      var result = await userManager.CreateAsync(user, userForRegistration.Password);
      if (!result.Succeeded)
      {
        return TypedResults.BadRequest(result.Errors);
      }
      return TypedResults.Ok();
    }

    private static async Task<IResult> LoginUser(IConfiguration config, UserManager<IdentityUserModel> userManager, LoginUserDTO loginUser)
    {
      var user = await userManager.FindByEmailAsync(loginUser.Email);
      if (user == null)
      {
        return TypedResults.Unauthorized();
      }

      if (!await userManager.CheckPasswordAsync(user, loginUser.Password))
      {
        return TypedResults.Unauthorized();
      }

      var signingCredentials = GetSigningCredentials(config.GetSection("JwtSettings"));
      var claims = await userManager.GetClaimsAsync(user);
      var tokenOptions = GenerateTokenOptions(signingCredentials, claims, config.GetSection("JwtSettings"));
      var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

      return TypedResults.Ok(new AuthenticatedUserModel { AccessToken = token });
    }

    private static SigningCredentials GetSigningCredentials(IConfigurationSection jwtConfig)
    {
      var key = Encoding.UTF8.GetBytes(jwtConfig.GetSection("securityKey").Value!);
      var secret = new SymmetricSecurityKey(key);

      return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private static JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, IEnumerable<Claim> claims, IConfigurationSection jwtConfig)
      => new JwtSecurityToken(
            issuer: jwtConfig.GetSection("validIssuer").Value,
            audience: jwtConfig.GetSection("validAudience").Value,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtConfig.GetSection("expiryInMinutes").Value)),
            signingCredentials: signingCredentials);
  }
}
