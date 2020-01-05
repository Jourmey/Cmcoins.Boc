using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmcoins.Boc
{
    public static class UriFactory
    {
        internal static Uri GetUri()
        {
            return new Uri("https://cmcoins.boc.cn/BOC15_CoinSeller/welcome.html");
        }
    }

    public static class HTMLElementSetting
    {
        //姓名
        public static string Str_UserName = "txt_name_1956714";
        //手机号
        public static string Str_Mobile = "txt_mobile_1956715";
        //证件类型
        public static string Str_IdentifyType = "sel_identifytype_1956716";
        //身份证
        public static string Str_IdentityNumber = "txt_identitynumber_1956717";
        //下一步按钮
        public static string Str_Btn_Nextstep = "btn_nextstep_1956722";
    }

    public class UserInfo
    {
        public string Str_UserName { get; set; }
        //手机号
        public string Str_Mobile { get; set; }
        //证件类型
        public string Str_IdentifyType { get; set; }
        //身份证
        public string Str_IdentityNumber { get; set; }

        public bool IsPrint { get; set; }
    }
}