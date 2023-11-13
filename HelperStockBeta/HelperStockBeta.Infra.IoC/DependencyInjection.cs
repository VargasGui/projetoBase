﻿using HelperStockBeta.Domain.Entities;
using HelperStockBeta.Domain.Interface;
using HelperStockBeta.Infra.Data.Context;
using HelperStockBeta.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperStockBeta.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection services,
            IConfiguration configuration )
        {
            services.AddDbContext<ApplicationDbContext>
                (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
