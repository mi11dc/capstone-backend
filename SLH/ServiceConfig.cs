using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SLH.Service.Interface;
using SLH.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace SLH
{
    public class ServiceConfig
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISportService, SportService>();
            services.AddTransient<IVenueService, VenueService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ITournamentService, TournamentService>();
            services.AddTransient<IMatchService, MatchService>();
        }
    }
}
