namespace PackageGroup.Ecommerce.Application.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Token { get; set; } = null!;
    }
}
