using BlogDataAccess.Models;

namespace HVACTopGun.UI.Services;

public class CategoryService
{
    private readonly BlogContext _context;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(BlogContext context, ILogger<CategoryService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync() =>
        await _context.Categories
         .AsNoTracking()
         .ToListAsync();


    public async Task<MethodResult> SaveCategoryAsync(Category model)
    {
        _logger.LogInformation("SaveCategoryAsync method started");

        try
        {
            if (model.Id > 0)
            {
                // update category
                var categoryToUpdate = await _context.Categories.FindAsync(model.Id);
                if (categoryToUpdate != null)
                {
                    categoryToUpdate.Name = model.Name;
                    categoryToUpdate.Slug = model.Slug.Slugify();
                    // update other properties as needed
                }
            }
            else
            {
                // create category
                model.Slug = model.Slug.Slugify();
                await _context.Categories.AddAsync(model);
            }
            await _context.SaveChangesAsync();

            _logger.LogInformation("SaveCategoryAsync method completed successfully");

            return MethodResult.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the SaveCategoryAsync method");

            //log exception
            return MethodResult.Failure(ex.Message);
        }
    }
}
