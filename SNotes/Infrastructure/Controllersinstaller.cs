using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace SNotes.Infrastructure
{
    public class Controllersinstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //Wszamy wszystke kontrolery do Kontenera
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
        }

    }
}