using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TravelApi.Models;
using TravelApi.Helpers;

namespace TravelApi.Services
{
  public interface IUserService
  {
    User Authenticate(string username, string password);
    IEnumerable<User> GetAll();
  }

  public class UserService : IUserService
  {
    private readonly AppSettings _appSettings;

    private List<User> _users = new List<User> 
    {
      new User { Id = 1, FirstName = "Michelle", LastName = "Nolastname", Username = "michelle", Password = "hello" },
      new User { Id = 2, FirstName = "Joe", LastName = "Yolo", Username = "joe", Password = "world" },
      new User { Id = 3, FirstName = "James", LastName = "Aight", Username = "james", Password = "password" }
    };

    public UserService(IOptions<AppSettings> appSettings)
    {
      _appSettings = appSettings.Value;
    }

    public User Authenticate(string username, string password)
    {
      var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

      if (user == null)
      {
        return null;
      }

      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
        {
          new Claim(ClaimTypes.Name, user.Id.ToString())
        }),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      user.Token = tokenHandler.WriteToken(token);

      user.Password = null;

      return user;
    }

    public IEnumerable<User> GetAll()
    {
      return _users.Select(x => {
        x.Password = null;
        return x;
      });
    }
  }
}