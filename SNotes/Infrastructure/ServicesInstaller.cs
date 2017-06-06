using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SNotes.DAL;
using SNotes.Repositories;

namespace SNotes.Infrastructure
{
    public class ServicesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            container.Register(Component.For<SNotesContext>());

            container.Register(Component.For<INoteRepository>
                ().ImplementedBy<NoteRepository>());

            container.Register(Component.For<ILabelRepository>
                ().ImplementedBy<LabelRepository>());
        }

    }
}