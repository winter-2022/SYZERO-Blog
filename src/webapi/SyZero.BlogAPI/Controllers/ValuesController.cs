using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SyZero.Common;
using SyZero.Domain.Repository;
using SyZero.Domain.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyZero.BlogAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IRepository<Article> _articleRep;
        private readonly IRepository<SiteConfig> _siteconfigRep;
        private readonly IUnitOfWork _unitOfWork;
        public ValuesController(IRepository<Article> articleRep, IUnitOfWork unitOfWork, IRepository<SiteConfig> siteconfigRep) {
            _articleRep = articleRep;
            _unitOfWork = unitOfWork;
            _siteconfigRep = siteconfigRep;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Article> Get()
        {
            var op = _articleRep.GetList();
            _articleRep.Add(new Article() { Id = SnowflakeId.GetID(), Title = "aaa", AddTime = DateTime.Now, UpdateTime = DateTime.Now, Author = "aaaaaaaaaaa", Category = 99, Content = "aaaaaaa" });
            _unitOfWork.SaveChange();
            return op;
            // new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string signname = _siteconfigRep.GetModel(p => p.Key == SYKeys.CACHE_SIGNNAME_ALISMS).Value;
            string appid = _siteconfigRep.GetModel(p => p.Key == SYKeys.CACHE_ACCESSID_ALISMS).Value;
            string secret = _siteconfigRep.GetModel(p => p.Key == SYKeys.CACHE_SECRET_ALISMS).Value;
            AliSms aliSms = new AliSms(signname, appid, secret);
            return aliSms.SmsSend("13201463663", "SMS_163436125", "{'code':52332}");
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
            SetSetconfig(SYKeys.CACHE_SECRET_ALISMS, "QXmth7NEDEIJkfeDrML4klMfWIJuXL");
            SetSetconfig(SYKeys.CACHE_ACCESSID_ALISMS, "LTAITYFg9oA0ogW2");
            SetSetconfig(SYKeys.CACHE_SIGNNAME_ALISMS, "SYZERO");
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private void SetSetconfig(string key,string value) {
            var signame = _siteconfigRep.GetModel(p => p.Key == key);
            if (signame != null)
            {
                signame.Value = value;
                _unitOfWork.SaveChange();
            }
            else
            {
                SiteConfig siteConfig = new SiteConfig();
                siteConfig.Key = key;
                siteConfig.Value = value;
                _siteconfigRep.Add(siteConfig);
                _unitOfWork.SaveChange();
            }
        }
    }
}
