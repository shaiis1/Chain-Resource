using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResource_ShaiIsraeli.Storages.Abstract
{
    public enum StorageTypeEnum
    {
        Memory,
        FileSystem,
        WebService
    }

    public enum PermissionsEnum
    {
        ReadOnly,
        ReadWrite
    }

    public abstract class AbstractStorage
    {
        public PermissionsEnum Permissions { get; set; }
        public int ExpirationInterval { get; set; }
    }
}
