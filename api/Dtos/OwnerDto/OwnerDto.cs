using api.Dtos.PetDto;


namespace api.Dtos.OwnerDto
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public List<PetDisplayDto> Pets { get; set; } = new List<PetDisplayDto>();
    }
}