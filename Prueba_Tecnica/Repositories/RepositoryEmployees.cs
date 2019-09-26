using Newtonsoft.Json.Linq;
using Prueba_Tecnica.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Repositories
{
    public class RepositoryEmployees : IRepositoryEmployees
    {
        public async Task<List<Employees>> GetAll()
        {            
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://masglobaltestapi.azurewebsites.net/api/Employees"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return Deserialization(apiResponse);
                }
            }            
        }

        private List<Employees> Deserialization(string json)
        {
            List<Employees> employeesList = new List<Employees>();
            JArray jsonPreservar = JArray.Parse(json);
            foreach (JObject jsonOperaciones in jsonPreservar.Children<JObject>())
            {
                Employees employee = new Employees
                {
                    Id = Convert.ToInt32(jsonOperaciones["id"]),
                    Name = jsonOperaciones["name"].ToString(),
                    ContractTypeName = jsonOperaciones["contractTypeName"].ToString(),
                    RoleId = Convert.ToInt32(jsonOperaciones["roleId"]),
                    RoleName = jsonOperaciones["roleName"].ToString(),
                    RoleDescription = jsonOperaciones["roleDescription"].ToString(),
                    HourlySalary = Convert.ToInt32(jsonOperaciones["hourlySalary"]),
                    MonthlySalary = Convert.ToInt32(jsonOperaciones["monthlySalary"])
                };
                employeesList.Add(employee);
            }

            return employeesList;
        }
    }
}
