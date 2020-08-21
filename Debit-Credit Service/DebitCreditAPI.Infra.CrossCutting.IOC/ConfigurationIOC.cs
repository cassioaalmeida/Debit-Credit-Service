using Autofac;
using DebitCreditAPI.Application.Interfaces;
using DebitCreditAPI.Application.Service;
using DebitCreditAPI.Domain.Core.Interfaces.Repositories;
using DebitCreditAPI.Domain.Core.Interfaces.Services;
using DebitCreditAPI.Domain.Services.Services;
using DebitCreditAPI.Infra.CrossCutting.Adapter.Interfaces;
using DebitCreditAPI.Infra.CrossCutting.Adapter.Map;
using DebitCreditAPI.Infra.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebitCreditAPI.Infra.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceAccount>().As<IApplicationServiceAccount>();
            builder.RegisterType<ApplicationServiceEntry>().As<IApplicationServiceEntry>();
            builder.RegisterType<ApplicationServiceTransaction>().As<IApplicationServiceTransaction>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceAccount>().As<IServiceAccount>();
            builder.RegisterType<ServiceEntry>().As<IServiceEntry>();
            builder.RegisterType<ServiceTransaction>().As<IServiceTransaction>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryAccount>().As<IRepositoryAccount>();
            builder.RegisterType<RepositoryEntry>().As<IRepositoryEntry>();
            builder.RegisterType<RepositoryTransaction>().As<IRepositoryTransaction>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperAccount>().As<IMapperAccount>();
            builder.RegisterType<MapperEntry>().As<IMapperEntry>();
            #endregion

            #endregion

        }
    }
}
