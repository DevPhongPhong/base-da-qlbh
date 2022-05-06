using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Export
{
    public class ExportService : IExportService
    {
        private readonly CMS_DBContext context;
        public ExportService(CMS_DBContext _context)
        {
            context = _context;
        }
        public IEnumerable<ExportViewModel> GetExportViewModels()
        {
            try
            {
                var list = context.Exports.Join(context.Orders,
                export => export.OrderID,
                order => order.Id,
                (export, order) => new ExportViewModel
                {
                    CreateDate = order.CreatedDate,
                    ExportDate = export.ExportedDate,
                    ExportID = export.ID,
                    OrderID = export.OrderID,
                    CustomerAddress = order.CustomerAddress,
                    CustomerEmail = order.CustomerEmail,
                    CustomerFullName = order.CustomerFullName,
                    CustomerNote = order.CustomerNote,
                    CustomerPhone = order.CustomerPhone,
                    OrderCode = order.OrderCode,
                    TotalPrice = order.TotalPrice,
                    ListProduct = context.OrderDetailses.Where(x => x.OrderId == export.OrderID).Join(context.Products,
                    o => o.ProductId,
                    p => p.Id,
                    (o, p) => new ProductOrder
                    {
                        ProductId = p.Id,
                        Code = p.Code,
                        ProductImage = p.MainImageLarge,
                        ProductName = p.Name,
                        ProductPrice = o.ProductPrice,
                        Quantity = o.Quantity
                    }).ToList()
                });
                return list.OrderBy(x => x.ExportDate);
            }
            catch (Exception ex)
            {

                throw ex;
            }   
        }
    }
}
