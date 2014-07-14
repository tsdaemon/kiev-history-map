[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(KyivMap.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(KyivMap.App_Start.NinjectWebCommon), "Stop")]

namespace KyivMap.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;
    using Data;
    using Data.Daos;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Models;
    using Ninject;
    using Ninject.Web.Common;
    using TSFramework.Dao;

	public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
	        kernel.Bind<DbContext>().To<KyivMapDbContext>().InRequestScope();
	        kernel.Bind<KyivMapDbContext>().ToSelf().InRequestScope();

	        kernel.Bind<IDao<HistoryBuilding>>().To<HistoryBuildingDao>();
        }        
    }
}
