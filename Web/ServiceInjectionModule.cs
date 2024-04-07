using Microsoft.Extensions.DependencyInjection;
using Services.Common;
using Services.Export;
using Services.FromCustomer;
using Services.Import;
using Services.Kaafly;
using Services.Login;
using Services.News;
using Services.Order;
using Services.Product;
using Services.StaticData;

namespace Web
{
    public static class ServiceInjectionModule
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IKaaflyService, KaaflyService>();
            services.AddScoped<IImportService, ImportService>();
            services.AddScoped<IExportService, ExportService>();
            services.AddScoped<IFromCustomerService, FromCustomerService>();
            services.AddScoped<IStaticDataService, StaticDataService>();

            return services;
        }
    }
}
