using CleanArchitecture1.Application.DTOs.Account.Requests;
using CleanArchitecture1.Application.DTOs.Account.Responses;
using CleanArchitecture1.Application.Wrappers;
using System.Threading.Tasks;

namespace CleanArchitecture1.Application.Interfaces.UserInterfaces
{
    public interface IGetUserServices
    {
        Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model);
    }
}
