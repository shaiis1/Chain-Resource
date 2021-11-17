using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResource_ShaiIsraeli.Storages.Abstract
{
    public abstract class AbstractReadOnlyStorage<T> : AbstractStorage
    {
        public abstract Task<T> ReadData();
    }
}
