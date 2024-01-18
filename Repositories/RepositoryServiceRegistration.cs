using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Context;
using Repositories.IRepositories;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class RepositoryServiceRegistration
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<SqlConnection, SqlConnection>(p =>
               new SqlConnection(configuration.GetConnectionString("ConnectionStrings")));
            services.AddScoped<IBlogsRepository, BlogsRepository>();
            services.AddScoped<IDocumentsRepository, DocumentsRepository>();
            services.AddScoped<ITagsRepository, TagsRepository>();
            services.AddScoped<ICommentsRepository, CommentsRepository>();
            services.AddScoped<IBlogFragmentsRepository, BlogFragmentsRepository>();
            services.AddScoped<ICommentLikesRepository, CommentLikesRepository>();
            services.AddScoped<IBlogLikesRepository, BlogLikesRepository>();

            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("UserDatabase"));
            });

            return services;
        }
    }
}
