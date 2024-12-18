using Geometrie.BLL;
using Microsoft.AspNetCore.Mvc;

namespace Geometrie.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CercleController : Controller
    {
        private readonly List<Cercle> cercles = new();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(cercles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cercle = cercles.ElementAtOrDefault(id);
            return cercle != null ? Ok(cercle) : NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Cercle cercle)
        {
            cercles.Add(cercle);
            return CreatedAtAction(nameof(GetById), new { id = cercles.Count - 1 }, cercle);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Cercle cercle)
        {
            if (id < 0 || id >= cercles.Count)
                return NotFound();

            cercles[id] = cercle;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id < 0 || id >= cercles.Count)
                return NotFound();

            cercles.RemoveAt(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult GetTotalArea([FromBody] IEnumerable<int> ids)
        {
            double totalArea = ids
                .Where(id => id >= 0 && id < cercles.Count)
                .Sum(id => cercles[id].CalculerAire());

            return Ok(totalArea);
        }
    }
}
