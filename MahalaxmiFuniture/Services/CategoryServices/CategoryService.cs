using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories;
using MahalaxmiFuniture.Repositories.IRepositories;
using MahalaxmiFuniture.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Services.CategoryServices
{
   
    public class CategoryService : ICatergoryService
    {
        private readonly ICategoryRepository _catagoryRepository;
        private readonly IUnitOfWork _unitofWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitofWork)
        {
            _catagoryRepository = categoryRepository;
            _unitofWork = unitofWork;
        }

        public Task<Category> FindByCategoryName(string category)
        {
            return _catagoryRepository.GetCategoryByName(category);
        }

        public async Task<ServiceResponse<Category>> GetCategoryById(int id)
        {
            ServiceResponse<Category> serviceResponse = new ServiceResponse<Category>();
                var existingRecord = await _catagoryRepository.GetCategoryById(id);
                if (existingRecord == null)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "Record Not Found.";
                    return (serviceResponse);
                }
            else
            {
                serviceResponse.IsSuccess = true;
                serviceResponse.Data = existingRecord;
                return (serviceResponse);
            }
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
                var categoryList = await _catagoryRepository.GetCategories();
                //int totalItems = categoryList.Count();
                return categoryList;
            
        }

        public async Task<ServiceResponse<Category>> SaveAsync(Category category)
        {
            try {
                var existionCategory = await _catagoryRepository.GetCategoryByName(category.categoryName);
                if (existionCategory != null)
                {
                    return new ServiceResponse<Category>
                    {
                        Message = "This Category Name is already in the list",
                        IsSuccess = false
                    };
                }
                category.userId = 1;
                await _catagoryRepository.AddCategory(category);
                await _unitofWork.CompleteAsync();
                return new ServiceResponse<Category>
                {
                    Message = "New Category Saved Successfully.",
                    IsSuccess = true
                };
            }catch(Exception ex)
            {
                return new ServiceResponse<Category>
                {
                    Message = "Error occured while saving the user.",
                    IsSuccess = false,
                    Errors = ex.Message
                };
            }
           }

        public async Task<ServiceResponse<Category>> UpdateAsync(int id, Category category)
        {
            ServiceResponse<Category> serviceResponse = new ServiceResponse<Category>();
            var existingCategory = await _catagoryRepository.GetCategoryById(id);
            if (existingCategory == null)
            {
                serviceResponse.Message = "Category Not Found.";
                serviceResponse.IsSuccess = false;
                return (serviceResponse);
            }
            else
            {
                existingCategory.categoryName = category.categoryName;
                existingCategory.description = category.description;
                existingCategory.userId = category.userId;
                try {
                    _catagoryRepository.UpdateCategory(existingCategory);
                    await _unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Category Updated Successfully.";
                    return (serviceResponse);
                }
                catch(Exception ex)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "An error occured while updating a category";
                    serviceResponse.Errors = ex.Message;
                    return (serviceResponse);
                }
                
            }
        }

        public async Task<ServiceResponse<Category>> DeleteAsync(int id)
        {
            ServiceResponse<Category> serviceResponse = new ServiceResponse<Category>();
            var deletingCategory = await _catagoryRepository.GetCategoryById(id);
            if (deletingCategory == null)
            {
                serviceResponse.Message = "Record Not Found.";
                serviceResponse.IsSuccess = false;
                return (serviceResponse);
            }
            else
            {
                try
                {
                    _catagoryRepository.DeleteCategory(deletingCategory);
                    await _unitofWork.CompleteAsync();
                    serviceResponse.IsSuccess = true;
                    serviceResponse.Message = "Record deleted successfully.";
                    return (serviceResponse);
                }
                catch (Exception ex)
                {
                    serviceResponse.IsSuccess = false;
                    serviceResponse.Message = "An error occured while deleting a record.";
                    serviceResponse.Errors = ex.Message;
                    return (serviceResponse);
                }
            }
        }
    }
}
