using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha1zhd.Model
{
    public class Authentication
    {
        public string login { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string confirmpassword { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    }
}
