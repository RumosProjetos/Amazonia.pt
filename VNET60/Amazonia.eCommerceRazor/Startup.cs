using Amazonia.eCommerceRazor.Models;
using Amazonia.eCommerceRazor.Services.Logging;
using Amazonia.eCommerceRazor.Services.PDFGenerator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Amazonia.eCommerceRazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMiniProfiler().AddEntityFramework();

            //Exemplo SQLite
            //services.AddDbContext<ECommerceDbContext>(options => options.UseSqlite("Data Source=person.db"));

            var connectionString = Configuration.GetConnectionString("MinhaConexao");
            services.AddDbContext<ECommerceDbContext>(options => options.UseSqlServer(connectionString));




            services.AddControllersWithViews();
            services.AddLogging();

            services.AddSingleton<IGerador, GeradorCustomizado>();
            services.AddSingleton<IHistorico, HistoricoCustomizado>();
            //services.AddSingleton<IHistorico, HistoricoJson>();
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHistorico logger, ECommerceDbContext dbContext)
        {
            //logger.Guardar("Oi mundo - Hora que a App iniciou");

            ////app.Use não é Short Circuit, a execução continua com o next.Invoke
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync($"{Environment.NewLine} Hello World - App.Use");
            //    await next.Invoke();
            //});



            //app.Map("/AreaReservada", (map) =>
            //{
            //    map.Run(async (context) => {
            //        await context.Response.WriteAsync($"{Environment.NewLine} Hello World - App.Map - Area Reservada");
            //        //context.Response.Redirect("https://localhost:44306/index.html");
            //    });
            //});

            //app.Map("/AreaPublica", (map) =>
            //{
            //    map.Run(async (context) => {
            //        await context.Response.WriteAsync($"{Environment.NewLine} Hello World - App.Map - Area Pública");
            //    });
            //});

            ////Cuidado, é um método Short Circuit. Pára a execução do resto da configuração
            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync($"{Environment.NewLine}Hello World - App.Run");
            //    await context.Response.WriteAsync($"{Environment.NewLine}End World  - App.Run");                
            //    await context.Response.WriteAsync($"{Environment.NewLine}End World  - App.Run");
            //});


            app.UseDeveloperExceptionPage();

            if (env.IsDevelopment())
            {
                //dbContext.Database.EnsureDeleted(); //Cuidado: Vai apagar tudo, nunca usar em PRODução.
                dbContext.Database.EnsureCreated();

                app.UseMiniProfiler();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();






            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");



                //Cuidado - Como o Controller definiu antes a regra, só chega aqui caso o controller nAo resolva
                endpoints.MapControllerRoute(
                    name: "apagar",
                    pattern: "apagar/{id?}",
                    defaults: new { controller = "Livro", action = "Edit" });
            });


        }
    }
}
