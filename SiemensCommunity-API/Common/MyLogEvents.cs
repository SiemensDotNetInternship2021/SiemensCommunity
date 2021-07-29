using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class MyLogEvents
    {
        public const int GenerateItems = 1000;
        public const int ListItems = 1001;
        public const int GetItem = 1002;
        public const int InsertItem = 1003;
        public const int UpdateItem = 1004;
        public const int DeleteItem = 1005;

        public const int EmailSent = 2000;
        public const int ErrorEmailSent = 2001;

        public const int TestItem = 3000;
        public const int UploadItem = 3001;
        public const int ErrorUploadItem = 3002;

        public const int GetItemNotFound = 4000;
        public const int UpdateItemNotFound = 4001;


    }
}
