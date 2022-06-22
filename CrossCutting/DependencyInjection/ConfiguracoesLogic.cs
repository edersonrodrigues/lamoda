using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using Rgm.Domain.Entities.Interfaces;
using Rgm.Domain.Service;

namespace Rgm.DataAcessLayer.CrosCutting
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IToken, TokenService>();
            serviceCollection.AddTransient<IAluno, AlunoService>();
        }
    }
}


