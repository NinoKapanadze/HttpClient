using Refit;

namespace RefitTest
{
    public interface IUserClient
    {
        [Get("/api/user")]
        Task<List<UserResponseModel>> GetAll();
    }
}
