using Excellentiam.Data.UnitOfWork.Interface;
using Excellentiam.DTOs;
using Excellentiam.Models;
using Excellentiam.Service.Interface;
using Microsoft.JSInterop;
using System.Text.Json;

namespace Excellentiam.Service.Impl;

public class TareaService : ITareaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJSRuntime _jsRuntime;
    public TareaService(IUnitOfWork unitOfWork, IJSRuntime jsRuntime)
    {
        _unitOfWork = unitOfWork;
        _jsRuntime = jsRuntime;
    }

    public async Task<IEnumerable<TareaDTO>> ObtenerTareas(int id)
    {
        var tareas = await _unitOfWork.Tarea.ExistenTareasUsuario(id);

        if (!tareas)
        {
            return Enumerable.Empty<TareaDTO>();
        }

        var tareasDTO = await _unitOfWork.Tarea
            .GetAllAsync<TareaDTO>(
                selector: t => new TareaDTO
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descripcion = t.Descripcion,
                    FechaCreacion = t.FechaCreacion,
                    Estado = t.Estado.ToString()
                }
            );
       
        return tareasDTO;
    }
    public async Task<TareaDTO> ObtenerTareaPorId(int id)
    {
        var tarea = await _unitOfWork.Tarea
            .GetFirstOrDefaultAsync(
                filter: t => t.Id == id,
                selector: t => new TareaDTO
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descripcion= t.Descripcion,
                    Estado= t.Estado.ToString(),
                    FechaCreacion = t.FechaCreacion,
                });

        return tarea;
    }

    public async Task<bool> RegistrarTarea(RegistrarTareaDTO registrarTareaDTO)
    {
        var json = await _jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "authUser");
        var usuarioData = JsonSerializer.Deserialize<UsuarioData>(json);


        var tarea = new Tarea
        {
            Titulo = registrarTareaDTO.Titulo,
            Descripcion = registrarTareaDTO.Descripcion,
            FechaCreacion = registrarTareaDTO.Fecha,
            UsuarioId = usuarioData.Id
        };

        await _unitOfWork.Tarea.AddAsync(tarea);
        await _unitOfWork.SaveAsync();
        return true;
    }
}