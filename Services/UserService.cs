using BlazorApp1.Models;

namespace BlazorApp1.Services
{
    public class UserService
    {
        private List<User> users = new() { new User() { Email = "asdas", Name = "fxdvgxvxg", Id = 42 } };
        private int nextId = 1;

        public List<User> GetAll() => users;

        public void Add(string name, string email)
        {
            if (!string.IsNullOrEmpty(email) && users.Any(x => x.Email == email)) {
                throw new Exception("No no! Van már ilyen mail!!");
            }

            users.Add(new User
            {
                Id = nextId++,
                Name = name,
                Email = email
            });
        }

        public void Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user != null)
                users.Remove(user);
        }
    }
}
