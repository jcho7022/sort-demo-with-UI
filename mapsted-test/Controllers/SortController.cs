using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MapstedTest.Models;
using MapstedTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MapstedTest.Controllers
{
    [Route("api/[controller]")]
    public class SortController : Controller
    {
        private readonly ISortRespoitory _repo;

        public SortController(ISortRespoitory repo)
        {
            _repo = repo;
        }

        [HttpPost("int")]
        public List<List<int>> SortInteger([FromBody] SortTask<int> sortTask)
        {
            if (sortTask == null)
            {
                Response.StatusCode = 400;
                return null;
            }
            return _repo.SortList(sortTask);
        }

        [HttpPost("double")]
        public List<List<double>> SortString([FromBody] SortTask<double> sortTask)
        {
            if (sortTask == null)
            {
                Response.StatusCode = 400;
                return null;
            }
            return _repo.SortList(sortTask);
        }
    }
}
