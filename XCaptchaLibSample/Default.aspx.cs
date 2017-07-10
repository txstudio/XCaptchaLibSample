using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace XCaptchaLibSample
{
    public partial class Default : System.Web.UI.Page
    {
        const string captcha_session_name = "captcha_session_name";
        const string base64_image_format = "data:image/jpg;base64,{0}";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.IsPostBack == false)
            {
                //隨機取得驗證碼數值
                var _captcha = this.GetCaptcha();

                //建立 XCaptcha 驗證物件
                var _builder = new XCaptcha.ImageBuilder();
                var _result = _builder.Create(_captcha);

                //取得驗證碼數值圖片
                var _buffer = _result.Image;
                var _base64 = this.GetBase64Image(_buffer);

                this.SetCaptchValue(_captcha);
                this.CaptchaImage.ImageUrl = _base64;
            }
        }

        protected void CaptchaButton_Click(object sender, EventArgs e)
        {
            var _captcha = this.CaptchaTextBox.Text;

            if(this.IsCaptchaValidator(_captcha) == true)
                this.Validator.Text = "驗證通過";
            else
                this.Validator.Text = "驗證失敗";

        }

        /// <summary>設定驗證碼</summary>
        private void SetCaptchValue(string captcha)
        {
            this.Session[captcha_session_name] = captcha;
        }

        /// <summary>進行驗證碼的檢查</summary>
        private bool IsCaptchaValidator(string captcha)
        {
            if(this.Session[captcha_session_name] == null)
                return false;

            var _imgCaptcha = this.Session[captcha_session_name].ToString();

            if (String.Equals(_imgCaptcha, captcha, StringComparison.OrdinalIgnoreCase) == true)
                return true;

            return false;
        }


        /// <summary>取得 base64 編碼影像</summary>
        private string GetBase64Image(byte[] content)
        {
            var _quotationMark = new char[]{'"'};
            var _json = JsonConvert.SerializeObject(content);
            var _base64 = _json.Trim(_quotationMark);

            return string.Format(base64_image_format, _base64);
        }

        /// <summary>使用 guid 取得隨機的五個字元英數字</summary>
        private string GetCaptcha()
        {
            var _guid = Guid.NewGuid();
            var _guidString = _guid.ToString();
            var _captcha = _guidString.Substring(0, 5);

            return _captcha;
        }
    }
}