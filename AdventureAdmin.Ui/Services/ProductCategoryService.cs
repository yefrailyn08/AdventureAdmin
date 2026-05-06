using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class ProductCategoryService(
    AdventureWorksContext context
    ) : IService<Data.Models.ProductCategory, int>
{
    public async Task<bool> Guardar(Data.Models.ProductCategory categoria)
    {
        if (categoria.ProductCategoryId == 0)
        {
            await context.ProductCategories.AddAsync(categoria);
        }
        else
        {
            var existente = await context.ProductCategories.FindAsync(categoria.ProductCategoryId);
            if (existente == null) return false;
            
            existente.Name = categoria.Name;
            existente.ModifiedDate = DateTime.Now;
        }
        
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<Data.Models.ProductCategory?> Buscar(int id)
    {
        return await context.ProductCategories.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var categoria = await context.ProductCategories.FindAsync(id);
        if (categoria == null) return false;
        
        context.ProductCategories.Remove(categoria);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Data.Models.ProductCategory>> GetList(Expression<Func<Data.Models.ProductCategory, bool>> criterio)
    {
        return await context.ProductCategories
            .Where(criterio)
            .ToListAsync();
    }
}
