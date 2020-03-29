using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AKQA.Common;
using AKQA.Service;

namespace AKQA.SharedLogic
{
    public interface IServiceFactories
    {
        IServiceFactory<IConvertService> ConvertServiceFactory { get; set; }
    }
}
