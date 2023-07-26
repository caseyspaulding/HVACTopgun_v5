using HVACTopGun.UI.Data;
using HVACTopGun.UI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HVACTopGun.UI.Features.Blog.Services;

public class CategoryService
{
    private readonly BlogContext _context;

    public CategoryService(BlogContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _context.Categories
         .AsNoTracking()
         .ToListAsync();
    }
}
