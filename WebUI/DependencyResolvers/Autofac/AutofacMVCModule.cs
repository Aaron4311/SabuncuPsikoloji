using Autofac;
using WebUI.Services.Abstract;
using WebUI.Services.Concrete;
using Module = Autofac.Module;

namespace WebUI.DependencyResolvers.Autofac
{
    public class AutofacMVCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogManager>().As<IBlogService>().SingleInstance();
            builder.RegisterType<ServiceManager>().As<IServiceService>().SingleInstance();
            builder.RegisterType<MessageManager>().As<IMessageService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<PsychologistManager>().As<IPsychologistService>().SingleInstance();
            builder.RegisterType<SliderContentManager>().As<ISliderContentService>().SingleInstance();
            builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
            builder.RegisterType<TopContentManager>().As<ITopContentService>().SingleInstance();
            builder.RegisterType<BottomContentManager>().As<IBottomContentService>().SingleInstance();






        }
    }
}
