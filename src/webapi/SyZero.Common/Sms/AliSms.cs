using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Exceptions;

namespace SyZero.Common
{
    public class AliSms
    {
        protected static string _accessId = "";   //accessId
        protected static string _accessSecret = "";   //accessSecret
        protected static string _signName = "";   //签名
        static AliSms() {
            _signName = ConfigurationUtil.GetSection("AliyunSms:signName");
            _accessId = ConfigurationUtil.GetSection("AliyunSms:accessId");
            _accessSecret = ConfigurationUtil.GetSection("AliyunSms:accessSecret");
        }
        /// <summary>
        /// 短信发送
        /// </summary>
        /// <param name="mobile">手机号</param>
        /// <param name="templateCode">模板code</param>
        /// <param name="templateParam">内容</param>
        /// <returns>Code=ok 成功</returns>
        public static string SmsSend(string mobile, string templateCode, string templateParam = "")
        {
            IClientProfile profile = DefaultProfile.GetProfile("default", _accessId, _accessSecret);
            DefaultAcsClient client = new DefaultAcsClient(profile);
            CommonRequest request = new CommonRequest();
            request.Method = MethodType.POST;
            request.Domain = "dysmsapi.aliyuncs.com";
            request.Version = "2017-05-25";
            request.Action = "SendSms";
            request.AddQueryParameters("PhoneNumbers", mobile);
            request.AddQueryParameters("SignName", _signName);
            request.AddQueryParameters("TemplateCode", templateCode);
            request.AddQueryParameters("TemplateParam", templateParam);
            // request.Protocol = ProtocolType.HTTP;
            try
            {
                CommonResponse response = client.GetCommonResponse(request);
                string code = JsonHelper.DataRowFromJSON(System.Text.Encoding.Default.GetString(response.HttpResponse.Content))["Code"].ToString();
                return code;
            }
            catch (ServerException e)
            {
                return e.Message;
            }
            catch (ClientException e)
            {
                return e.Message;
            }
        }
       
    }
}