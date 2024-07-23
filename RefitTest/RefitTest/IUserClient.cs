using Refit;

namespace RefitTest
{
    public interface IUserClient
    {
        [Get("/api/user")]
        Task<List<UserResponseModel>> GetAll();
        [Post("/api/user")]
        Task<UserResponseModel>Create(CreateUserDto dto);
    }
}
