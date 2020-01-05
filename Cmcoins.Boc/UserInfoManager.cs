using NOPItest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmcoins.Boc
{
    class UserInfoManager
    {
        private List<UserInfo> _userInfos = new List<UserInfo>();
        private int _index = 0;

        public UserInfoManager()
        {

        }

        public void InitAllUserInfo(List<UserInfoDTO> userInfoDTO)
        {
            if (userInfoDTO == null || userInfoDTO.Count == 0)
            {
                return;
            }

            var userInfos = userInfoDTO.Select((w) => new UserInfo()
            {
                IsPrint = true,
                Str_IdentifyType = "身份证",
                Str_IdentityNumber = w.ID,
                Str_Mobile = w.MobileNumber,
                Str_UserName = w.Name
            });

            if (userInfos != null)
            {
                this._userInfos = userInfos.ToList();
            }

        }

        public UserInfo GetSelectUserInfo()
        {
            return (new UserInfo()
            {
                Str_IdentifyType = "身份证",
                Str_IdentityNumber = "211021199511111111",
                Str_Mobile = "15735181111",
                Str_UserName = "郑成功"
            });
        }

        public List<UserInfo> GetAllUserInfo()
        {
            return this._userInfos;
        }

        public UserInfo GetNextUserInfo()
        {
            if (this._userInfos == null || this._userInfos.Count == 0)
            {
                return null;
            }

            if (this._index >= this._userInfos.Count)
            {
                this._index = 0;
            }
            UserInfo result = this._userInfos[this._index];
            this._index++;
            return result;

        }

    }
}
