using EmployeeManagement.Shared.Helpers;
using EmployeeManagement.Shared.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeManagement.Shared.Services
{
    public class AppService
    {
        HttpClient httpClient;

        public AppService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public Job Job;

        public async Task<SaveJobResponse> SaveJob(Job job)
        {
            SaveJobResponse message = null;
            var response = await httpClient.PostAsJsonAsync(URLStrings.ServerURL + "/job/edit", job);

            if (response.IsSuccessStatusCode)
            {
                message = await response.Content.ReadAsAsync<SaveJobResponse>();

                if (message == null)
                {
                    message = new SaveJobResponse {
                        ReturnCode = -1,
                        ReturnMessage = "Response data null"
                    };
                }
            }
            else
            {
                message = new SaveJobResponse
                {
                    ReturnCode = -1,
                    ReturnMessage = "Response status not successful"
                };
            }

            return message;
        }
    }
}
