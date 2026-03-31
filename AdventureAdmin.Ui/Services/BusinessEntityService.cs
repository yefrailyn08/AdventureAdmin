using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class BusinessEntityService(
    AdventureWorksContext context
    ) : IService<Data.Models.BusinessEntity, int>
{
    public async Task<bool> Guardar(Data.Models.BusinessEntity nuevoBusinessEntity)
    {
        await context.BusinessEntities.AddAsync(nuevoBusinessEntity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.BusinessEntity?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.BusinessEntity>> GetList(Expression<Func<Data.Models.BusinessEntity, bool>> criterio)
    {
        return await context.BusinessEntities
            .Where(criterio)
            .ToListAsync();
    }
}
