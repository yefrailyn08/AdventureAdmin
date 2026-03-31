using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class PersonService(
    AdventureWorksContext context
    ) : IService<Data.Models.Person, int>
{
    public async Task<bool> Guardar(Data.Models.Person nuevoPerson)
    {
        await context.People.AddAsync(nuevoPerson);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.Person?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.Person>> GetList(Expression<Func<Data.Models.Person, bool>> criterio)
    {
        return await context.People
            .Where(criterio)
            .ToListAsync();
    }
}
