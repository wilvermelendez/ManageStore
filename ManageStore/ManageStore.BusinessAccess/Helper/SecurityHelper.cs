using System.Security.Cryptography;
using System.Text;

namespace ManageStore.BusinessAccess.Helper
{
    public static class SecurityHelper
    {
        public static string ToSha256(this string inputString)
        {
            var builder = new StringBuilder();
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(inputString));
                foreach (var t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
