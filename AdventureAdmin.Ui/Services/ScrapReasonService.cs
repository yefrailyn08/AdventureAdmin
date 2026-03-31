using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class ScrapReasonService(
    AdventureWorksContext context
    ) : IService<Data.Models.ScrapReason, short>
{
    public async Task<bool> Guardar(Data.Models.ScrapReason nuevoScrapReason)
    {
        await context.ScrapReasons.AddAsync(nuevoScrapReason);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.ScrapReason?> Buscar(short id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(short id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.ScrapReason>> GetList(Expression<Func<Data.Models.ScrapReason, bool>> criterio)
    {
        return await context.ScrapReasons
            .Where(criterio)
            .ToListAsync();
    }
}
