using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace EmployeeUI
{
    internal static class Program
    {
        public static IContainer Container;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Container = Configure();
            Application.Run(new XtraHome(Container.Resolve<IDepartmentService>(), Container.Resolve<IEmployeeService>(), Container.Resolve<IOffDayService>(), Container.Resolve<IPayrollParameterService>(), Container.Resolve<IPayrollService>()));
        }

        static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DerpartmentManager>().As<IDepartmentService>();
            builder.RegisterType<EfDeparmentDal>().As<IDeparmentDal>();

            builder.RegisterType<EmployeeManager>().As<IEmployeeService>();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>();

            builder.RegisterType<OffDayManager>().As<IOffDayService>();
            builder.RegisterType<EfOffDayDal>().As<IOffDayDal>();

            builder.RegisterType<PayrollParameterManager>().As<IPayrollParameterService>();
            builder.RegisterType<EfPayrollParameterDal>().As<IPayrollParameterDal>();

            builder.RegisterType<PayrollManager>().As<IPayrollService>();
            builder.RegisterType<EfPayrollDal>().As<IPayrollDal>();

            builder.RegisterType<XtraHome>();            
            return builder.Build();
        }
    }
}