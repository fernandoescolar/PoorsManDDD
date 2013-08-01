using System;
using System.Collections.Generic;
using System.Web.Http;
using PoorsManDDD.Services.Contracts;
using PoorsManDDD.Services.Contracts.DataTransferObjects;

namespace PoorsManDDD.Web.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ITodoService service;

        public ValuesController(ITodoService service)
        {
            this.service = service;
        }

        // GET api/values
        public IEnumerable<TodoListItem> Get()
        {
            return this.service.GetPending();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            this.service.AddNew(new TodoListItem { Name = value });
        }

        // PUT api/values/5
        public void Put(Guid id)
        {
            this.service.UpdateStateToDone(id);
        }
    }
}