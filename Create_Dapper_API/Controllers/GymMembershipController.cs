using Create_Dapper_API.DAL;
using Create_Dapper_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Create_Dapper_API.Controllers
{
    public class GymMembershipController : ApiController
    {
        private GymMembershipRepository gymRepository;

        public GymMembershipController()
        {
           gymRepository = new GymMembershipRepository();
        }

        // GET: api/GymMembership/
        [Route("GymMembership")]
        [HttpGet]
        public List<GymMembership> Get()
        {
            return gymRepository.GetGymMemberships(10, "ASC");
        }

        // GET: api/GymMembership/10/ASC
        [Route("GymMembership/{amount}/{sort}")]
        public List<GymMembership> Get(int amount, string sort)
        {
            return gymRepository.GetGymMemberships(amount, sort);
        }

        // GET: /GymMembership/5
        [Route("GymMembership/{id}")]
        [HttpGet]
        public GymMembership Get(int id)
        {
            return gymRepository.GetSingleGymMembership(id);
        }

        // POST: api/GymMembership
        [Route("GymMembership")]
        [HttpPost]
        public bool Post([FromBody]GymMembership membership)
        {
            //GymMembership membership1 = new GymMembership()
            return gymRepository.InsertGymMembership(membership);
        }

        // PUT: api/GymMembership/5
        public bool Put([FromBody]GymMembership membership)
        {
            return gymRepository.UpdateGymMembership(membership);
        }

        // DELETE: api/GymMembership/5
        [Route("GymMembership/{id}")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return gymRepository.DeleteGymMembership(id);
        }
    }
}
