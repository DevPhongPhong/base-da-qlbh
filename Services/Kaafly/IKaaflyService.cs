using Entities.Common;
using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Kaafly
{
    public interface IKaaflyService
    {
        PaginationModel<List<ProductViewModel>> GetListProductByCategoryId(RequestHomeViewModel request);
        ProductCategory GetCategoryById(int id);
        ProductViewModel GetProductViewModelById(int id);
        List<ProductViewModel> GetListProductByHomeHot(bool isHome, bool isHot, int count);
        OrderResponseViewModel OrderRequest(OrderRequestViewModel model);
        TrackingOrderReceivedModel GetOrderReceivedByOrderCode(string orderCode);
        TrackingOrderReceivedModel GetOrderReceivedByOrderCodeAndEmail(string orderCode,string emailOrPhone);
        List<OrderReceivedViewModel> ListOrderReceivedOfMemberByEmailPhone(string Email, string Phone);
        List<OrderReceivedViewModel> ListOrderReceivedOfMemberByAccountId(Guid id);
        PaginationModel<List<ProductViewModel>> GetListProductBySearchKeyWord(RequestSearchModel request);
        Entities.Models.Product GetProductById(int id);
    }
}
