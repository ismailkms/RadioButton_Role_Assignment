using Microsoft.AspNetCore.Mvc;
using RadioButton_Role_Assignment.ExampleEntities;
using RadioButton_Role_Assignment.ExampleServices;
using System.Text.Json;

namespace RadioButton_Role_Assignment.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            List<User> user = UserService.GetAllUsers();

            ViewBag.Roles =  JsonSerializer.Serialize(RoleService.GetAllRoles());
            //Rolleri Jquery üzerinden dinamik bir şekilde çekmek için json'a çevirdik

            return View(user);
        }

        public async Task<JsonResult> AddRoleToUser(int userId, int roleId)
        {
            User user = UserService.GetUserById(userId);
            Role role = RoleService.GetRoleById(roleId);
            if(user != null && role != null)
                return Json($"{user.UserName} isimli kullanıcıya {role.Name} rolü atandı!");

            return Json(null);
        }


    }
}
