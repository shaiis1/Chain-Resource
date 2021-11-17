using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResource_ShaiIsraeli.Storages.Abstract
{
    public abstract class AbstractReadWriteStorage<T> : AbstractStorage
    {
        public abstract Task<T> ReadData();
        public abstract bool WriteData(T stream);
    }
}
