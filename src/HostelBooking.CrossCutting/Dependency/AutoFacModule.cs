using Autofac;
using HostelBooking.ApplicationService.AppService;
using HostelBooking.Domain.AppService;
using HostelBooking.Domain.Repositories;
using HostelBooking.Domain.Repositories.Transaction;
using HostelBooking.Infra.Context;
using HostelBooking.Infra.Repositories;
using HostelBooking.Infra.Transaction;

namespace HostelBooking.CrossCutting.Dependency
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /* Infra */
            builder.RegisterType<HostelBookingDataContext>().As<HostelBookingDataContext>().SingleInstance();
            builder.RegisterType<UoW>().As<IUoW>();
            builder.RegisterType<RoomRepository>().As<IRoomRepository>();
            builder.RegisterType<GuestRepository>().As<IGuestRepository>();

            /* App Service */
            builder.RegisterType<RoomAppService>().As<IRoomAppService>();
            builder.RegisterType<GuestAppService>().As<IGuestAppService>();
        }
    }
}
 