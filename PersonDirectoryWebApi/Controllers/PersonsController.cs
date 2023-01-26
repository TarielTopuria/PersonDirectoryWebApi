using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Models.PersonModels;
using PersonDirectoryWebApi.Repositories.Abstraction.IRepositories;
using PersonDirectoryWebApi.Requests.ImageRequests;
using PersonDirectoryWebApi.Requests.PersonRequests;
using System.Text.Json;

namespace PersonDirectoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private readonly IPersonInfoRepository _personInfoRepository;
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        const int maxCitiesPageSize = 30;

        public PersonsController(ILogger<PersonsController> logger, IPersonInfoRepository personInfoRepository, IMapper mapper, IImageRepository imageRepository)
        {
            _logger = logger;
            _personInfoRepository = personInfoRepository;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonWithEverythingDto>>> GetPersons(string? firstName, string? lastName, string? personalNumber, string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                if (pageSize > maxCitiesPageSize)
                {
                    _logger.LogInformation($"Items per page can't be more than 30");
                    pageSize = maxCitiesPageSize;
                }

                var (personEntities, paginationMetadata) = await _personInfoRepository.GetPersonsAsync(firstName, lastName, personalNumber, searchQuery, pageNumber, pageSize);

                Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

                return Ok(_mapper.Map<IEnumerable<PersonWithEverythingDto>>(personEntities));
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use GET Method to get info about every user, while filtering and paging it. See the message: {e.Message}");
                throw;
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPerson(int Id)
        {
            try
            {
                var existingPerson = await _personInfoRepository.GetPersonAsync(Id);
                if (existingPerson == null)
                {
                    _logger.LogInformation($"Person with id {Id} wasn't found when accessing database.");
                    return NotFound();
                }

                return Ok(_mapper.Map<PersonWithEverythingDto>(existingPerson));
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use GET Method and filter data by person Id. See the message: {e.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<PersonDto>> CreatePerson(CreatePersonRequestDto person)
        {
            try
            {
                var personToCreate = _mapper.Map<Person>(person);
                await _personInfoRepository.CreatePersonASync(personToCreate);
                await _personInfoRepository.SaveChangesAsync();

                var createdPersonToReturn = _mapper.Map<PersonDto>(personToCreate);
                return Ok(createdPersonToReturn);
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use Post Method and creating Person. See the message: {e.Message}");
                throw;
            }   
        }

        [HttpPut("{personId}")]
        public async Task<ActionResult> UpdatePerson(int personId, UpdatePersonRequestDto newPerson)
        {
            try
            {
                if (!await _personInfoRepository.CheckPersonAsync(personId))
                {
                    _logger.LogInformation($"Person with Id {personId} wasn't found when accessing database.");
                    return NotFound();
                }

                var existingPerson = await _personInfoRepository.GetPersonAsync(personId);

                if (existingPerson == null)
                {
                    _logger.LogInformation($"Person with Id {personId} wasn't found when accessing database.");
                    return NotFound();
                }

                _mapper.Map(newPerson, existingPerson);
                _logger.LogError($"Problem occured while saving newPerson propertioes to existingPerson.");
                await _personInfoRepository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use Put method and updating person with Id: {personId}. See the message: {e.Message}");
                throw;
            }
        }

        [HttpDelete("{personId}")]
        public async Task<ActionResult> DeletePerson(int personId)
        {
            try
            {
                if (!await _personInfoRepository.CheckPersonAsync(personId))
                {
                    _logger.LogInformation($"Person with Id {personId} wasn't found when accessing database.");
                    return NotFound();
                }

                var existingPerson = await _personInfoRepository.GetPersonAsync(personId);
                if (existingPerson == null)
                {
                    _logger.LogInformation($"Person with Id {personId} wasn't found when accessing database.");
                    return NotFound();
                }

                _personInfoRepository.DeletePerson(existingPerson);
                await _personInfoRepository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use Delete method and deleting person with Id: {personId}. See the message: {e.Message}");
                throw;
            }
        }

        [HttpPut("uploadImage")]
        public async Task<ActionResult> UploadImage([FromQuery] ImageUploadRequestDto imageToUpload)
        {
            try
            {
                var existingPerson = await _personInfoRepository.GetPersonAsync(imageToUpload.personId);
                if (existingPerson == null)
                {
                    _logger.LogInformation($"Person with Id {imageToUpload.personId} wasn't found when accessing database.");
                    return NotFound();
                }

                existingPerson.ImagePath = await _imageRepository.UploadImage(imageToUpload.Image);
                _logger.LogError($"Problem occured while saving new image path to existing path.");
                await _personInfoRepository.UpdateAsync(existingPerson);

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use Put method and updating image path on person with Id: {imageToUpload.personId}. See the message: {e.Message}");
                throw;
            }
        }
    }
}
