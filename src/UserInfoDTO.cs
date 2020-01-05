using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOPItest
{
    public struct UserInfoDTO
    {
        public string Name;
        public string ID;
        public string MobileNumber;

    }


    public static class UserInfoExcelHelper
    {

        public static List<UserInfoDTO> InitUserInfoDTO(string path)
        {
            if (string.IsNullOrWhiteSpace(path) == true)
            {
                return null;
            }

            List<UserInfoDTO> result = new List<UserInfoDTO>();

            var sheets = NPOIC.GetSheetName(path);
            if (sheets == null || sheets.Count() == 0)
            {
                return null;
            }
            for (int i = 0; i < sheets.Count(); i++)
            {
                DataTable oneSheetDataTables = NPOIC.ExcelToDataTable(path, sheets[i]);

                List<UserInfoDTO> oneSheetUserInfo = GetUserInfoDTOs(oneSheetDataTables);

                if (oneSheetUserInfo != null && oneSheetUserInfo.Count != 0)
                {
                    result.AddRange(oneSheetUserInfo);
                }
            }


            return result;

        }

        private static List<UserInfoDTO> GetUserInfoDTOs(DataTable oneSheetDataTables)
        {
            if (oneSheetDataTables == null || oneSheetDataTables.Rows == null || oneSheetDataTables.Rows.Count == 0)
            {
                return null;
            }

            List<UserInfoDTO> result = new List<UserInfoDTO>();
            foreach (DataRow row in oneSheetDataTables.Rows)
            {
                UserInfoDTO one = new UserInfoDTO();
                one.Name = row[0].ToString();
                one.MobileNumber = row[1].ToString();
                one.ID = row[2].ToString();

                if (string.IsNullOrWhiteSpace(one.Name) == false &&
                    string.IsNullOrWhiteSpace(one.MobileNumber) == false &&
                    string.IsNullOrWhiteSpace(one.ID) == false)
                {
                    result.Add(one);
                }

            }

            return result;
        }
    }

}
