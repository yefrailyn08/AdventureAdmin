using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class LocationService(
    AdventureWorksContext context
    ) : IService<Data.Models.Location, short>
{
    public async Task<bool> Guardar(Data.Models.Location nuevaLocation)
    {
        await context.Locations.AddAsync(nuevaLocation);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.Location?> Buscar(short id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(short id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.Location>> GetList(Expression<Func<Data.Models.Location, bool>> criterio)
    {
        return await context.Locations
            .Where(criterio)
            .ToListAsync();
    }
}
