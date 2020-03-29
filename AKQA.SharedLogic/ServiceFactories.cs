using AKQA.Common;
using AKQA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKQA.SharedLogic
{
    class ServiceFactories
    {
        public static WcfServiceFactory<IConvertService> ConvertServiceFactory = new WcfServiceFactory<IConvertService>("ConvertService");
    }
}
