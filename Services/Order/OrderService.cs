using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly CMS_DBContext context;
        public OrderService(CMS_DBContext _context)
        {
            context = _context;
        }
        public List<OrderViewModel> GetOrders(int? statusId)
        {
            var query = from a in context.Orders.AsQueryable()

                        select new OrderViewModel
                        {
                            CreatedDate = a.CreatedDate,
                            CustomerAddress = a.CustomerAddress,
                            CustomerFullName = a.CustomerFullName,
                            CustomerPhone = a.CustomerPhone,
                            Id = a.Id,
                            OrderCode = a.OrderCode,
                            OrderStatusId = a.OrderStatusId,
                            TotalPrice = a.TotalPrice,
                            OrderStatusName = context.OrderStatus.FirstOrDefault(x => x.Id == a.OrderStatusId).Name,
                            ListOrderDetails = context.OrderDetailses.Where(x => x.OrderId == a.Id).ToList()
                        };
            if (statusId != null && statusId != 0)
            {
                query = query.Where(x => x.OrderStatusId == statusId);
            }
            return query.OrderByDescending(x => x.CreatedDate).ToList();
        }
        public bool ChangeStatus(int id, int status)
        {
            try
            {
                var order = context.Orders.FirstOrDefault(x => x.Id == id);

                if (order == null) return false;
                else
                {
                    if (status == -1 || status == -2)
                    {
                        var list = context.OrderDetailses.Where(x => x.OrderId == order.Id).ToList();
                        foreach (var item in list)
                        {
                            context.Products.Find(item.ProductId).Quantity += item.Quantity;
                        }
                    }
                    else if (status == 3)
                    {
                        var exportModel = new Entities.Models.Export
                        {
                            ID = 0,
                            ExportedDate = DateTime.Now,
                            OrderID = id
                        };
                        context.Exports.Add(exportModel);
                    }
                    order.OrderStatusId = status;
                    context.Orders.Update(order);
                    return context.SaveChanges() > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public OrderAdminViewModel GetDetailsOrderByOrderId(int id)
        {
            var query = from a in context.Orders.AsQueryable()

                        select new OrderAdminViewModel
                        {
                            CreatedDate = a.CreatedDate,
                            CustomerAddress = a.CustomerAddress,
                            CustomerFullName = a.CustomerFullName,
                            CustomerPhone = a.CustomerPhone,
                            CustomerEmail = a.CustomerEmail,
                            CustomerNote = a.CustomerNote,
                            Id = a.Id,
                            OrderCode = a.OrderCode,
                            OrderStatusId = a.OrderStatusId,
                            TotalPrice = a.TotalPrice,
                            OrderStatusName = context.OrderStatus.FirstOrDefault(x => x.Id == a.OrderStatusId).Name,
                            ListOrderDetails = (from b in context.OrderDetailses.AsQueryable()
                                                where b.OrderId == a.Id
                                                select new OrderDetailsViewModel
                                                {
                                                    Id = b.Id,
                                                    OrderId = b.OrderId,
                                                    ProductId = b.ProductId,
                                                    ProductName = context.Products.FirstOrDefault(x => x.Id == b.ProductId).Name,
                                                    ProductPrice = b.ProductPrice,
                                                    Quantity = b.Quantity
                                                }).ToList()
                        };
            return query.FirstOrDefault(x => x.Id == id);
        }

        public DataBaoCaoNam GetDataBaoCaoNam(int nam)
        {
            try
            {
                var data = new DataBaoCaoNam();
                int thang = 0;

                thang = 1;
                data.Thang1 = new DataAllTheoThang();
                data.Thang1.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang1.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang1.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang1.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang1.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                thang = 2;
                data.Thang2 = new DataAllTheoThang();
                data.Thang2.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang2.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang2.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang2.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang2.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                thang = 3;
                data.Thang3 = new DataAllTheoThang();
                data.Thang3.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang3.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang3.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang3.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang3.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                thang = 4;
                data.Thang4 = new DataAllTheoThang();
                data.Thang4.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang4.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang4.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang4.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang4.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                thang = 5;
                data.Thang5 = new DataAllTheoThang();
                data.Thang5.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang5.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang5.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang5.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang5.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                thang = 6;
                data.Thang6 = new DataAllTheoThang();
                data.Thang6.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang6.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang6.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang6.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang6.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                thang = 7;
                data.Thang7 = new DataAllTheoThang();
                data.Thang7.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang7.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang7.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang7.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang7.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                thang = 8;
                data.Thang8 = new DataAllTheoThang();
                data.Thang8.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang8.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang8.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang8.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang8.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                thang = 9;
                data.Thang9 = new DataAllTheoThang();
                data.Thang9.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang9.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang9.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang9.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang9.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                thang = 10;
                data.Thang10 = new DataAllTheoThang();
                data.Thang10.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang10.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang10.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang10.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang10.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                thang = 11;
                data.Thang11 = new DataAllTheoThang();
                data.Thang11.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang11.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang11.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang11.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang11.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                thang = 12;
                data.Thang12 = new DataAllTheoThang();
                data.Thang12.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Sum(x => x.TotalPrice);
                data.Thang12.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang12.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang12.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();
                data.Thang12.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == nam && x.CreatedDate.Value.Month == thang).Count();

                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataBaoCao GetDataBaoCaoNgay(DateTime ngay)
        {
            try
            {
                var data = new DataBaoCao();
                data.DoanhThu = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == ngay.Year && x.CreatedDate.Value.Month == ngay.Month && x.CreatedDate.Value.Day == ngay.Day).Sum(x => x.TotalPrice);
                data.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == ngay.Year && x.CreatedDate.Value.Month == ngay.Month && x.CreatedDate.Value.Day == ngay.Day).Count();
                data.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == ngay.Year && x.CreatedDate.Value.Month == ngay.Month && x.CreatedDate.Value.Day == ngay.Day).Count();
                data.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == ngay.Year && x.CreatedDate.Value.Month == ngay.Month && x.CreatedDate.Value.Day == ngay.Day).Count();
                data.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == ngay.Year && x.CreatedDate.Value.Month == ngay.Month && x.CreatedDate.Value.Day == ngay.Day).Count();

                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DataBaoCao GetDataBaoCaoThang(DateTime ngay)
        {
            try
            {
                var data = new DataBaoCao();
                var DoanhThuCurrent = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == ngay.Year && x.CreatedDate.Value.Month == ngay.Month).Sum(x => x.TotalPrice);
                data.DoanhThu = DoanhThuCurrent;
                data.DonHangMoi = context.Orders.Where(x => (x.OrderStatusId == 1 || x.OrderStatusId == 2 || x.OrderStatusId == 3) && x.CreatedDate.Value.Year == ngay.Year && x.CreatedDate.Value.Month == ngay.Month).Count();
                data.DonHangThanhCong = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == ngay.Year && x.CreatedDate.Value.Month == ngay.Month).Count();
                data.DonHangHuy = context.Orders.Where(x => x.OrderStatusId == -1 && x.CreatedDate.Value.Year == ngay.Year && x.CreatedDate.Value.Month == ngay.Month).Count();
                data.DonHangThatBai = context.Orders.Where(x => x.OrderStatusId == -2 && x.CreatedDate.Value.Year == ngay.Year && x.CreatedDate.Value.Month == ngay.Month).Count();
                if (ngay.Month == 1)
                {
                    data.TangTruong = 0;
                }
                else
                {
                    var DoanhThuPrev = context.Orders.Where(x => x.OrderStatusId == 4 && x.CreatedDate.Value.Year == ngay.Year && x.CreatedDate.Value.Month == (ngay.Month - 1)).Sum(x => x.TotalPrice);
                    if (DoanhThuPrev == 0)
                    {
                        data.DoanhThuPrev = 0;
                        data.TangTruong = 100;
                    }
                    else
                    {
                        data.DoanhThuPrev = DoanhThuPrev;
                        data.TangTruong = (int)(((DoanhThuCurrent - DoanhThuPrev) / DoanhThuPrev) * 100);
                    }

                }
                return data;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataBanChayBanCham GetDataThongKeBanChayBanCham(int nam)
        {
            try
            {
                if (nam < DateTime.Now.Year && context.ProductStatisticals.Any(x => x.Year == nam))
                {
                    var data = new DataBanChayBanCham();

                    var products = context.ProductStatisticals
                        .Where(x => x.Year == nam)
                        .OrderByDescending(x => x.TotalQuantity)
                        .ThenBy(x => x.ProductName)
                        .ToList();

                    data.ProductName = products.Select(x => x.ProductName).ToList();
                    data.TotalQuantity = products.Select(x => x.TotalQuantity).ToList();

                    return data;
                }
                else
                {
                    var data = new DataBanChayBanCham();

                    var orders = context.Orders
                        .Where(x => x.OrderStatusId == 4 &&
                                    x.CreatedDate.Value.Year == nam)
                        .Select(x => x.Id);

                    var orderDetails = context.OrderDetailses
                        .Where(x => orders.Contains(x.OrderId))
                        .ToList();

                    var products = context.Products
                        .Where(x => orderDetails.Select(od => od.ProductId).Contains(x.Id))
                        .ToList();

                    var combinedData = orderDetails
                        .Join(products,
                              od => od.ProductId,
                              p => p.Id,
                              (od, p) => new { ProductName = p.Name, TotalQuantity = od.Quantity })
                        .OrderByDescending(x => x.TotalQuantity)
                        .ThenBy(x => x.ProductName)
                        .ToList();

                    data.ProductName = combinedData.Select(x => x.ProductName).ToList();
                    data.TotalQuantity = combinedData.Select(x => x.TotalQuantity).ToList();
                    foreach (var item in combinedData)
                    {
                        context.ProductStatisticals.Add(new ProductStatistical
                        {
                            Year = nam,
                            ProductName = item.ProductName,
                            TotalQuantity = item.TotalQuantity
                        });
                    }

                    // Save the changes to the database
                    context.SaveChanges();
                    return data;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

