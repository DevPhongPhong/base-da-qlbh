using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Order
{
    public interface IOrderService
    {
        List<OrderViewModel> GetOrders(int? statusId);
        OrderAdminViewModel GetDetailsOrderByOrderId(int id);
        DataBaoCaoNam GetDataBaoCaoNam(int nam);
        bool ChangeStatus(int id, int status);
        DataBaoCao GetDataBaoCaoNgay(DateTime ngay);
        DataBaoCao GetDataBaoCaoThang(DateTime ngay);
    }
}
