using Application.Dtos.Users;
using Application.Extentions;
using Application.Interfaces;
using Domain.Models.Users;

namespace Application.Services;

public class UsersService
{
    private readonly IUsersRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UsersService(IUsersRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<UserDto>> GetAllAsync() =>
        (await _repository.GetAllAsync()).Select(user => user.ToDto()).ToList();

    public async Task<UserDto?> GetAsync(int id) =>
        (await _repository.GetByIdAsync(id))?.ToDto();

    public async Task<bool> UpdateAsync(int id, UpdateUserDto updateUser)
    {
        User? user = await _repository.GetByIdAsync(id);

        if (user == null)
            return false;

        UpdateUser(user, updateUser);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        User? user = await _repository.GetByIdAsync(id);

        if (user == null)
            return false;

        _repository.Delete(user);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }

    private void UpdateUser(User user, UpdateUserDto updateUser)
    {
        UpdateEmail(user, updateUser.Email);
        UpdateFullName(user, updateUser.FirstName, updateUser.LastName);
        user.UpdateAvatatUrl(updateUser.AvatarUrl);
    }

    private void UpdateEmail(User user, string? newEmail)
    {
        if (string.IsNullOrWhiteSpace(newEmail))
            return;

        Email email = Email.Create(newEmail);
        user.UpdateEmail(email);
    }

    private void UpdateFullName(User user, string? newFirstName, string? newLastName)
    {
        if (string.IsNullOrWhiteSpace(newFirstName) && string.IsNullOrWhiteSpace(newLastName))
            return;

        string firstname = string.IsNullOrWhiteSpace(newFirstName) ? user.FullName.FirstName : newFirstName;
        string lastName = string.IsNullOrWhiteSpace(newLastName) ? user.FullName.LastName : newLastName;

        FullName fullName = FullName.Create(firstname, lastName);
        user.UpdateFullName(fullName);
    }
}
