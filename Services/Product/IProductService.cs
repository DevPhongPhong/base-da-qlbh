using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Product
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProducts();
        ProductViewModel GetProduct(int id);
        Entities.Models.Product InsertOrUpdateProduct(ProductViewModel model);
        bool DeleteProduct(int id);
        List<ProductImages> GetAllProductImages(int productid);
        bool CheckExistProduct(int id);
        bool InsertOrUpdateProductImages(List<ProductImages> data);
        bool ProductImagesDelete(int id);
        bool CheckExistProductCode(string code);
        bool CheckQuantityProductOrder(int id, int order);
        List<ProductCategoryViewModel> GetListProductCategoryByHomeHot(bool isHome, bool isHot, int count);
        List<ProductCategoryViewModel> GetListProductCategoryShowOnHome(bool isHome, bool isHot, int count);
        List<ProductCategoryShowOnHome> GetAllProductCategoryShowOnHome(bool isHome, bool isHot, int countProduct = 5);
        ImportProductViewModel GetImportProductByKeyCode(string keyCode);
        //ImportProductViewModel GetImportProductById(long id);
        List<ImportProductViewModel> GetAllImportProduct();
        bool ImportProduct(int id, int quantity);
        List<ProductCategory> GetRelatedCate(int id);
    }
}
