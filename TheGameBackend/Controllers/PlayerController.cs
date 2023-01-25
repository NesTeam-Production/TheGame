using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheGame.Factories;
using TheGame.Items;

namespace TheGameBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/weapon")]
    public class WeaponController : ControllerBase
    {
        [HttpGet("weapons")]
        public List<Weapon> GetWeapons()
        {
            return WeaponFactory.GetWeapons();
        }
    }
}