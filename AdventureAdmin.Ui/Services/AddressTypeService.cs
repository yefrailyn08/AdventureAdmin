using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class AddressTypeService(
    AdventureWorksContext context
    ) : IService<Data.Models.AddressType, int>
{
    public async Task<bool> Guardar(Data.Models.AddressType nuevoAddressType)
    {
        await context.AddressTypes.AddAsync(nuevoAddressType);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.AddressType?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.AddressType>> GetList(Expression<Func<Data.Models.AddressType, bool>> criterio)
    {
        return await context.AddressTypes
            .Where(criterio)
            .ToListAsync();
    }
}
