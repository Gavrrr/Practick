using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace carservice.model
{
    public class User
    {
        private int id;
        private String userName;
        private String password;
        private String role;

        public User()
        {
        }

        public User(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public String Role { get => role; set => role = value; }
    }
}