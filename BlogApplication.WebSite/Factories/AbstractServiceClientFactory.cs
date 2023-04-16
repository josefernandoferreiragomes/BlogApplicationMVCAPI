using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApplication.WebSite.Factories
{
    public abstract class AbstractServiceClientFactory<T>
    {
        public abstract T GetClient();
    }
}
