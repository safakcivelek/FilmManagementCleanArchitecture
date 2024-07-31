namespace FilmManagement.Application.Features.Directors.Dtos
{
    public class GetByIdDirectorResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
