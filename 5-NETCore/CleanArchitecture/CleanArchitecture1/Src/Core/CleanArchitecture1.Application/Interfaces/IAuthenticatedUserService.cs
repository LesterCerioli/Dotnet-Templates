namespace CleanArchitecture1.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        string UserName { get; }
    }

}
