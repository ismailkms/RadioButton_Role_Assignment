using Microsoft.AspNetCore.Mvc;
using RadioButton_Role_Assignment.ExampleEntities;
using RadioButton_Role_Assignment.ExampleServices;
using RadioButton_Role_Assignment.Models;
using System.Text.Json;

namespace RadioButton_Role_Assignment.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            List<User> user = UserService.GetAllUsers();

            ViewBag.Roles = JsonSerializer.Serialize(RoleService.GetAllRoles());
            //Rolleri Jquery üzerinden dinamik bir şekilde çekmek için json'a çevirdik

            return View(user);
        }

        public async Task<JsonResult> AddRoleToUser(int userId, int roleId)
        {
            User user = UserService.GetUserById(userId);
            Role role = RoleService.GetRoleById(roleId);
            if (user != null && role != null)
                return Json($"{user.UserName} isimli kullanıcıya {role.Name} rolü atandı!");

            return Json(null);
        }

        public IActionResult AssignRoleWithCheckbox(int userId)
        {
            var user = UserService.GetUserById(userId);
            var userRole = UserService.GetUserRole(userId);
            //Burada kullanıcı rolleri List<> olarak çekilmelidir. Benim önceden oluşturduğum senaryo uyuşmadığı için ben tek çektim.
            var roles = RoleService.GetAllRoles();

            RoleAssignSendModel model = new();

            List<RoleAssignListModel> list = new();

            foreach (var role in roles)
            {
                list.Add(new()
                {
                    Name = role.Name,
                    RoleId = role.Id,
                    Exist = userRole != null ? (userRole.Name == role.Name) : false, //Burada user'ın birden çok rolü olsaydı çektiğimiz rolleri userRoles.Contains(role.Name) ile denetlerdik.
                });
            }

            model.Roles = list;
            model.UserId = userId;

            return View(model);
        }

        [HttpPost]
        public IActionResult AssignRoleWithCheckbox(RoleAssignSendModel model)
        {
            //Role Ekleme => Seçilen role'nin ilgili user'da olmaması gerekiyor.(yani Role.Exist=false)
            //Role Çıkarma => Seçilen role'nin ilgili user'da olması gerekiyor.(yani Role.Exist=true)

            var user = UserService.GetUserById(model.UserId);
            var userRole = UserService.GetUserRole(model.UserId);
            //Burada kullanıcı rolleri List<> olarak çekilmelidir. Benim önceden oluşturduğum senaryo uyuşmadığı için ben tek çektim.

            foreach (var role in model.Roles)
            {
                if (role.Exist)
                {
                    if (userRole != null ? (userRole.Name != role.Name) : true) //!userRoles.Contains(role.Name)
                    {
                        //User'ın rollerine bu rolü burada ekle
                    }
                }
                else
                {
                    if (userRole != null ? (userRole.Name == role.Name) : false) //userRoles.Contains(role.Name)
                    {
                        //User'ın rollerinden bu rolü burada sil
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}
