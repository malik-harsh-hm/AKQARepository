﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Ninject;
using Ninject.Web.Common;
using AKQA.Business;

namespace AKQA.Service
{
    public class Global : NinjectHttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IBusiness>().To<Business.Business>();

            return kernel;
        }
    }
}