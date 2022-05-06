using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Login
{
    public interface ILoginService
    {
        Users Login(string username, string password);
    }
}
