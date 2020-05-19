namespace InterCareBackend.Models
{
    public interface IUser
    {

        string Email { get; set; }
        string Password { get; set; }
        string FullName { get; set; }
        string AccessLevel { get; set; }
        string Type { get; set; }


    }
}
