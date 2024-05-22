using Entities.Common;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services.Kaafly
{
    public class KaaflyService : IKaaflyService
    {
        private CMS_DBContext context;
        public KaaflyService(CMS_DBContext _context)
        {
            context = _context;
        }
        public PaginationModel<List<ProductViewModel>> GetListProductByCategoryId(RequestHomeViewModel request)
        {
            try
            {
                if (!request.Offset.HasValue)
                {
                    request.Offset = 0;
                }
                if (request.Offset > 0)
                {
                    request.Offset -= 1;
                }

                if (!request.Size.HasValue)
                {
                    request.Size = 9;
                }

                PaginationModel<List<ProductViewModel>> res = new PaginationModel<List<ProductViewModel>>();

                res.Pagination.Offset = request.Offset.Value;
                res.Pagination.Size = request.Size.Value;

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
                                currentCategoryId = request.categoryId
                            };
                var childCateIds = context.ProductCategories.Where(pc => pc.ParentId == request.categoryId).Select(x => x.Id).ToList();
                if (request.categoryId > 0)
                {
                    query = query.Where(x => x.CategoryId == request.categoryId || childCateIds.Contains(x.CategoryId.HasValue ? x.CategoryId.Value : 0));
                }

                var count = query.Count();
                var data = query.OrderByDescending(x => x.CreatedDate).Skip((int)request.Offset * (int)request.Size).Take((int)request.Size).ToList();
                res.Pagination.Total = count;
                res.Data = data;

                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ProductCategory GetCategoryById(int id)
        {
            return context.ProductCategories.FirstOrDefault(x => x.Id == id);
        }
        public ProductViewModel GetProductById(int id)
        {
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
            return query.FirstOrDefault(x => x.Id == id);
        }
        public List<ProductViewModel> GetListProductByHomeHot(bool isHome, bool isHot, int count)
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
                            };
                var newQuery = query.OrderBy(elem => Guid.NewGuid()).AsQueryable();
                if (isHome)
                {
                    newQuery = newQuery.Where(x => x.IsHome);
                }
                if (isHot)
                {
                    newQuery = newQuery.Where(x => x.IsHot);
                }
                if (count != null && count > 0)
                {
                    newQuery = newQuery.Take(count);
                }
                return newQuery.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public OrderResponseViewModel OrderRequest(OrderRequestViewModel model)
        {
            var strategy = context.Database.CreateExecutionStrategy();
            return strategy.Execute(() =>
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var order = new Entities.Models.Order();
                        order.CreatedDate = DateTime.Now;
                        order.CustomerAddress = model.CustomerAddress;
                        order.CustomerFullName = model.CustomerFullName;
                        order.CustomerPhone = model.CustomerPhone;
                        order.CustomerEmail = model.CustomerEmail;
                        order.CustomerNote = model.CustomerNote;
                        order.OrderStatusId = 1; // Chờ xác nhận
                        order.TotalPrice = model.TotalPrice;
                        context.Orders.Add(order);
                        var check = context.SaveChanges() > 0;
                        if (!check)
                        {
                            dbContextTransaction.Rollback();
                            return null;
                        }
                        order.OrderCode = "Order0000" + order.Id;
                        context.Orders.Update(order);
                        foreach (var item in model.ProductsOrder)
                        {
                            var detail = new OrderDetails();
                            context.Products.Find(item.ProductId).Quantity -= item.Quantity;
                            context.SaveChanges();
                            detail.OrderId = order.Id;
                            detail.ProductId = item.ProductId;
                            detail.Quantity = item.Quantity;
                            detail.ProductPrice = item.ProductPrice;
                            context.OrderDetailses.Add(detail);
                        }
                        check = context.SaveChanges() > 0;
                        if (!check)
                        {
                            dbContextTransaction.Rollback();
                            return null;
                        }
                        else
                        {
                            var response = new OrderResponseViewModel();
                            response.OrderCode = order.OrderCode;
                            response.CustomerAddress = order.CustomerAddress;
                            response.CustomerEmail = order.CustomerEmail;
                            response.CustomerFullName = order.CustomerFullName;
                            response.CustomerNote = order.CustomerNote;
                            response.CustomerPhone = order.CustomerPhone;
                            response.TotalPrice = order.TotalPrice;
                            response.ProductsOrder = new List<ProductOrder>();
                            response.ProductsOrder.AddRange(model.ProductsOrder);
                            dbContextTransaction.Commit();
                            return response;
                        }
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        throw;
                    }
                }
            });
        }
        public TrackingOrderReceivedModel GetOrderReceivedByOrderCode(string orderCode)
        {
            try
            {
                var result = new TrackingOrderReceivedModel();
                var o = context.Orders.FirstOrDefault(x => x.OrderCode.ToUpper() == orderCode.ToUpper());

                if (o == null) throw new Exception("Không tìm thấy mã đơn hàng!");

                result.TotalPrice = o.TotalPrice;
                result.OrderCode = orderCode;
                result.CustomerFullName = o.CustomerFullName;
                result.CustomerEmail = o.CustomerEmail;
                result.CreatedDate = o.CreatedDate;
                result.CustomerAddress = o.CustomerAddress;
                result.CustomerPhone = o.CustomerPhone;
                result.OrderStatusId = o.OrderStatusId;

                var listOrderDetail = context.OrderDetailses.Where(x => x.OrderId == o.Id).ToList();
                var listProductOrder = new List<ProductOrder>();

                if (listOrderDetail == null || listOrderDetail.Count <= 0 || listOrderDetail[0] == null) throw new Exception("Đơn hàng không có sản phẩm!");

                foreach (var item in listOrderDetail)
                {
                    var productOrder = new ProductOrder();
                    var product = context.Products.FirstOrDefault(x => x.Id == item.ProductId);

                    productOrder.ProductId = item.ProductId;
                    productOrder.ProductPrice = item.ProductPrice;
                    productOrder.Quantity = item.Quantity;
                    productOrder.ProductImage = (product == null ? "<Sản phẩm không còn tồn tại>" : product.MainImageLarge);
                    productOrder.ProductName = (product == null ? "<Sản phẩm không còn tồn tại>" : product.Name);
                    listProductOrder.Add(productOrder);
                }

                result.ListProductOrder = listProductOrder;
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public List<OrderReceivedViewModel> ListOrderReceivedOfMemberByEmail(string email)
        {
            try
            {
                var result = new List<OrderReceivedViewModel>();
                var os = context.Orders.Where(x => x.CustomerEmail == email).ToList();
                if (os != null && os.Count > 0 && os[0] != null)
                {
                    foreach (var item in os)
                    {
                        var orderView = new OrderReceivedViewModel()
                        {
                            CreatedDate = item.CreatedDate,
                            CustomerFullName = item.CustomerFullName,
                            OrderCode = item.OrderCode,
                            OrderStatusId = item.OrderStatusId,
                            TotalPrice = item.TotalPrice
                        };
                        result.Add(orderView);
                    }
                    return result;
                }
                else throw new Exception("Email chưa từng mua hàng!");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public PaginationModel<List<ProductViewModel>> GetListProductBySearchKeyWord(RequestSearchModel request)
        {
            try
            {
                if (!request.Offset.HasValue)
                {
                    request.Offset = 0;
                }
                if (request.Offset > 0)
                {
                    request.Offset -= 1;
                }

                if (!request.Size.HasValue)
                {
                    request.Size = 9;
                }

                PaginationModel<List<ProductViewModel>> res = new PaginationModel<List<ProductViewModel>>();

                res.Pagination.Offset = request.Offset.Value;
                res.Pagination.Size = request.Size.Value;

                var query = from a in context.Products
                            where a.Name.Contains(request.KeyWord) || a.Code.Contains(request.KeyWord)
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
                                currentCategoryId = a.CategoryId
                            };
                IQueryable<ProductViewModel> data;
                if (request.Order == "date")
                {
                    data = query.OrderBy(x => x.ModifiedDate);
                }
                else if (request.Order == "date_desc")
                {
                    data = query.OrderByDescending(x => x.CreatedDate);
                }
                else if (request.Order == "price")
                {
                    data = query.OrderBy(x => x.Price);
                }
                else if (request.Order == "price_desc")
                {
                    data = query.OrderByDescending(x => x.Price);
                }
                else if (request.Order == "abc")
                {
                    data = query.OrderBy(x => x.Name);
                }
                else if (request.Order == "abc_desc")
                {
                    data = query.OrderByDescending(x => x.Name);
                }
                else if (request.Order == "best_sell")
                {
                    data = query.OrderBy(x => x.IsPromote && x.IsHot);
                }
                else
                {
                    data = query.OrderBy(x => x.Id);
                }
                var count = query.Count();
                var dataRes = data.Skip((int)request.Offset * (int)request.Size).Take((int)request.Size).ToList();
                res.Pagination.Total = count;
                res.Data = dataRes;

                return res;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public TrackingOrderReceivedModel GetOrderReceivedByOrderCodeAndEmail(string orderCode, string email)
        {
            try
            {
                var result = new TrackingOrderReceivedModel();
                var o = context.Orders.FirstOrDefault(x => x.OrderCode.ToUpper() == orderCode.ToUpper() && x.CustomerEmail == email);

                if (o == null) throw new Exception("Sai mã đơn hàng hoặc email!");

                result.TotalPrice = o.TotalPrice;
                result.OrderCode = orderCode;
                result.CustomerFullName = o.CustomerFullName;
                result.CustomerEmail = o.CustomerEmail;
                result.CreatedDate = o.CreatedDate;
                result.CustomerAddress = o.CustomerAddress;
                result.CustomerPhone = o.CustomerPhone;
                result.OrderStatusId = o.OrderStatusId;

                var listOrderDetail = context.OrderDetailses.Where(x => x.OrderId == o.Id).ToList();
                var listProductOrder = new List<ProductOrder>();

                if (listOrderDetail == null || listOrderDetail.Count <= 0 || listOrderDetail[0] == null) throw new Exception("Đơn hàng không có sản phẩm!");

                foreach (var item in listOrderDetail)
                {
                    var productOrder = new ProductOrder();
                    var product = context.Products.FirstOrDefault(x => x.Id == item.ProductId);

                    productOrder.ProductId = item.ProductId;
                    productOrder.ProductPrice = item.ProductPrice;
                    productOrder.Quantity = item.Quantity;
                    productOrder.ProductImage = (product == null ? "<Sản phẩm không còn tồn tại>" : product.MainImageLarge);
                    productOrder.ProductName = (product == null ? "<Sản phẩm không còn tồn tại>" : product.Name);
                    listProductOrder.Add(productOrder);
                }

                result.ListProductOrder = listProductOrder;
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
