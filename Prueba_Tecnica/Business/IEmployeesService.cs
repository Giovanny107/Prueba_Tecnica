using Prueba_Tecnica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Business
{
    public interface IEmployeesService
    {
        Task<List<EmployeesDTO>> GetAllEmployeesAsync();
        Task<EmployeesDTO> GetEmployeeByIdAsync(int id);
    }
}
