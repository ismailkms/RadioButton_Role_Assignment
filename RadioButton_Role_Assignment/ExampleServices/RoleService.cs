using RadioButton_Role_Assignment.ExampleEntities;

namespace RadioButton_Role_Assignment.ExampleServices
{
    public static class RoleService
    {
        public static List<Role> GetAllRoles()
        {
            return new()
            {
                new() { Id = 1, Name = "Role 1" },
                new() { Id = 2, Name = "Role 2" },
                new() { Id = 3, Name = "Role 3" },
                new() { Id = 4, Name = "Role 4" },
                new() { Id = 5, Name = "Role 5" }

            };
        }

        public static Role GetRoleById(int roleId)
        {
            List<Role> roles = GetAllRoles();

            return roles.FirstOrDefault(r => r.Id == roleId);
        }
    }
}
