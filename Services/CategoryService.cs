using Microsoft.EntityFrameworkCore;
using ttcm_mvc.Data;
using ttcm_mvc.Models.DTOs;
using ttcm_mvc.Interfaces;
using ttcm_mvc.Models;
using ttcm_mvc.Helpers;
using System.Drawing.Printing;

namespace ttcm_mvc.Services
{
    public class CategoryService : ICategoryCRUD

    {
        private ApplicationDbContext _mainAppContext;

        public CategoryService(ApplicationDbContext mainAppContext)
        {
            _mainAppContext = mainAppContext;
        }
        public async Task Create(CategoryDTO c)
        {
            Category category = new Category();
            category.Name = c.Name;
            await _mainAppContext.Categories.AddAsync(category);
            await _mainAppContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDTOResponse>> GetAll()
        {
            // SELECT * FROM Categories
            // Join wiht Programs
            return await _mainAppContext.Categories
                .Select(c=> new CategoryDTOResponse { 
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<bool> Delete(Category c)
        {
            _mainAppContext.Categories.Remove(c);
            await _mainAppContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Edit(Category c)
        {
            try
            {
                _mainAppContext.Categories.Update(c);
                _mainAppContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }

        }

        public async Task<Category> GetById(int Id)
        {
            Category c = await _mainAppContext.Categories.FirstOrDefaultAsync(c => c.Id == Id);


            return c;
        }
        public async Task<PaginatedList<CategoryDTOResponse>> GetPaginatedCategoriesAsync(int pageIndex, int pageSize)
        {
            var query = _mainAppContext.Categories.AsQueryable(); // Assuming Categories is your DbSet

            var count = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize)
                .Select(c=> new CategoryDTOResponse { 
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            return new PaginatedList<CategoryDTOResponse>(items, count, pageIndex, pageSize);
        }
    }

}
