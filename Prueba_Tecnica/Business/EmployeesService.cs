using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prueba_Tecnica.Models;
using Prueba_Tecnica.Repositories;

namespace Prueba_Tecnica.Business
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IRepositoryEmployees _repository;
        private const string hourlySalary = "HourlySalaryEmployee";

        public EmployeesService(IRepositoryEmployees repositoryBase)
        {
            _repository = repositoryBase;
        }

        public async Task<List<EmployeesDTO>> GetAllEmployeesAsync()
        {
            return CalculateSalary(await _repository.GetAll());
        }

        public async Task<EmployeesDTO> GetEmployeeByIdAsync(int id)
        {
            var employees = await GetAllEmployeesAsync();
            return employees.FirstOrDefault(x => x.Id == id);
        }

        private List<EmployeesDTO> CalculateSalary(List<Employees> employees)
        {
            List<EmployeesDTO> employeesDTO = new List<EmployeesDTO>();

            foreach(var employee in employees)
            {
                var employeeDTO = SetPropertiesDTO(employee);
                if (employee.ContractTypeName.Equals(hourlySalary))
                    employeeDTO.AnnualSalary = 120 * employee.HourlySalary * 12;
                else
                    employeeDTO.AnnualSalary = employee.MonthlySalary * 12;

                employeesDTO.Add(employeeDTO);
            }

            return employeesDTO;
        }

        private EmployeesDTO SetPropertiesDTO(Employees employees)
        {
            return new EmployeesDTO
            {
                Id = employees.Id,
                Name = employees.Name,
                ContractTypeName = employees.ContractTypeName,
                RoleName = employees.RoleName,
                RoleDescription = employees.RoleDescription,
            };
        }
    }
}
