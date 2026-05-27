using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class UserService
    {
        private List<User> users;
        private int nextId;

        public UserService()
        {
            string name = "Teszt Elek";
            users = new() { new User() { Name = name, Email = GenerateMail(name), Id = 1 } };
            nextId = users.Max(x => x.Id) + 1;
        }

        public List<User> GetAll() => users;

        public string GenerateMail(string name)
        {
            string result;
            int counter = 1;
            do
            {
                result = name.Replace(" ", ".").ToLower() + (counter == 1 ? "" : counter) + "@nanoworx.hu";
                counter++;
            }
            while (users != null && users.Any(x => x.Email == result));
            return result;
        }

        public void Add(string name, string email)
        {
            if (!string.IsNullOrEmpty(email) && users.Any(x => x.Email == email))
            {
                throw new Exception("No no! Van már ilyen mail!!");
            }

            users.Add(new User
            {
                Id = nextId++,
                Name = name,
                Email = email
            });
        }

        public void Update(int id, string name, string email)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (!string.IsNullOrEmpty(email) && users.Any(x => x.Email == email && x.Id != id))
            {
                throw new Exception("No no! Van már ilyen mail!!");
            }

            user.Name = name;
            user.Email = email;
        }

        public void Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
        }
    }
}
