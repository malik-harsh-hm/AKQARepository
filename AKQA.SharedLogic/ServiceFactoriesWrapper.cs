using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKQA.Common;
using AKQA.Service;

namespace AKQA.SharedLogic
{
    public class ServiceFactoriesWrapper : IServiceFactories
    {
        public IServiceFactory<IConvertService> ConvertServiceFactory
        {
            get
            {
                return ServiceFactories.ConvertServiceFactory;
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
