using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tareas.application.Context;
using tareas.application.Entities.Models;
using tareas.application.Entities.ViewModels;
using tareas.application.IServices;

namespace tareas.application.Services
{
    public class TareaService : ITareaService
    {

        private readonly ApplicationDbContext _dBContext;

        public TareaService(ApplicationDbContext dbContext)
        {
                _dBContext = dbContext;
        }

        public async Task<(int id, string mensaje)> AddAsync(TareaViewModel viewModel)
        {
            var DbSet = _dBContext.Set<TareaEntity>();

            var entity = viewModel.Adapt<TareaEntity>();

            DbSet.Add(entity);
            await _dBContext.SaveChangesAsync();

            if (entity.Id > 0)
            {
                return (entity.Id,"Guardado");
            }
            else
            {
                return (0, "Error guardado");
            }
        }

        public async Task<(bool flag, string mensaje)> DeleteAsync(int id)
        {
           // var registros = await _dBContext.Set<TareaEntity>().Where(t => t.Id.Equals(id)).ExecuteDeleteAsync();

            var tareaAEliminar = await _dBContext.Set<TareaEntity>().FindAsync(id);

            _dBContext.Set<TareaEntity>().Remove(tareaAEliminar);

            var registros = await _dBContext.SaveChangesAsync();

            if (registros > 0)
            {
                return (true, "Eliminado");
            }
            else
            {
                return (false, "Error eliminacion");
            }
        }

        public async Task<List<TareaViewModel>> GetAllAsync()
        {
            var DbSet = _dBContext.Set<TareaEntity>();
            var data = await DbSet.AsNoTracking()
                .OrderByDescending(t => t.Id)
                .ToListAsync();
            return data.Adapt<List<TareaViewModel>>();
        }

        public async Task<TareaViewModel> GetAsync(int id)
        {
            var entity = await _dBContext.Set<TareaEntity>().AsNoTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));
            if (entity != null)
            {
                return entity.Adapt<TareaViewModel>();
            }
            else
            {
                return new TareaViewModel();
            }
        }

        public Task<(bool flag, string mensaje)> UpdateAsync(TareaViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
