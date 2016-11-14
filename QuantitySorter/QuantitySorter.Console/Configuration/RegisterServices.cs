using Autofac;
using QuantitySorter.Business.Service;

namespace QuantitySorter.Console.Configuration
{
    public class RegisterServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Application
            builder.RegisterType<Application>().As<IApplication>();

            //Services
            builder.RegisterType<FileReadService>().As<IFileReadService>();
            builder.RegisterType<SortService>().As<ISortService>();
            builder.RegisterType<DataTrackerListService>().As<IDataTrackerListService>();
            base.Load(builder);
        }
    }
}