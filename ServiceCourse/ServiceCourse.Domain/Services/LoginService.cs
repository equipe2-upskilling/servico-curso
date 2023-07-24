using ServiceCourse.Data.Entities;
using ServiceCourse.Data.Repositories;
using ServiceCourse.Domain.Authentication;
using ServiceCourse.Domain.Models;

namespace ServiceCourse.Domain.Services
{
    public class LoginService
    {
        public LoginRepository _repository = new LoginRepository();
        CryptoHelper cryptoHelper = new CryptoHelper();

        public LoginModel GetuserByEmail(string email, string password)
        {
            var login = _repository.GetuserByEmail(email);

            var loginModel = new LoginModel()
            {
                Id = login.Id,
                Email = login.Email,
                Password = login.Password,
                Salt = login.Salt
            };

            return loginModel;
        }
        public LoginModel GetLogin(string email, string password)
        {
            var login = _repository.GetLogin(email, password);

            var loginModel = new LoginModel()
            {
                Id = login.Id,
                Email = login.Email,
                Password = login.Password,
                Salt = login.Salt
            };

            return loginModel;
        }

        public bool Authenticate(string password, string storedHash, string salt)
        {
            // Gera o hash da senha fornecida usando o mesmo "salt" armazenado no banco de dados
            string hashedPassword = cryptoHelper.Encrypt(password, salt);

            // Compara os hashes gerados
            return storedHash.Equals(hashedPassword);
        }
    }
}
