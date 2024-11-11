using Microsoft.EntityFrameworkCore;
using ttcm_mvc.Data;
using ttcm_mvc.Interfaces;
using ttcm_mvc.Models;
using ttcm_mvc.Models.DTOs;

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

        // PageIndex :1, PageSize : 5  => 1-1 * 5 = 0 * 5 = 0
        //PageIndex :2, PageSize : 5  => 2-1 * 5 = 1 * 5 = 5
        public async Task<PaginationList<CategoryDTOResponse>> GetPaginatedListAsync(string search, int pageIndex,  int pageSize)
        {
            var query = _mainAppContext.Categories.AsQueryable();// SELECT * FROM Categfories


            if(!string.IsNullOrEmpty(search))
            {
                query = query.
                    Where(c=>c.Name.Contains(search));
            }
            var count = await query.CountAsync();
            var items = await query
                .Select(c => new CategoryDTOResponse { 
                    Id= c.Id,
                    Name = c.Name,
                })
                .OrderBy(c => c.Id)
                .OrderByDescending(c => c.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginationList<CategoryDTOResponse>(items, count, pageIndex, pageSize);

        }
    }

}
