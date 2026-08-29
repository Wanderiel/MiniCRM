using Application.Interfaces;
using Domain.Models.Users;

namespace Application.Services;

public class UserLookupService : IUserLookup
{
    private readonly IUsersRepository _repository;

    public UserLookupService(IUsersRepository repository) =>
        _repository = repository;

    public async Task<bool> HasUserByEmail(Email email) =>
        await _repository.HasUserByEmailAsync(email);

    public async Task<bool> HasUserByUsernameAsync(string username) =>
        await _repository.HasUserByUsernameAsync(username);
}
