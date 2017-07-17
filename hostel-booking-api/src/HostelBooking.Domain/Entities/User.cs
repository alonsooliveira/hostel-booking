using System.Text;

namespace HostelBooking.Domain.Entities
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

        public bool Authenticate(string email, string password)
        {
            //if (Email == email && Password == EncryptPassword(password))
            //    return true;

            if (Email == email)
                return true;

            return false;
        }

        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331sed-45ik-50c0-aa56-3r4598c6773");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
