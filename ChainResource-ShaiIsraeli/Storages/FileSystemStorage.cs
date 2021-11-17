using ChainResource_ShaiIsraeli.Storages.Abstract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ChainResource_ShaiIsraeli.Storages
{
    public class FileSystemStorage<T> : AbstractReadWriteStorage<T>
    {
        private String SERIALIZERPATH = ConfigurationManager.AppSettings["filePath"]; // Change it on App.config

        public FileSystemStorage(int _expirationInterval, PermissionsEnum _permission)
        {
            this.ExpirationInterval = _expirationInterval;
            this.Permissions = _permission;
        }

        public override Task<T> ReadData()
        {
            //********* TODO: Read Data From File **********//
            //if (File.Exists(this.SERIALIZERPATH))
            //{
            //    using (FileStream fs = new FileStream(SERIALIZERPATH, FileMode.Open))
            //    {
            //        XmlSerializer _xSer = new XmlSerializer();

            //        var myObject = _xSer.Deserialize(fs);

            //        return Task.FromResult((T)myObject);
            //    }
            //}

            return null;
        }

        public override bool WriteData(T stream)
        {
            try
            {
                //********* TODO: Write Data To File **********//
                //var serialize = new XmlSerializer(stream.GetType());
                //using (FileStream fs = new FileStream(SERIALIZERPATH, FileMode.Create))
                //{
                //    XmlSerializer _xSer = new XmlSerializer(stream.GetType());
                //    _xSer.Serialize(fs, stream);
                //}

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
