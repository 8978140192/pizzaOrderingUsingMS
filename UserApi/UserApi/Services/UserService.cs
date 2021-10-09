using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserApi.Models;

namespace UserApi.Services
{
    public class UserService
    {
        private readonly UserDetailContext _context;
        private readonly ITokenService _tokenService;

        
        public UserService(UserDetailContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        public UserDTO Register(UserDTO userDto)
        {
            try
            {
                using var hmac = new HMACSHA512();
                var user = new UserDetail()
                {
                    UserId = userDto.UserId,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
                    PasswordSalt = hmac.Key,
                    UserName= userDto.UserName,
                    UserPhone = userDto.UserPhone,
                    UserAge = userDto.UserAge,
                    UserAddress = userDto.UserAddress
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                
                return userDto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public UserDTO Login(UserDTO userDto)
        {
            try
            {
                UserDTO user = new();
                var myUser = _context.Users.SingleOrDefault(u => u.UserId == userDto.UserId);
                if (myUser != null)
                {
                    using var hmac = new HMACSHA512(myUser.PasswordSalt);
                    var userPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));

                    for (int i = 0; i < userPassword.Length; i++)
                    {
                        if (userPassword[i] != myUser.PasswordHash[i])
                            return null;
                    }
                    //userDto.jwtToken = _tokenService.CreateToken(userDto);
                    userDto.Password = "";


                    user.UserId = myUser.UserId;
                    user.UserName = myUser.UserName;
                    user.UserAddress = myUser.UserAddress;
                    user.jwtToken= _tokenService.CreateToken(userDto);
                    return user;
                    //return myUser;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
