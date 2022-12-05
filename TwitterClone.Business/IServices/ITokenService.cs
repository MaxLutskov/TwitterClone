using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Business.Models;

namespace TwitterClone.Business.IServices
{
    public interface ITokenService
    {
        string BuildToken(string key, UserModel user);
        bool ComparePasswords(string inputPassword, string hashedPassword, string salt);
        bool ValidateUser(UserModel user);
    }
}
