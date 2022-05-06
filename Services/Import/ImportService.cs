using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ultilities;

namespace Services.Import
{
    public class ImportService : IImportService
    {
        private readonly CMS_DBContext context;
        public ImportService(CMS_DBContext _context)
        {
            context = _context;
        }
        public bool AddImport(ImportViewModel model)
        {
            try
            {
                var import = new Entities.Models.Import
                {
                    ID = 0,
                    ImportedDate = model.CreatedDate.GetValueOrDefault(DateTime.Now),
                    Nane = model.Name,
                    Note = model.Note,
                    TotalPrice = model.TotalPrice.GetValueOrDefault()
                };
                context.Imports.Add(import);
                context.SaveChanges();
                foreach (var item in model.ListImportProductViewModel)
                {
                    var importDetail = new Entities.Models.ImportDetail
                    {
                        ImportID = import.ID,
                        Price = item.Price,
                        ProductID = item.ProductID,
                        Quantity = item.Quantity
                    };
                    context.ImportDetails.Add(importDetail);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<ImportViewModel> GetImportViewModels()
        {
            try
            {
                var result = new List<ImportViewModel>();
                var listImport = context.Imports.ToList();
                foreach (var i in listImport)
                {
                    var listImportProductViewModel = context.ImportDetails.Join(context.Products,
                        importDetail => importDetail.ProductID,
                        product => product.Id,
                        (importDetail, product) => new ImportProductViewModel
                        {
                            ImportID = importDetail.ImportID,
                            Price = importDetail.Price,
                            Quantity = importDetail.Quantity,
                            Code = product.Code,
                            Name = product.Name,
                            ProductID = product.Id
                        }).Where(x => x.ImportID == i.ID).ToList();
                    var totalQuantity = 0;
                    foreach (var item in listImportProductViewModel) totalQuantity += item.Quantity;
                    var model = new ImportViewModel
                    {
                        ID = i.ID,
                        Name = i.Nane,
                        CreatedDate = i.ImportedDate,
                        Note = i.Note,
                        TotalPrice = i.TotalPrice,
                        CountProduct = listImportProductViewModel.Count,
                        TotalQuantity = totalQuantity,
                        ListImportProductViewModel = listImportProductViewModel
                    };
                    result.Add(model);
                }
                result.OrderByDescending(x => x.CreatedDate);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
