using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tareas.application.Entities.ViewModels;

namespace tareas.application.IServices
{
    public interface ITareaService
    {
        Task<List<TareaViewModel>> GetAllAsync();
        Task<TareaViewModel> GetAsync(int id);
        Task<(int id, string mensaje)> AddAsync(TareaViewModel viewModel);
        Task<(bool flag, string mensaje)> UpdateAsync(TareaViewModel viewModel);
        Task<(bool flag, string mensaje)> DeleteAsync(int id);
    }
}
