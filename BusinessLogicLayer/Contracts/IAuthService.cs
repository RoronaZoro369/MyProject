using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Contracts
{
    public interface IAuthService
    {
        bool ValidateUser(string UserID, string Password);
    }
}
