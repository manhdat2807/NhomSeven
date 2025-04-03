namespace NhomSeven.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DOB { get; set; }
        public string Address {  get; set; }
    }
}
