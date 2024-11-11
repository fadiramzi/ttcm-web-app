using ttcm_mvc.Models;
using ttcm_mvc.Models.DTOs;

namespace ttcm_mvc.Interfaces
{
    public interface ICategoryCRUD
    {
        Task Create(CategoryDTO c);
        Task<Category> GetById(int id);
        Task<bool> Delete(Category c);
        Task<bool> Edit(Category c);
        Task<IEnumerable<CategoryDTOResponse>> GetAll();

        Task<PaginationList<CategoryDTOResponse>> GetPaginatedListAsync(string search, int pageIndex, int pageSize);


    }
}
