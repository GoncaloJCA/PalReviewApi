using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PalReviewApi.Dto;
using PalReviewApi.Interfaces;
using PalReviewApi.Models;
using PalReviewApi.Repository;

namespace PalReviewApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalController : ControllerBase
    {
        private readonly IPalRepository _palRepository;
        private readonly IMapper _mapper;

        public PalController(IPalRepository palRepository, IMapper mapper)
        {
            _palRepository = palRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pal>))]
        public IActionResult GetPals()
        {
            var pals = _mapper.Map<List<PalDto>>(_palRepository.GetPals());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pals);
        }

        [HttpGet("{palId}")]
        [ProducesResponseType(200, Type = typeof(Pal))]
        [ProducesResponseType(400)]
        public IActionResult GetPal(int palId)
        {
            if (!_palRepository.PalExists(palId))
            {
                return NotFound();
            }

            var pal = _mapper.Map<PalDto>(_palRepository.GetPal(palId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pal);
        }

        [HttpGet("{palId}/rating")]
        [ProducesResponseType(200, Type = typeof(Pal))]
        [ProducesResponseType(400)]
        public IActionResult GetPalRating(int palId)
        {
            if (!_palRepository.PalExists(palId))
            {
                return NotFound();
            }

            var rating = _palRepository.GetPalRating(palId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult CreateOwner([FromBody] PalDto palCreate, [FromQuery] int ownerId, [FromQuery] int catId)
        {
            if (palCreate == null) { return BadRequest(ModelState); }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var pals = _palRepository.GetPals()
                .Where(p => p.Name.Trim().ToUpper() == palCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (pals != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            var palMap = _mapper.Map<Pal>(palCreate);

            if (!_palRepository.CreatePal(ownerId, catId, palMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
