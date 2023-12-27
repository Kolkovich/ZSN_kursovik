using Microsoft.AspNetCore.Mvc;
using ZavodSocialNetwork.Server.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZavodSocialNetwork.Server
{
    [Route("[controller]")]
    [ApiController]
    public class XyetaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Холодно я ебал", "Видимо, не так холодно, как я ебал", "Прохлдненько блин", "Уже приятнеее", "Мокро", "Тёпленько", "Хз", "Жарко", "Чо", "Я приготовился в духовке"
        };

        private readonly ILogger<XyetaController> _logger;

        public XyetaController(ILogger<XyetaController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetXyeta")]
        public IEnumerable<Xyeta> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Xyeta
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-60, 4896),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
