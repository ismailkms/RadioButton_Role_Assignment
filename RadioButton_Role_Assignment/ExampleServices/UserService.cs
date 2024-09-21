using RadioButton_Role_Assignment.ExampleEntities;

namespace RadioButton_Role_Assignment.ExampleServices
{
    public static class UserService
    {
        public static List<User> GetAllUsers()
        {
            return new()
            {
                new() { Id = 1, UserName = "User 1", RoleId = 4 },
                new() { Id = 2, UserName = "User 2", RoleId = null },
                new() { Id = 3, UserName = "User 3", RoleId = 2 },
                new() { Id = 4, UserName = "User 4", RoleId = null },
                new() { Id = 5, UserName = "User 5", RoleId = 1 }

            };
        }

        public static User GetUserById(int userId)
        {
           List<User> users = GetAllUsers();

           return users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
