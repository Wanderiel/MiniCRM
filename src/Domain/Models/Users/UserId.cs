namespace Domain.Models.Users;

public struct UserId
{
    private int _id;

    public UserId(int id) =>
        _id = id;

    public int Value => _id;
}
