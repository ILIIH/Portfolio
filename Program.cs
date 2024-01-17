using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyCourses
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<RazorPagesProfile>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PortfolioContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found."))
                .EnableDetailedErrors()
                );

           
     
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var coursesDAO = new CoursesDAO(services);
                var courses = coursesDAO.getAllCourses();
      
            }


            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

  

            app.UseHttpsRedirection();
            app.UseStaticFiles();

        
            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();

        }
    }
}