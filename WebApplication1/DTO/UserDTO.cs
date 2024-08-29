namespace WebApplication1.DTO
{
    public class UserDTO
    {
        public UserDTO() { }

        public UserDTO(string? id, string? email, List<PlaceUrlDTO>? places)
        {
            Id = id;
            Email = email;
            Places = places;
        }

        public string? Id { get; set; }
        public string? Email { get; set; }
        public List<PlaceUrlDTO>? Places { get; set; }

    }
}