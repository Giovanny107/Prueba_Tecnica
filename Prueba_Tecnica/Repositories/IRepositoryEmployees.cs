using Prueba_Tecnica.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Repositories
{
    public interface IRepositoryEmployees
    {
       Task<List<Employees>> GetAll();
    }
}
