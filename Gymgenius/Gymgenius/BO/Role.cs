namespace GymGenius.BO
{
    public class Role
    {
        public string RoleName { get; set; }

        public int RoleId
        {
            get
            {
                return (int)Enum.Parse(typeof(Roles), RoleName);
                
            }
        }

        public enum Roles
        {
            Admin = 1,
            Trainer = 2,
            Trainee = 3
        }
    }
}
