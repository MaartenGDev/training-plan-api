using Core.Schema;
using Core.Schema.Data;
using Core.Services;
using DataContext.Data;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prometheus;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TrainingPlanContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IDependencyResolver>(
                c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
            
            // Services
            services.AddTransient<WorkoutService>();
            services.AddTransient<WorkshopService>();
            services.AddTransient<UserService>();
            services.AddTransient<ExerciseService>();
            services.AddTransient<TrainingScheduleService>();
            services.AddTransient<JourneyService>();
            
            // Types
            services.AddTransient<UserType>();
            services.AddTransient<ExerciseCategoryType>();
            services.AddTransient<ExerciseType>();
            services.AddTransient<TrainingScheduleExerciseType>();
            services.AddTransient<TrainingScheduleType>();
            services.AddTransient<WorkoutExerciseType>();
            services.AddTransient<WorkshopType>();
            services.AddTransient<JourneyType>();
            services.AddTransient<WorkoutType>();
            services.AddTransient<ExerciseIdWithSetsType>();
            services.AddTransient<ExerciseIdWithSetsAndDateType>();

            // Input types
            services.AddTransient<ExerciseCreateInputType>();
            services.AddTransient<TrainingScheduleCreateInputType>();
            services.AddTransient<WorkoutCreateInputType>();

            
            // Schema setup
            services.AddTransient<SchemaQuery>();
            services.AddTransient<SchemaMutation>();
            
            services.AddTransient<TrainingPlanSchema>();
     

            services.AddGraphQL(options =>    
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = true;
                })
                .AddWebSockets()
                .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMetricServer();
            app.UseHttpMetrics();

            app.UseExceptionHandler();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseGraphQLWebSockets<TrainingPlanSchema>();
            app.UseGraphQL<TrainingPlanSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground"
            });
            app.UseGraphiQLServer(new GraphiQLOptions
            {
                GraphiQLPath = "/ui/graphiql",
                GraphQLEndPoint = "/graphql"
            });
            app.UseGraphQLVoyager(new GraphQLVoyagerOptions
            {
                GraphQLEndPoint = "/graphql",
                Path = "/ui/voyager"
            });
        }
    }
}