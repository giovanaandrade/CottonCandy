
using CottonCandy.Application;
using CottonCandy.Application.AppPostagem;
using CottonCandy.Application.AppPostagem.Interfaces;
using CottonCandy.Application.AppUser.Interfaces;
using CottonCandy.Application.AppUsuario;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CottonCandy.Repositories.IoC.Application
{
   internal class ApplicationBootstraper
    {
        internal void ChildServiceRegister(IServiceCollection services)
        {
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<IPostagemAppService, PostagemAppService>();
            services.AddScoped<ICurtidasAppService, CurtidasAppService>();
        }
    }
}
