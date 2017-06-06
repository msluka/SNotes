using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;

namespace SNotes.Infrastructure
{
    //tworzy obikt przez pobranie kontenera // Pobiera kontrolery uziwanc kontenera
    public class WindsorConrtollerFactory : DefaultControllerFactory
    {

        private readonly IKernel _kernel;

        public WindsorConrtollerFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controlleType)
        {
            if (controlleType == null)
                throw new HttpException(404, $"Controller for path " +
                                             $"{requestContext.HttpContext.Request.Path} could not found");

            return (IController)_kernel.Resolve(controlleType);
        }

        public override void ReleaseController(IController controller)
        {
            _kernel.ReleaseComponent(controller);
        }

    }
}