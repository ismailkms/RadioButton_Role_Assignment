namespace RadioButton_Role_Assignment.Models
{
    public class RoleAssignListModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Exist { get; set; }
        //Bu rolün User'da olup olmadığını tutacağım property'im.
    }

    public class RoleAssignSendModel
    {
        public List<RoleAssignListModel> Roles { get; set; }

        public int UserId { get; set; }
    }
}
