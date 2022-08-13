using CRUD_Code_Test.Application.Interfaces;
using CRUD_Code_Test.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //var connectionString = "Data Source=.;Initial Catalog=CRUD_Code_Test; Integrated Security=SSPI; MultipleActiveResultSets=true";
            //services.AddEntityFrameworkSqlServer().AddDbContext<CustomerContext>(option => option.UseSqlServer(connectionString));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            var connectionString = Configuration.GetConnectionString("DbConnection");
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<CustomerContext>(
                    opts => opts.UseNpgsql(connectionString)
                );
            services.AddScoped<ICustomerContext>(provider => provider.GetService<CustomerContext>());
            services.AddControllers();
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}
