using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class ShiftService(
    AdventureWorksContext context
    ) : IService<Data.Models.Shift, byte>
{
    public async Task<bool> Guardar(Data.Models.Shift nuevoShift)
    {
        await context.Shifts.AddAsync(nuevoShift);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.Shift?> Buscar(byte id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(byte id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.Shift>> GetList(Expression<Func<Data.Models.Shift, bool>> criterio)
    {
        return await context.Shifts
            .Where(criterio)
            .ToListAsync();
    }
}
