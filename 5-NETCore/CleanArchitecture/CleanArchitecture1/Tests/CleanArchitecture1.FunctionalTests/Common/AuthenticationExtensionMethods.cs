using CleanArchitecture1.Application.DTOs.Account.Responses;
using CleanArchitecture1.Application.Wrappers;

namespace CleanArchitecture1.FunctionalTests.Common
{
    public static class AuthenticationExtensionMethods
    {
        public static async Task<AuthenticationResponse> GetGhostAccount(this HttpClient client)
        {
            var url = ApiRoutes.V1.Account.Start;

            var result = await client.PostAndDeserializeAsync<BaseResult<AuthenticationResponse>>(url);

            return result.Data;
        }
    }
}
