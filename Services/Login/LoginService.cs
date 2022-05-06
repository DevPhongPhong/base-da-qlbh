using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly CMS_DBContext context;
        public LoginService(CMS_DBContext _context)
        {
            context = _context;
        }
        public Users Login(string username, string password)
        {
            return context.Users.AsQueryable().FirstOrDefault(x => x.Username == username && x.Password == password);
        }
    }
}
