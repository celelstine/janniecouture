using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using jannieCouture.Repositories;
using jannieCouture.Models;

namespace jannieCouture.Controllers
{
    [Route("api/AgeRange")]
    public class AgeRangeController : Controller
    {
        private IAgeRangeRespository _ageRangeRepository;
		private ILogger<AgeRangeController> _logger;

        public AgeRangeController(
            IAgeRangeRespository ageRangeRepository,
			 ILogger<AgeRangeController> logger
        )
        {
            _ageRangeRepository = ageRangeRepository;
			_logger = logger;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var AgeRanges = _ageRangeRepository.AgeRanges;
                return Ok(AgeRanges);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurres while getting ageranges {DateTime.UtcNow}, error_message - {ex}");
                return StatusCode(500, "Failed to get age range.");
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
