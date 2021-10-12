using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerPlatform.Dataverse.Client;

namespace ServiceClientRepro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ServiceClient _serviceClient;

        public AccountsController(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        [HttpGet("~/accounts")]
        public IActionResult GetAccount()
        {
            using (var context = new CrmServiceContext(_serviceClient))
            {
                var account = new Account();
                account.Name = "ABC";
                account.Description = null;

                context.AddObject(account);

                context.SaveChanges();
            }

            return Ok();
        }
    }
}
