using HVACTopGun.UI.Data;
using HVACTopGun.UI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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

    public async Task SaveCategoryAsync(Category model)
    {
        if (model.Id > 0)
        {
            // update category
            _context.Categories.Update(model);
        }
        else
        {
            // create category
            await _context.Categories.AddAsync(model);
        }
        await _context.SaveChangesAsync();
    }

    private string Slugify(string name) =>
        Regex.Replace(name.ToLower(), @"[^a-zA-Z0-9\-_]", "-", RegexOptions.Compiled, TimeSpan.FromSeconds(1))
            .Replace("--", "-")
            .Trim('-');



}
