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

            if(!ModelState.IsValid)
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
    }
}
