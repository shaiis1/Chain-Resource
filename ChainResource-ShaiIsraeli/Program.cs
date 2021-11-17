using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResource_ShaiIsraeli
{
    class Program
    {
        static void Main(string[] args)
        {
            ChainResource<ExchangeRateList> cahinResource = new ChainResource<ExchangeRateList>();
            Task<ExchangeRateList> taskChain = cahinResource.Get();
            taskChain.Wait();
            ExchangeRateList results = taskChain.Result;
            if (results != null)
            {
                Console.WriteLine("\nThe rates are :\n");
                foreach (var rate in results.Rates)
                {
                    Console.WriteLine("{0}:{1}", rate.Key, rate.Value);
                }
            }
        }
    }
}
