using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Ultilities;

namespace Services.Product
{
    public class ProductService : IProductService
    {
        private readonly CMS_DBContext context;
        public ProductService(CMS_DBContext _context)
        {
            context = _context;
        }

        public bool DeleteProduct(int id)
        {
            var exist = context.Products.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (exist == null) return false;
            else
            {
                var productImageExist = context.ProductImageses.Where(x => x.ProductId == id);
                context.Products.Remove(exist);
                context.ProductImageses.RemoveRange(productImageExist);
                return context.SaveChanges() > 0;
            }
        }

        public List<ProductImages> GetAllProductImages(int productId)
        {
            return context.ProductImageses.Where(x => x.ProductId == productId).ToList();
        }

        public ProductViewModel GetProduct(int id)
        {
            try
            {
                var query = from a in context.Products
                            where a.Id == id
                            select new ProductViewModel
                            {
                                CategoryId = a.CategoryId,
                                Code = a.Code,
                                CreatedBy = a.CreatedBy,
                                CreatedDate = a.CreatedDate,
                                Description = a.Description,
                                SubDes = a.SubDes,
                                Id = a.Id,
                                IsHome = a.IsHome,
                                IsHot = a.IsHot,
                                MainImageLarge = a.MainImageLarge,
                                MainImageThumb = a.MainImageThumb,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedDate = a.ModifiedDate,
                                Name = a.Name,
                                Branch = a.Branch,
                                Price = a.Price,
                                ProductCategory = context.ProductCategories.Where(x => x.Id == a.CategoryId).FirstOrDefault(),
                                ProductImages = context.ProductImageses.Where(x => x.ProductId == a.Id).ToList(),
                                ProductImagesId = a.ProductImagesId,
                                PromotionPrice = a.PromotionPrice,
                                IsPromote = a.IsPromote,
                                Quantity = a.Quantity
                            };
                return query.First();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            try
            {
                var x = context.Products.ToList();
                var query = from a in context.Products
                            select new ProductViewModel
                            {
                                CategoryId = a.CategoryId,
                                Code = a.Code,
                                CreatedBy = a.CreatedBy,
                                CreatedDate = a.CreatedDate,
                                Description = a.Description,
                                Id = a.Id,
                                IsHome = a.IsHome,
                                IsHot = a.IsHot,
                                MainImageLarge = a.MainImageLarge,
                                MainImageThumb = a.MainImageThumb,
                                ModifiedBy = a.ModifiedBy,
                                ModifiedDate = a.ModifiedDate,
                                Name = a.Name,
                                Price = a.Price,
                                ProductCategory = context.ProductCategories.Where(x => x.Id == a.CategoryId).FirstOrDefault(),
                                ProductImages = context.ProductImageses.Where(x => x.ProductId == a.Id).ToList(),
                                ProductImagesId = a.ProductImagesId,
                                PromotionPrice = a.PromotionPrice,
                                IsPromote = a.IsPromote,
                                Quantity = a.Quantity
                            };
                return query.AsEnumerable();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Entities.Models.Product InsertOrUpdateProduct(ProductViewModel model)
        {
            try
            {
                if (model.Id > 0)
                {
                    var exist = context.Products.FirstOrDefault(x => x.Id == model.Id);
                    if (exist != null)
                    {
                        PropertyCopy.Copy(model, exist);
                        context.Products.Update(exist);
                        if (context.SaveChanges() > 0) return exist;
                        else
                        {
                            return null;
                        }
                    }
                    else return null;
                }
                else
                {
                    var newData = new Entities.Models.Product();
                    PropertyCopy.Copy(model, newData);
                    context.Products.Add(newData);
                    if (context.SaveChanges() > 0) return newData;
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public bool CheckExistProduct(int id)
        {
            var data = context.Products.AsQueryable().First(x => x.Id == id);
            return data != null;
        }
        public bool CheckExistProductCode(string code)
        {
            var data = context.Products.AsQueryable().FirstOrDefault(x => x.Code == code);
            return data != null;
        }
        public bool InsertOrUpdateProductImages(List<ProductImages> data)
        {
            try
            {
                context.ProductImageses.AddRange(data);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ProductImagesDelete(int id)
        {
            var old = context.ProductImageses.First(x => x.Id == id);
            context.Remove(old);
            return context.SaveChanges() > 0;
        }
        public List<ProductCategoryViewModel> GetListProductCategoryByHomeHot(bool isHome, bool isHot, int count)
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
                            ListProducts = context.Products.Where(x => x.CategoryId == a.Id).ToList()
                        };
            if (isHome)
            {
                query = query.Where(x => x.IsHome == isHome);
            }
            if (isHot)
            {
                query = query.Where(x => x.IsHot == isHot);
            }
            if (count != null && count > 0)
            {
                query = query.Take(count);
            }
            return query.OrderBy(x => x.CategoryOrder).ToList();
        }
        public List<ProductCategoryViewModel> GetListProductCategoryShowOnHome(bool isHome, bool isHot, int count)
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
                            ListProducts = context.Products.Where(x => x.CategoryId == a.Id).ToList()
                        };
            if (isHome)
            {
                query = query.Where(x => x.IsHome == isHome);
            }
            if (count != null && count > 0)
            {
                query = query.Take(count);
            }
            return query.OrderBy(x => x.CategoryOrder).ToList();
        }
        public List<ProductCategoryShowOnHome> GetAllProductCategoryShowOnHome(bool isHome, bool isHot, int countProduct = 5)
        {
            var ProductCategories = context.ProductCategories.AsQueryable();
            var Products = context.Products.AsQueryable();
            var query = from a in ProductCategories
                        where (a.IsHome == isHome && a.IsHot == isHot)
                        orderby a.CategoryOrder
                        select new ProductCategoryShowOnHome
                        {
                            Id = a.Id,
                            CategoryName = a.CategoryName,
                            CategoryOrder = a.CategoryOrder,
                            ListProducts = (from b in Products
                                            where (b.IsHome == true
                                            && b.CategoryId == a.Id
                                            //&& b.IsView == true
                                            //&& b.Status == true
                                            )
                                            orderby b.CreatedDate
                                            select new ProductShowOnHomeModel
                                            {
                                                Id = b.Id,
                                                CategoryId = b.CategoryId,
                                                IsPromote = b.IsPromote,
                                                MainImageThumb = b.MainImageThumb,
                                                Name = b.Name,
                                                Price = b.Price,
                                                PromotionPrice = b.PromotionPrice
                                            }).Take(countProduct).ToList()

                        };
            return query.ToList();
        }
        public ImportProductViewModel GetImportProductByKeyCode(string keyCode)
        {
            try
            {
                var product = context.Products.AsQueryable();
                var obj = (from a in product
                           where a.Code == keyCode
                           select new ImportProductViewModel
                           {
                               ProductID = a.Id,
                               Code = a.Code,
                               Name = a.Name,
                               Quantity = 0,
                           });
                if (obj.Count() == 1) return obj.First();
                else throw new Exception("Mã sản phẩm không tồn tại");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public ImportProductViewModel GetImportProductById(long id)
        //{
        //    try
        //    {
        //        var product = context.Products.AsQueryable();
        //        var obj = (from a in product
        //                   where a.Id == id
        //                   select new ImportProductViewModel
        //                   {
        //                       ProductID = a.Id,
        //                       Code = a.Code,
        //                       Name = a.Name,
        //                       Quantity = 0
        //                   });
        //        if (obj.Count() == 1) return obj.First();
        //        else throw new Exception("Id không tồn tại");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public List<ImportProductViewModel> GetAllImportProduct()
        {
            var product = context.Products.AsQueryable();
            var obj = (from a in product
                       orderby a.Id
                       select new ImportProductViewModel
                       {
                           ProductID = a.Id,
                           Code = a.Code,
                           Name = a.Name,
                           Quantity = 0
                       }).ToList();
            return obj;
        }
        public bool ImportProduct(int id, int quantity)
        {
            try
            {
                if (quantity <= 0) return false;
                var obj = context.Products.Find(id);
                obj.Quantity += quantity;
                return context.SaveChanges() == 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool CheckQuantityProductOrder(int id, int order)
        {
            var product = context.Products.Find(id);
            return product.Quantity >= order;
        }

        public List<ProductCategory> GetRelatedCate(int id)
        {
            var cate = context.ProductCategories.FirstOrDefault(c => c.Id == id);
            var res = context.ProductCategories.Where(c => (c.ParentId == id || (c.ParentId == cate.ParentId && cate.ParentId != 0)) && c.Id != id).ToList();
            return res;
        }
    }

}
