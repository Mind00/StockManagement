using MahalaxmiFuniture.DTOs.loginViewModel;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.Employee
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
        IEnumerable<User> GetAll();
        User GetById(int id);
        //Task<IEnumerable<User>> GetAll();
        //Task<User> GetById(int id);
        //Task<ServiceResponse<User>> CreateUser(User user);
    }
}
