using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cmcoins.Boc
{
    public class IHTMLElementManager
    {
        private bool _isNeedInit = true;

        private IHTMLElement _html_userName;
        private IHTMLElement _html_mobile;
        private IHTMLElement _html_IdentityNumber;
        private IHTMLElement _html_Btn_Nextstep;

        public IHTMLElementManager() { }

        public void Init(IHTMLDocument2 document)
        {

            IHTMLDocument2 doc2 = document;

            this._html_userName = (IHTMLElement)doc2.all.item(HTMLElementSetting.Str_UserName, 0);
            this._html_mobile = (IHTMLElement)doc2.all.item(HTMLElementSetting.Str_Mobile, 0);
            this._html_IdentityNumber = (IHTMLElement)doc2.all.item(HTMLElementSetting.Str_IdentityNumber, 0);
            this._html_Btn_Nextstep = (IHTMLElement)doc2.all.item(HTMLElementSetting.Str_Btn_Nextstep, 0);

            if (this._html_userName == null || this._html_mobile == null || this._html_IdentityNumber == null || this._html_Btn_Nextstep == null)
            {
                this._isNeedInit = true;
            }
            else
            {
                this._isNeedInit = false;
            }

        }
        public bool IsNeedInit()
        {
            return this._isNeedInit;
        }
        public void AddInfo(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return;
            }
            this._html_userName.setAttribute("value", userInfo.Str_UserName);
            this._html_mobile.setAttribute("value", userInfo.Str_Mobile);
            this._html_IdentityNumber.setAttribute("value", userInfo.Str_IdentityNumber);
            //this._html_Btn_Nextstep.setAttribute("value", userInfo.Str_UserName);
        }

    }

}
