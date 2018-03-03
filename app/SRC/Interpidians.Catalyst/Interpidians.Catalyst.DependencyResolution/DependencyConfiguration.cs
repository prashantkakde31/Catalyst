using Interpidians.Catalyst.Core.ApplicationService;
using Interpidians.Catalyst.Core.Common;
using Interpidians.Catalyst.Core.DomainService;
using Interpidians.Catalyst.Infrastructure.Data;
using Interpidians.Catalyst.Infrastructure.Logger;
using Interpidians.Catalyst.Infrastructure.Mailer;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.DependencyResolution
{
    public sealed class DependencyConfiguration : IServiceLocator
    {
        private static readonly Lazy<DependencyConfiguration> lazy = new Lazy<DependencyConfiguration>(() => new DependencyConfiguration());

        public static DependencyConfiguration Instance { get { return lazy.Value; } }

        private Container diContainer;

        public  Container Container { get { return diContainer; } }

        private DependencyConfiguration()
        {
            diContainer = new Container();
            diContainer.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            #region Infrastructure

            #region Data

            //diContainer.Register<IDataContext,DataContext>(Lifestyle.Scoped);
            diContainer.Register<IEmployeeRepository, EmployeeRepository>(Lifestyle.Scoped);
            diContainer.Register<IMcqRepository, McqRepository>(Lifestyle.Scoped);
            diContainer.Register<IExamDetailRepository, ExamDetailRepository>(Lifestyle.Scoped);
            diContainer.Register<IExamRepository, ExamRepository>(Lifestyle.Scoped);
            diContainer.Register<ICourseMasterRepository, CourseMasterRepository>(Lifestyle.Scoped);
            diContainer.Register<ISubCourseMasterRepository, SubCourseMasterRepository>(Lifestyle.Scoped);
            diContainer.Register<ISubjectMasterRepository, SubjectMasterRepository>(Lifestyle.Scoped);
            diContainer.Register<ITopicMasterRepository, TopicMasterRepository>(Lifestyle.Scoped);
            diContainer.Register<IPaperMasterRepository, PaperMasterRepository>(Lifestyle.Scoped);
            diContainer.Register<IMcqAnswerRepository, McqAnswerRepository>(Lifestyle.Scoped);
            diContainer.Register<IExamResultRepository, ExamResultRepository>(Lifestyle.Scoped);
            diContainer.Register<IProductMasterRepository, ProductMasterRepository>(Lifestyle.Scoped);
            diContainer.Register<ICartItemRepository, CartItemRepository>(Lifestyle.Scoped);
            diContainer.Register<IShoppingCartRepository, ShoppingCartRepository>(Lifestyle.Scoped);
            diContainer.Register<IDiscountMasterRepository, DiscountMasterRepository>(Lifestyle.Scoped);
            diContainer.Register<IUserMasterRepository, UserMasterRepository>(Lifestyle.Scoped);
            diContainer.Register<IUserProfileRepository, UserProfileRepository>(Lifestyle.Scoped);
            diContainer.Register<IUserRoleRepository, UserRoleRepository>(Lifestyle.Scoped);
            diContainer.Register<ITestimonialMasterRepository, TestimonialMasterRepository>(Lifestyle.Scoped);


            #endregion

            diContainer.Register<ILogger, Logger>(Lifestyle.Singleton);
            diContainer.Register<IMailer, SmtpMailer>(Lifestyle.Singleton);

            #endregion

            #region Core

            diContainer.Register<IEmployeeService, EmployeeService>();
            diContainer.Register<IExamService, ExamService>();
            diContainer.Register<ICatalystService, CatalystService>();
            diContainer.Register<IUserService, UserService>();
            diContainer.Register<IShoppingCartService, ShoppingCartService>();
            diContainer.Register<ICacheService, CacheService>();


            #endregion

            diContainer.RegisterMvcControllers(System.Reflection.Assembly.GetExecutingAssembly());
            diContainer.RegisterMvcIntegratedFilterProvider();

            diContainer.Verify();
        }

        public object GetInstance(Type serviceType)
        {
            return diContainer.GetInstance(serviceType);
        }

        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return diContainer.GetAllInstances(serviceType).Cast<object>().AsEnumerable();
        }

        public TService GetInstance<TService>() where TService : class
        {
            //return diContainer.GetInstance<TService>();
            return diContainer.GetInstance<TService>();
           //throw new NotImplementedException();
        }

        public IEnumerable<TService> GetAllInstances<TService>() where TService : class
        {
            return diContainer.GetAllInstances<TService>().AsEnumerable();
            //throw new NotImplementedException();
        }
    }
}
