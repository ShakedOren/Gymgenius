namespace GymGenius.BO
{
    public class Role
    {
        public string RoleName { get; set; }

        public enum Roles
        {
            Admin = 1,
            User = 2,
        }
    }
}
