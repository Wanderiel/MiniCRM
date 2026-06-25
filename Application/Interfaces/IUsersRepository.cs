using Application.Dtos.Users;
using Domain.Models.Users;

namespace Application.Interfaces
{
    public interface IUsersRepository
    {
        Task InsertAsync(User user);
        Task<UserDto?> GetByIdAsync(int id);
        Task<List<UserDto>> GetAllAsync();
        Task<bool> UpdateAsync(int id, UpdateUserDto user);
        Task<bool> DeleteAsync(int id);
    }
}
