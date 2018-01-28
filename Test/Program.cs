using QiangHongBao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //string str = Guid.NewGuid().ToString();
            //var str2 = str.Substring(0, 2);
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(System.IO.Path.GetTempFileName());
            //}


            var result = NetHelper.Get("http://www.ip138.com/");
            if(result.Success)
            {

            }
            
            

            Console.ReadKey();
        }
    }
}
