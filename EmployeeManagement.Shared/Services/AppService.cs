using EmployeeManagement.Shared.Helpers;
using EmployeeManagement.Shared.Models;
using System.Collections.Generic;
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

        public async Task<SaveResponse> SaveJob(Job job)
        {
            SaveResponse message = null;
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(URLStrings.ServerURL + "/job/edit", job);

            if (response.IsSuccessStatusCode)
            {
                message = await response.Content.ReadAsAsync<SaveResponse>();

                if (message == null)
                {
                    message = new SaveResponse {
                        ReturnCode = -1,
                        ReturnMessage = "Response data null"
                    };
                }
            }
            else
            {
                message = new SaveResponse
                {
                    ReturnCode = -1,
                    ReturnMessage = "Response status not successful"
                };
            }

            return message;
        }

        public async Task<SaveResponse> DeleteJob(Job job)
        {
            SaveResponse message = null;
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(URLStrings.ServerURL + "/job/delete", job);

            if (response.IsSuccessStatusCode)
            {
                message = await response.Content.ReadAsAsync<SaveResponse>();

                if (message == null)
                {
                    message = new SaveResponse
                    {
                        ReturnCode = -1,
                        ReturnMessage = "Response data null"
                    };
                }
            }
            else
            {
                message = new SaveResponse
                {
                    ReturnCode = -1,
                    ReturnMessage = "Response status not successful"
                };
            }

            return message;
        }

        public Employee Employee;

        public async Task<SaveResponse> SaveEmployee(Employee employee)
        {
            SaveResponse message = null;
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(URLStrings.ServerURL + "/employee/edit", employee);

            if (response.IsSuccessStatusCode)
            {
                message = await response.Content.ReadAsAsync<SaveResponse>();

                if (message == null)
                {
                    message = new SaveResponse
                    {
                        ReturnCode = -1,
                        ReturnMessage = "Response data null"
                    };
                }
            }
            else
            {
                message = new SaveResponse
                {
                    ReturnCode = -1,
                    ReturnMessage = "Response status not successful"
                };
            }

            return message;
        }
    }
}
