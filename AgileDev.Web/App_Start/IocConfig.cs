using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;

namespace AgileDev.Common
{
    public class IocConfig
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// 获取 IDAL 的实例化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    RegisterContainer();
                }
                return container.Resolve<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"IOC实例化类型{typeof(T).GetType().FullName}出错!" + ex.Message);
            }

        }

        /// <summary>
        /// 注册到容器中
        /// </summary>
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();
            builder.RegisterAssemblyTypes(assemblys.ToArray())
            .Where(t => t.Name.EndsWith("BLL"))//查找所有程序集下面以BLL结尾的类
            .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assemblys.ToArray())
            .Where(t => t.Name.EndsWith("DAL"))//查找所有程序集下面以DAL结尾的类
            .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());//注册mvc容器的实现

            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
