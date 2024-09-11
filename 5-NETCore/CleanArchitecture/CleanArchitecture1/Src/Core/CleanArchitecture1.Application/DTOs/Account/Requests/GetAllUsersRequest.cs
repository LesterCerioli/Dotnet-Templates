using CleanArchitecture1.Application.Parameters;

namespace CleanArchitecture1.Application.DTOs.Account.Requests
{
    public class GetAllUsersRequest : PaginationRequestParameter
    {
        public string Name { get; set; }
    }
}
