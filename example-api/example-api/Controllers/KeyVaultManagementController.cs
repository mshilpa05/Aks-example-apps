using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Mvc;

namespace example_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KeyVaultManagementController : ControllerBase
    {
        private readonly SecretClient _secretClient;

        public KeyVaultManagementController(SecretClient secretClient)
        {
            _secretClient = secretClient;
        }

        [HttpPost("addSecret")]
        public async Task<IActionResult> AddSecret([FromBody] SecretRequest secretRequest)
        {
            try
            {
                KeyVaultSecret secret = new KeyVaultSecret(secretRequest.Name, secretRequest.Value);
                await _secretClient.SetSecretAsync(secret);
                return Ok("Secret added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    public class SecretRequest
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
