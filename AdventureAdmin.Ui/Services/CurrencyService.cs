using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class CurrencyService(
    AdventureWorksContext context
    ) : IService<Data.Models.Currency, string>
{
    public async Task<bool> Guardar(Data.Models.Currency nuevaMoneda)
    {
        await context.Currencies.AddAsync(nuevaMoneda);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.Currency?> Buscar(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.Currency>> GetList(Expression<Func<Data.Models.Currency, bool>> criterio)
    {
        return await context.Currencies
            .Where(criterio)
            .ToListAsync();
    }
}
