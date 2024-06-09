using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;

namespace example_api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class KeyVaultController : ControllerBase
    {
        private readonly SecretClient _secretClient;

        public KeyVaultController(SecretClient secretClient)
        {
            _secretClient = secretClient;
        }

        [HttpGet("secret/{secretName}")]
        public async Task<IActionResult> GetSecret(string secretName)
        {
            try
            {
                KeyVaultSecret secret = await _secretClient.GetSecretAsync(secretName);
                return Ok(secret.Value);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("hello")]
        public  IActionResult SayHello()
        {
            try
            {
                return Ok("Hello");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}