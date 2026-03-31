using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class CountryRegionService(
    AdventureWorksContext context
    ) : IService<Data.Models.CountryRegion, string>
{
    public async Task<bool> Guardar(Data.Models.CountryRegion nuevoPais)
    {
        await context.CountryRegions.AddAsync(nuevoPais);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.CountryRegion?> Buscar(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.CountryRegion>> GetList(Expression<Func<Data.Models.CountryRegion, bool>> criterio)
    {
        return await context.CountryRegions
            .Where(criterio)
            .ToListAsync();
    }
}
