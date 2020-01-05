using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOPItest
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Administrator\Desktop\新建 XLSX 工作表.xlsx";

            var ss = UserInfoExcelHelper.InitUserInfoDTO(path);


        }
    }
}
