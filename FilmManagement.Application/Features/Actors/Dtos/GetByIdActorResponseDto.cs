namespace FilmManagement.Application.Features.Actors.Dtos
{
    public class GetByIdActorResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
