using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultilities;

namespace Services.Common
{
    public class CommonService : ICommonService
    {
        private readonly CMS_DBContext context;
        public CommonService(CMS_DBContext _context)
        {
            context = _context;
        }
        #region Accounts
        public bool ChangeAccountPassword(ChangePasswordViewModel model)
        {
            var account = context.Accounts.FirstOrDefault(x => x.Username == model.username);
            account.Password = model.reNewPassword;
            return context.SaveChanges() > 0;
        }
        public bool CheckAccountPassword(ChangePasswordViewModel model)
        {
            return (context.Accounts.FirstOrDefault(x => x.Username == model.username && x.Password == model.oldPassword) != null);
        }
        public List<Accounts> GetAccounts()
        {
            return context.Accounts.ToList();
        }
        public Accounts GetAccount(Guid id)
        {
            return context.Accounts.FirstOrDefault(x => x.Id == id);
        }
        public bool InsertOrUpdateAccount(Accounts model)
        {
            try
            {
                var Accounts = context.Accounts;
                if (model.Id != null && model.Id != Guid.Empty)
                {
                    var exist = Accounts.FirstOrDefault(x => x.Id == model.Id);
                    if (exist != null)
                    {
                        exist.FullName = model.FullName;
                        exist.Gender = model.Gender;
                        exist.Password = model.Password;
                        exist.Email = model.Email;
                        exist.Phone = model.Phone;
                        exist.Address = model.Address;
                        exist.Birthday = model.Birthday;
                        context.SaveChanges();

                        return true;
                    }
                    else return false;
                }
                else
                {
                    context.Accounts.Add(model);
                    var result = context.SaveChanges() > 0;

                    // Add orders to OrderAccount for orders with matching phone number
                    var matchingOrders = context.Orders.Where(o => o.CustomerPhone == model.Phone || o.CustomerEmail == model.Email).ToList();
                    foreach (var order in matchingOrders)
                    {
                        context.OrderAccounts.Add(new OrderAccount { OrderId = order.Id, AccountId = model.Id });
                    }
                    context.SaveChanges();

                    return result;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeleteAccount(Guid id)
        {
            var exist = context.Accounts.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (exist == null) return false;
            else
            {
                context.Accounts.Remove(exist);
                return context.SaveChanges() > 0;
            }
        }
        public bool ChangeStatus(Guid id)
        {
            var exist = context.Accounts.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (exist == null) return false;
            else
            {
                exist.IsActive = !exist.IsActive;
                if (context.SaveChanges() > 0) return exist.IsActive;
                else throw new Exception("Có lỗi xảy ra!");
            }
        }
        public bool CheckExistAccountUserName(string username)
        {
            return context.Accounts.FirstOrDefault(x => x.Username == username) != null;
        }
        public bool CheckExistAccountEmail(string email)
        {
            return context.Accounts.FirstOrDefault(x => x.Email == email) != null;
        }
        public bool CheckExistAccountPhoneNumber(string phoneNumber)
        {
            return context.Accounts.FirstOrDefault(x => x.Phone == phoneNumber) != null;
        }

        public Accounts AccountLogin(AccountLoginDTO account)
        {
            return context.Accounts.FirstOrDefault(x => x.Username == account.username && x.Password == account.password && x.IsActive == true);
        }
        #endregion

        #region CategoryNews
        public CategoryNewsViewModel GetCategoryNews(int id)
        {
            var CategoryNewses = context.CategoryNewses.AsQueryable();
            var query = from a in CategoryNewses
                        select new CategoryNewsViewModel
                        {
                            Id = a.Id,
                            CategoryDecription = a.CategoryDecription,
                            CategoryName = a.CategoryName,
                            CategoryOrder = a.CategoryOrder,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            IsHome = a.IsHome,
                            IsHot = a.IsHot,
                            IsView = a.IsView,
                            MetaDescription = a.MetaDescription,
                            MetaKeywords = a.MetaKeywords,
                            MetaTitle = a.MetaTitle,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedDate,
                        };
            return query.AsEnumerable().FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CategoryNewsViewModel> GetListCategoryNews()
        {
            var CategoryNewses = context.CategoryNewses.AsQueryable();
            var query = from a in CategoryNewses

                        select new CategoryNewsViewModel
                        {
                            Id = a.Id,
                            CategoryDecription = a.CategoryDecription,
                            CategoryName = a.CategoryName,
                            CategoryOrder = a.CategoryOrder,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            IsHome = a.IsHome,
                            IsHot = a.IsHot,
                            IsView = a.IsView,
                            MetaDescription = a.MetaDescription,
                            MetaKeywords = a.MetaKeywords,
                            MetaTitle = a.MetaTitle,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedDate,
                            Tags = a.Tags,
                        };
            return query.OrderByDescending(x => x.CreatedDate).AsEnumerable();
        }

        public bool InsertOrUpdateCategoryNews(CategoryNewsViewModel model)
        {
            try
            {
                var categoryNews = context.CategoryNewses.AsQueryable();
                if (model.Id > 0)
                {
                    var exist = categoryNews.FirstOrDefault(x => x.Id == model.Id);
                    if (exist != null)
                    {
                        PropertyCopy.Copy(model, exist);
                        context.CategoryNewses.Update(exist);
                        return context.SaveChanges() > 0;
                    }
                    else return false;
                }
                else
                {
                    var newData = new CategoryNews();
                    PropertyCopy.Copy(model, newData);
                    context.CategoryNewses.Add(newData);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public bool CheckExistNews(int CategoryId)
        {
            return context.Newses.Any(x => x.CategoryId == CategoryId);
        }
        public bool DeleteCategoryNews(int id)
        {
            var exist = context.CategoryNewses.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (exist == null) return false;
            else
            {
                context.CategoryNewses.Remove(exist);
                var oldNews = context.Newses.Where(x => x.CategoryId == id);
                context.Newses.RemoveRange(oldNews);
                return context.SaveChanges() > 0;
            }
        }
        public List<CategoryNewsViewModel> GetRandomCategoryNews(int take)
        {
            var CategoryNewses = context.CategoryNewses.AsQueryable();
            var query = from a in CategoryNewses

                        select new CategoryNewsViewModel
                        {
                            Id = a.Id,
                            CategoryDecription = a.CategoryDecription,
                            CategoryName = a.CategoryName,
                            CategoryOrder = a.CategoryOrder,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            IsHome = a.IsHome,
                            IsHot = a.IsHot,
                            IsView = a.IsView,
                            MetaDescription = a.MetaDescription,
                            MetaKeywords = a.MetaKeywords,
                            MetaTitle = a.MetaTitle,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedDate,
                            NewsCount = context.Newses.Where(x => x.CategoryId == a.Id).Count()
                        };
            return query.OrderBy(emp => Guid.NewGuid())
                .Take(take).ToList();
        }
        #endregion

        #region ProductCategory
        public ProductCategoryViewModel GetProductCategory(int id)
        {
            var ProductCategories = context.ProductCategories.AsQueryable();
            var query = from a in ProductCategories

                        select new ProductCategoryViewModel
                        {
                            Id = a.Id,
                            ParentId = a.ParentId,
                            CategoryDecription = a.CategoryDecription,
                            CategoryName = a.CategoryName,
                            CategoryOrder = a.CategoryOrder,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            IsHome = a.IsHome,
                            IsHot = a.IsHot,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedDate,
                        };
            return query.AsEnumerable().FirstOrDefault(x => x.Id == id);
        }
        // Get list danh mục sản phẩm con theo mã cha
        public List<ProductCategory> GetListDataProductCategory(int? CategoryId)
        {
            return context.ProductCategories.Where(x => x.Id != CategoryId && x.ParentId != CategoryId).ToList();
        }
        public IEnumerable<ProductCategoryViewModel> GetListProductCategory()
        {
            var ProductCategories = context.ProductCategories.AsQueryable();
            var Product = context.Products.AsQueryable();
            var query = from a in ProductCategories
                        select new ProductCategoryViewModel
                        {
                            Id = a.Id,
                            ParentId = a.ParentId,
                            CategoryDecription = a.CategoryDecription,
                            CategoryName = a.CategoryName,
                            CategoryOrder = a.CategoryOrder,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            IsHome = a.IsHome,
                            IsHot = a.IsHot,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedDate,
                            CountProduct = (from b in Product where b.CategoryId == a.Id select b).Count()
                        };
            return query.OrderByDescending(x => x.CreatedDate).AsEnumerable();
        }

        public bool InsertOrUpdateProductCategory(ProductCategoryViewModel model)
        {
            try
            {
                var ProductCategory = context.ProductCategories.AsQueryable();
                if (model.Id > 0)
                {
                    var exist = ProductCategory.FirstOrDefault(x => x.Id == model.Id);
                    if (exist != null)
                    {
                        PropertyCopy.Copy(model, exist);
                        context.ProductCategories.Update(exist);
                        return context.SaveChanges() > 0;
                    }
                    else return false;
                }
                else
                {
                    var newData = new ProductCategory();
                    PropertyCopy.Copy(model, newData);
                    context.ProductCategories.Add(newData);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        public bool CheckCanDeleteProductCategory(int CategoryId)
        {
            var can = false;
            //can = context.Newses.Any(x => x.CategoryId == CategoryId); Check tồn tại sản phẩm
            can = context.ProductCategories.Any(x => x.ParentId == CategoryId);
            return !can;
        }
        public bool DeleteProductCategory(int id)
        {
            var exist = context.ProductCategories.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (exist == null) return false;
            else
            {
                context.ProductCategories.Remove(exist);
                var oldProduct = context.Products.Where(x => x.CategoryId == id);
                context.Products.RemoveRange(oldProduct);
                return context.SaveChanges() > 0;
            }
        }
        public List<ProductCategoryViewModel> GetRandomProductCategory(int take)
        {
            var ProductCategories = context.ProductCategories.AsQueryable();
            var query = from a in ProductCategories
                        select new ProductCategoryViewModel
                        {
                            Id = a.Id,
                            ParentId = a.ParentId,
                            CategoryDecription = a.CategoryDecription,
                            CategoryName = a.CategoryName,
                            CategoryOrder = a.CategoryOrder,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            IsHome = a.IsHome,
                            IsHot = a.IsHot,
                            ModifiedBy = a.ModifiedBy,
                            ModifiedDate = a.ModifiedDate,
                            NewsCount = context.Newses.Where(x => x.CategoryId == a.Id).Count(),
                            ProductCount = context.Products.Where(x => x.CategoryId == a.Id).Count(),
                        };
            return query.OrderBy(emp => Guid.NewGuid())
                .Take(take).ToList();
        }
        #endregion

        #region Users
        public bool ChangePassword(ChangePasswordViewModel model)
        {
            var account = context.Users.FirstOrDefault(x => x.Username == model.username);
            account.Password = model.reNewPassword;
            return context.SaveChanges() > 0;
        }
        public bool CheckPassWord(ChangePasswordViewModel model)
        {
            return (context.Users.FirstOrDefault(x => x.Username == model.username && x.Password == model.oldPassword) != null);
        }
        public List<Roles> getListRole()
        {
            return context.Roles.ToList();
        }
        public List<Users> GetUsers()
        {
            return context.Users.ToList();
        }
        public Users GetUser(Guid id)
        {
            return context.Users.FirstOrDefault(x => x.Id == id);
        }
        public bool InsertOrUpdateUser(Users model)
        {
            try
            {
                var Users = context.Users.AsQueryable();
                if (model.Id != null && model.Id != Guid.Empty)
                {
                    var exist = Users.FirstOrDefault(x => x.Id == model.Id);
                    if (exist != null)
                    {
                        exist.FullName = model.FullName;
                        exist.Gender = model.Gender;
                        exist.Password = model.Password;
                        exist.Email = model.Email;
                        exist.Phone = model.Phone;
                        exist.Address = model.Address;
                        exist.Birthday = model.Birthday;

                        context.Users.Update(exist);
                        return context.SaveChanges() > 0;
                    }
                    else return false;
                }
                else
                {
                    context.Users.Add(model);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool DeleteUser(Guid id)
        {
            var exist = context.Users.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (exist == null) return false;
            else
            {
                context.Users.Remove(exist);
                return context.SaveChanges() > 0;
            }
        }
        public bool CheckExistUserName(string username)
        {
            return context.Users.FirstOrDefault(x => x.Username == username) != null;
        }
        #endregion

        #region Roles
        public List<Roles> GetListRoles()
        {
            return context.Roles.ToList();
        }

        public Roles GetRoleById(int Id)
        {
            return context.Roles.FirstOrDefault(x => x.Id == Id);
        }

        public bool InsertOrUpdateRole(Roles model)
        {
            try
            {
                var roles = context.Roles.AsQueryable();
                if (model.Id > 0)
                {
                    var exist = roles.FirstOrDefault(x => x.Id == model.Id);
                    if (exist != null)
                    {
                        exist.RoleName = model.RoleName;

                        context.Roles.Update(exist);
                        return context.SaveChanges() > 0;
                    }
                    else return false;
                }
                else
                {
                    context.Roles.Add(model);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeleteRole(int Id)
        {
            var exist = context.Roles.AsQueryable().FirstOrDefault(x => x.Id == Id);
            if (exist == null) return false;
            else
            {
                context.Roles.Remove(exist);
                return context.SaveChanges() > 0;
            }
        }
        #endregion
    }
}
