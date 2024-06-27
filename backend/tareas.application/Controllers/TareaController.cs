using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using tarea.Models;
using tareas.application.Entities.ViewModels;
using tareas.application.IServices;

namespace tareas.application.Controllers
{
    [Route("tarea")]
    [ApiController]
    public class TareaController:ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareaController(ITareaService tareaService)
        {
            this._tareaService = tareaService;
        }

        [HttpGet("todo")]
        public async Task<ResultadoModel<List<TareaViewModel>>> GetAllAsync()
        {
            var data = await _tareaService.GetAllAsync();
            if (data.Any())
            {
                return ResultadoModel<List<TareaViewModel>>.Success(data);
            }
            else
            {
                return ResultadoModel<List<TareaViewModel>>.Success(new List<TareaViewModel>());
            }
        }

        [HttpGet]
        public async Task<ResultadoModel<TareaViewModel>>  GetAsync(int id)
        {
            var data = await _tareaService.GetAsync(id);
            if (data != null && data.Id > 0)
            {
                return ResultadoModel<TareaViewModel>.Success(data);
            }
            else
            {
                return ResultadoModel<TareaViewModel>.Error("No existe");
            }
        }


        [HttpPost]
        public async Task<ResultadoModel<int>> AddAsync(TareaViewModel viewModel)
        {
            var (id, msg) = await _tareaService.AddAsync(viewModel);
            if (id > 0)
            {
                return ResultadoModel<int>.Success(id);
            }
            else
            {
                return ResultadoModel<int>.Error(msg);
            }
        }

        [HttpDelete]
        public async Task<ResultadoModel<string>> DeleteAsync(int id)
        {
            var (flag, msg) = await _tareaService.DeleteAsync(id);
            if (flag)
            {
                return ResultadoModel<string>.Success(msg);
            }
            else
            {
                return ResultadoModel<string>.Error(msg);
            }
        }
    }
}
