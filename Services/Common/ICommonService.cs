using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;

namespace Services.Common
{
    public interface ICommonService
    {
        #region Accounts
        bool ChangeAccountPassword(ChangePasswordViewModel model);
        bool CheckAccountPassword(ChangePasswordViewModel model);
        List<Accounts> GetAccounts();
        Accounts GetAccount(Guid id);
        bool InsertOrUpdateAccount(Accounts model);
        bool DeleteAccount(Guid id);
        bool ChangeStatus(Guid id);
        bool CheckExistAccountUserName(string username);
        bool CheckExistAccountEmail(string email);
        bool CheckExistAccountPhoneNumber(string phoneNumber);
        Accounts AccountLogin(AccountLoginDTO account);
        #endregion

        #region Users
        bool ChangePassword(ChangePasswordViewModel model);
        bool CheckPassWord(ChangePasswordViewModel model);
        List<Users> GetUsers();
        Users GetUser(Guid id);
        bool InsertOrUpdateUser(Users model);
        bool DeleteUser(Guid id);
        bool CheckExistUserName(string username);
        List<Roles> getListRole();
        #endregion
        #region CategoryNews
        IEnumerable<CategoryNewsViewModel> GetListCategoryNews();
        CategoryNewsViewModel GetCategoryNews(int id);
        bool InsertOrUpdateCategoryNews(CategoryNewsViewModel model);
        bool DeleteCategoryNews(int id);
        bool CheckExistNews(int CategoryId);
        List<CategoryNewsViewModel> GetRandomCategoryNews(int take);
        #endregion
        #region ProductCategory
        IEnumerable<ProductCategoryViewModel> GetListProductCategory();
        List<ProductCategory> GetListDataProductCategory(int? CategoryId);
        ProductCategoryViewModel GetProductCategory(int id);
        bool InsertOrUpdateProductCategory(ProductCategoryViewModel model);
        bool DeleteProductCategory(int id);
        bool CheckCanDeleteProductCategory(int CategoryId);
        List<ProductCategoryViewModel> GetRandomProductCategory(int take);
        #endregion
        #region Roles
        List<Roles> GetListRoles();
        Roles GetRoleById(int Id);
        bool InsertOrUpdateRole(Roles model);
        bool DeleteRole(int Id);
        #endregion
    }
}