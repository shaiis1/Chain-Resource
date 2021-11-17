using ChainResource_ShaiIsraeli.Factories;
using ChainResource_ShaiIsraeli.Interfaces;
using ChainResource_ShaiIsraeli.Storages.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResource_ShaiIsraeli
{
    public class ChainResource<T> : IChainResource<T>
    {
        StorageFactory factory = new StorageFactory();

        public Task<T> Get()
        {
            Task<T> extractedData = null;

            extractedData = ReadFromMemory();
            extractedData = extractedData == null ? ReadFromFileSystem() : extractedData;

            if (extractedData == null)
            {
                extractedData = ReadFromWebService();

                if (extractedData != null)
                {
                    SaveInFileSystem(extractedData.Result); //Save in File System for 4 Hours 
                    SaveInMemory(extractedData.Result);//Save in Memory for 1 Hour
                }

            }

            return extractedData;
        }


        #region Private Methods
        private Task<T> ReadFromMemory()
        {
            Task<T> extractedData = null;
            var memoryStorage = factory.GetRWStorageByType<T>(StorageTypeEnum.Memory);
            if (memoryStorage == null)
            {
                throw new Exception("Failed to create Memory Storage Object");
            }
            extractedData = memoryStorage.ReadData();
            return extractedData;
        }

        private Task<T> ReadFromFileSystem()
        {
            Task<T> extractedData = null;
            var fileSystemStorage = factory.GetRWStorageByType<T>(StorageTypeEnum.FileSystem);
            if (fileSystemStorage == null)
            {
                throw new Exception("Failed to create FileSystem Storage Object");
            }

            extractedData = fileSystemStorage.ReadData();

            return extractedData;
        }

        private Task<T> ReadFromWebService()
        {

            Task<T> extractedData = null;
            var webServiceStorage = factory.GetROStorageByType<T>(StorageTypeEnum.WebService);
            extractedData = webServiceStorage.ReadData();
            return extractedData;
        }


        private void SaveInMemory(T streamDataToWrite)
        {
            var memoryStorage = factory.GetRWStorageByType<T>(StorageTypeEnum.Memory);
            var success = memoryStorage.WriteData(streamDataToWrite);
            if (!success)
            {
                throw new Exception("Failed to write data to Memory System");
            }
        }

        private void SaveInFileSystem(T streamDataToWrite)
        {
            var fileSystemStorage = factory.GetRWStorageByType<T>(StorageTypeEnum.FileSystem);
            bool success = fileSystemStorage.WriteData(streamDataToWrite);
            if (!success)
            {
                throw new Exception("Failed to write data to File System");
            }
        }

        #endregion

    }
}
