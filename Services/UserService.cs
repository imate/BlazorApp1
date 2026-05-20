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
