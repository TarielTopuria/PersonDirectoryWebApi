using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Models.RelatedPersons;
using PersonDirectoryWebApi.Services.IRepositories;

namespace PersonDirectoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatedPersonsController : ControllerBase
    {
        private readonly ILogger<RelatedPersonsController> _logger;
        private readonly IRelatedPersonsInfoRepository _relatedPersonsInfoRepository;
        private readonly IMapper _mapper;
        public RelatedPersonsController(ILogger<RelatedPersonsController> logger, IRelatedPersonsInfoRepository relatedPersonsInfoRepository, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _relatedPersonsInfoRepository = relatedPersonsInfoRepository;
        }


        [HttpGet("{relatedPersonId}", Name = "GetRelatedPerson")]
        public async Task<ActionResult<RelativePersonsDto>> GetRelatedPerson(int personId, int relatedPersonId)
        {
            if (!await _relatedPersonsInfoRepository.CheckPersonAsync(personId))
            {
                _logger.LogInformation($"Person with id {personId} wasn't found when accessing database.");
                return NotFound();
            }

            var relatedPerson = await _relatedPersonsInfoRepository.GetRelatedPersonAsync(personId, relatedPersonId);

            if (relatedPerson == null)
            {
                _logger.LogInformation($"RelatedPerson with id {relatedPersonId} wasn't found when accessing database.");
                return NotFound();
            }

            return Ok(_mapper.Map<RelativePersonsDto>(relatedPerson));
        }

        [HttpGet("relationshipReport")]
        public async Task<ActionResult<IEnumerable<RelationReportDto>>> GetRelationReport()
        {
            try
            {
                var relations = await _relatedPersonsInfoRepository.GetPersonsAsync();
                return Ok(_mapper.Map<IEnumerable<RelationReportDto>>(relations));
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use GET Method to get info about Relationships. See the message: {e.Message}");
                throw;
            }
        }


        [HttpPost]
        public async Task<ActionResult<RelativePersonsDto>> CreateRelatedPerson(int personId, RelatedPersonForCreationDto relatedPerson)
        {
            if(!await _relatedPersonsInfoRepository.CheckPersonAsync(personId))
            {
                _logger.LogInformation($"Person with id {personId} wasn't found when accessing database.");
                return NotFound();
            }

            var finalRelatedPerson = _mapper.Map<RelatedPerson>(relatedPerson);

            await _relatedPersonsInfoRepository.AddRelatedPerson(personId, finalRelatedPerson);
            await _relatedPersonsInfoRepository.SaveChangesAsync();

            var createdRelatedPersonToReturn = _mapper.Map<RelativePersonsDto>(finalRelatedPerson);

            return CreatedAtRoute("GetRelatedPerson", 
                new
                {
                    personId = personId,
                    relatedPersonId = createdRelatedPersonToReturn.Id
                }, 
                createdRelatedPersonToReturn);
        }

        [HttpDelete("{relatedPersonId}")]
        public async Task<ActionResult> DeleteRelatedPerson(int personId, int relatedPersonId)
        {
            try
            {
                if (!await _relatedPersonsInfoRepository.CheckPersonAsync(personId))
                {
                    _logger.LogInformation($"Person with id {personId} wasn't found when accessing database.");
                    return NotFound();
                }

                var relatedPerson = await _relatedPersonsInfoRepository.GetRelatedPersonAsync(personId, relatedPersonId);
                if (relatedPerson == null)
                {
                    _logger.LogInformation($"'Person' with id {personId} which would be related to 'RelatedPerson' with Id {relatedPersonId} wasn't found when accessing database.");
                    return NotFound();
                }

                _relatedPersonsInfoRepository.DeleteRelation(relatedPerson);
                await _relatedPersonsInfoRepository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use Delete Method to delete Related Person with Id {relatedPersonId} who was related to person with Id {personId}. See the message: {e.Message}");
                throw;
            }
            
        }
    }
}
