using System.Xml.Linq;

namespace ProjectManager.API.Models.Input
{
    public class UserInput
    {
        public UserInput(string first_name, string last_name, string email, string password)
        {
            First_Name = first_name;
            Last_Name = last_name;
            Email = email;
            Password = password;
        }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
