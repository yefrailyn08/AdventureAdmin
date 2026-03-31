using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class PhoneNumberTypeService(
    AdventureWorksContext context
    ) : IService<Data.Models.PhoneNumberType, int>
{
    public async Task<bool> Guardar(Data.Models.PhoneNumberType nuevoPhoneNumberType)
    {
        await context.PhoneNumberTypes.AddAsync(nuevoPhoneNumberType);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.PhoneNumberType?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.PhoneNumberType>> GetList(Expression<Func<Data.Models.PhoneNumberType, bool>> criterio)
    {
        return await context.PhoneNumberTypes
            .Where(criterio)
            .ToListAsync();
    }
}
