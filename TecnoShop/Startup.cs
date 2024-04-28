using Microsoft.AspNetCore.Builder;

namespace TecnoShop
{
    public class Startup
    {


        // ...

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSession(); // Session kullanımını etkinleştirin
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ...

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession(); // Session'ı kullanmak için ekleyin

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
