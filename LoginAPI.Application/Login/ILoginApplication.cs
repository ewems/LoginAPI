using LoginAPI.Domains.Login;
using LoginAPI.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAPI.Application.Login
{
    public interface ILoginApplication
    {
        int Login(Credencial credencial);
    }
}
