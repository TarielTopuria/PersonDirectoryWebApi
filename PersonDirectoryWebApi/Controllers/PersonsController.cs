using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Models.PersonModels;
using PersonDirectoryWebApi.Services.IRepositories;

namespace PersonDirectoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private readonly IPersonInfoRepository _personInfoRepository;
        private readonly IMapper _mapper;

        public PersonsController(ILogger<PersonsController> logger, IPersonInfoRepository personInfoRepository, IMapper mapper)
        {
            _logger = logger;
            _personInfoRepository = personInfoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonWithEverythingDto>>> GetPersons()
        {
            try
            {
                var existingPersons = await _personInfoRepository.GetPersonsAsync();
                return Ok(_mapper.Map<IEnumerable<PersonWithEverythingDto>>(existingPersons));
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use GET Method to get info about every user. See the message: {e.Message}");
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
        public async Task<ActionResult<PersonDto>> CreatePerson(CreatePersonDto person)
        {
            try
            {
                var personToCreate = _mapper.Map<Person>(person);
                //var numberToCreate = _mapper.Map<PhoneNumber>(person); (+string PhoneNumbers and int NumberTypeId)
                await _personInfoRepository.CreatePersonASync(personToCreate);
                //await _phoneNumberRepository.CreatePhoneNumbersAsync(numberToCreate)
                await _personInfoRepository.SaveChangesAsync();
                //await _phoneNumberRepository.SaveChangesAsync();

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
        public async Task<ActionResult> UpdatePerson(int personId, UpdatePersonDto newPerson)
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
                _logger.LogError($"Problem occured while converting newPerson to existingPerson.");
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
    }
}
