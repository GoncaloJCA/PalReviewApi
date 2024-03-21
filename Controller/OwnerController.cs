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
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerRepository ownerRepository, ICountryRepository countryRepository , IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public ActionResult GetOwners()
        {
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owners);
        }

        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Owner))]
        public ActionResult GetOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId)) { return NotFound(); }

            var owner = _mapper.Map<OwnerDto>(_ownerRepository.GetOwner(ownerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owner);
        }

        [HttpGet("pal/{palId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public ActionResult GetOwnerByPal(int palId)
        {
            var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwnerByPal(palId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(owners);
        }

        [HttpGet("{ownerId}/pal")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public ActionResult GetPalByOwner(int ownerId)
        {
            if(!_ownerRepository.OwnerExists(ownerId)) { return NotFound(); }

            var pals = _mapper.Map<List<PalDto>>(_ownerRepository.GetPalByOwner(ownerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pals);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public ActionResult CreateOwner([FromBody] OwnerDto ownerCreate, [FromQuery] int countryId)
        {
            if (ownerCreate == null) { return BadRequest(ModelState); }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_ownerRepository.OwnerExists(ownerCreate.Id))
            {
                ModelState.AddModelError("", "There is already a Owner with that Id");
                return StatusCode(400, ModelState);
            }

            var owner = _ownerRepository.GetOwners()
                .Where(c => c.Name.Trim().ToUpper() == ownerCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (owner != null)
            {
                ModelState.AddModelError("", "Owner already exists");
                return StatusCode(422, ModelState);
            }

            var ownerMap = _mapper.Map<Owner>(ownerCreate);

            ownerMap.Country = _countryRepository.GetCountry(countryId);

            if (!_ownerRepository.CreateOwner(ownerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
