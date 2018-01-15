using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace gameReg
{
    public class DbStore
    {
        private const string dbFile = "dbFile.txt";

        public static void Init()
        {
            if (!File.Exists(dbFile))
            {
                var fileStream = File.Create(dbFile);
                fileStream.Dispose();
            }
        }

        public static void Store(string msg)
        {
            File.AppendAllText(dbFile, msg + "\r\n");
        }
    }
}
