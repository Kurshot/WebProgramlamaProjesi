using H12Auth2C.Data;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace H12Auth2C.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCompanyController : Controller
    {
        private readonly ApplicationDbContext o;
        public ApiCompanyController(ApplicationDbContext o)
        {
            this.o = o;
        }
        [HttpGet]
        public List<Company> Get()
        {
            var comp = o.Company.ToList();
            return comp;
        }
    }
}
