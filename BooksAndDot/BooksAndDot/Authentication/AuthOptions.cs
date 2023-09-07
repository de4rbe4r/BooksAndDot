using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BooksAndDot.Authentication
{
    public class AuthOptions
    {
        public const string ISSUER = "localhost:5000"; // Издатель токена
        public const string AUDINCE = "localhost:3000"; // Потребитель токена

        // Минимальная длина строки, чтобы сработало шифрование - 17 символов!
        private const string KEY = "симметричныйКлючШифрования_CJIo}|{HbIu"; // Ключ для шифрации
        public const int LIFETIME = 1; // Время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
