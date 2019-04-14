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
        private readonly IUnitOfWork _unitOfWork;
        public ValuesController(IRepository<Article> articleRep, IUnitOfWork unitOfWork) {
            _articleRep = articleRep;
            _unitOfWork = unitOfWork;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Article> Get()
        {
         var op =   _articleRep.GetList();
            _articleRep.Add(new Article() { Id = SnowflakeId.GetID(), Title = "aaa", AddTime = DateTime.Now, UpdateTime = DateTime.Now, Author = "aaaaaaaaaaa", Category = 99, Content = "aaaaaaa" });
            _unitOfWork.SaveChange();
            return op;
            // new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
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
    }
}
