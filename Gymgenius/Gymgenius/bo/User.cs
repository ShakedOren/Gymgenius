namespace Gymgenius.bo
{
    public class User
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
    }
}
