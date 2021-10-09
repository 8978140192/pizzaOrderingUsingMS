using PizzzaOrderingFEApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PizzzaOrderingFEApplication.Services
{
    public class UserService
    {
        public UserDetail Register(UserDetail userDto)
        {
            UserDetail userDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:35558/api/");
                var postTask = client.PostAsJsonAsync<UserDetail>("User", userDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<UserDetail>();
                    data.Wait();
                    userDTO = data.Result;
                }
            }
            return userDTO;
        }
        public UserDTO Login(UserLoginDTO userDto)
        {
            UserDTO userDTO = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:35558/api/");
                var postTask = client.PostAsJsonAsync<UserLoginDTO>("User/Login", userDto);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadFromJsonAsync<UserDTO>();
                    data.Wait();
                    userDTO = data.Result;
                    //CommanUsedValued.CurrentUsser = userDTO.UserId;
                    CommanUsedValued.User = userDTO;
                }
            }
            return userDTO;
        }
    }
}
