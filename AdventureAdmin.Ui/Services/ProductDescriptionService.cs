using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class ProductDescriptionService(
    AdventureWorksContext context
    ) : IService<Data.Models.ProductDescription, int>
{
    public async Task<bool> Guardar(Data.Models.ProductDescription nuevoProductDescription)
    {
        await context.ProductDescriptions.AddAsync(nuevoProductDescription);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.ProductDescription?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.ProductDescription>> GetList(Expression<Func<Data.Models.ProductDescription, bool>> criterio)
    {
        return await context.ProductDescriptions
            .Where(criterio)
            .ToListAsync();
    }
}
