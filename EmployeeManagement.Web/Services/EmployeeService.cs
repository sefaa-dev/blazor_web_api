using EmployeeManagement.Models;



namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        //public async Task<Employee> CreateEmployee(Employee newEmployee)
        //{
        //    return await httpClient.PostAsJsonAsync<Employee>("api/employees", newEmployee);
        //}

        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("api/employees", newEmployee);

            if (response.IsSuccessStatusCode)
            {
                // Employee tipindeki yanıtın içeriğini okuyarak dönüştürme
                return await response.Content.ReadFromJsonAsync<Employee>();
            }
            else
            {
                // Hata durumunda isteği fırlatma veya uygun bir şey yapma
                throw new Exception($"Employee creation failed with status code: {response.StatusCode}");
            }
        }

        public async Task DeleteEmployee(int id)
        {
            await httpClient.DeleteAsync($"api/employees/{id}");
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }

        //public async Task<Employee>UpdateEmployee(Employee updatedEmployee)
        //{
        //    return await httpClient.PutAsJsonAsync<Employee>("api/employees", updatedEmployee);
        //}

        public async Task<Employee> UpdateEmployee(Employee updatedEmployee)
        {
            HttpResponseMessage response = await httpClient.PutAsJsonAsync("api/employees", updatedEmployee);

            if (response.IsSuccessStatusCode)
            {
                // Employee tipindeki yanıtın içeriğini okuyarak dönüştürme
                return await response.Content.ReadFromJsonAsync<Employee>();
            }
            else
            {
                // Hata durumunda isteği fırlatma veya uygun bir şey yapma
                throw new Exception($"Employee update failed with status code: {response.StatusCode}");
            }
        }



    }
}


