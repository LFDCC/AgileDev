using AgileDev.Core;
using AgileDev.Web.Models;
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
        /// 获取实例化对象
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
            /**
             * AsImplementedInterfaces 以接口的形式注入
             *
             * InstancePerDependency 实例的生命周期 每次调用都new一个新的实例（默认值）
             * InstancePerLifetimeScope 实例的生命周期 new 的范围内都是同一实例
             * SingleInstance 实例的生命周期 单利模式 static一直存在
             * */
#if false

            #region 注册程序集下的指定类

            builder.RegisterAssemblyTypes(assemblys.ToArray())
             .Where(t => t.Name.Equals("AgileDevContext"))//注册指定类
             .InstancePerLifetimeScope();

            #endregion 注册程序集下的指定类

#endif

#if false

            #region 也可以注册指定程序集下的指定类

            Assembly ass = Assembly.Load("AgileDev.EntityFramework");

            builder.RegisterAssemblyTypes(ass)
           .Where(t => t.Name == "AgileDevContext")
           .InstancePerLifetimeScope();

            #endregion 也可以注册指定程序集下的指定类

#endif

            builder.RegisterAssemblyTypes(assemblys.ToArray())
            .Where(t => t.Name.EndsWith("Services"))//查找所有程序集下面以BLL DAL结尾的类
            .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType<TestOne>().InstancePerLifetimeScope();//注册指定的类

            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces().InstancePerDependency();//注册指定的类

            builder.RegisterControllers(Assembly.GetExecutingAssembly());//注册mvc容器的实现

            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}