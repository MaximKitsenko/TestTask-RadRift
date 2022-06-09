using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RadRiftGame.Contracts.Commands;
using RadRiftGame.Contracts.Events;
using RadRiftGame.Domain;
using RadRiftGame.Domain.Aggregates;
using RadRiftGame.Domain.Projections;
using RadRiftGame.Infrastructure;

namespace RadRiftGame
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
            var bus = new FakeBus();
            var storage = new EventStore(bus);
            var rep = new Repository<GameRoom>(storage);
            var commands = new GameRoomCommandHandlers(rep);
            
            // Commands
            bus.RegisterHandler<CreateGameRoom>(commands.Handle);
            bus.RegisterHandler<JoinGameRoom>(commands.Handle);
            
            // Projections
            var eventsCountDetailedByOneMinuteProjection = new GameRoomsWithTwoPlayersProjection();
            bus.RegisterHandler<UserJoinedGameRoom>(eventsCountDetailedByOneMinuteProjection.Handle);
            
            // Dependencies
            services.AddSingleton<FakeBus>(bus);
            services.AddSingleton<IReadModelFacade>(new ReadModelFacade());
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}