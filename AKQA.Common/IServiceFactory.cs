using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKQA.Common
{
    public interface IServiceFactory<T>
    {
        T CreateInstance();
    }
}
