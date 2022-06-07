using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginAPI.Models.Login;

namespace LoginAPI.Domains.Login
{
    public interface ILoginDomain
    {
        int Login(Credencial credencial);
    }
}
