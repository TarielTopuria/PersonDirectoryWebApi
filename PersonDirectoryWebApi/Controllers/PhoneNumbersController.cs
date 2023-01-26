using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonDirectoryWebApi.Entities;
using PersonDirectoryWebApi.Models.PhoneNumberModels;
using PersonDirectoryWebApi.Repositories.Abstraction.IRepositories;
using PersonDirectoryWebApi.Requests.PhoneNumberRequests;

namespace PersonDirectoryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumbersController : ControllerBase
    {
        private readonly ILogger<PhoneNumbersController> _logger;
        private readonly IPhoneNumbersInfoRepository _phoneNumbersInfoRepository;
        private readonly IMapper _mapper;

        public PhoneNumbersController(ILogger<PhoneNumbersController> logger, IPhoneNumbersInfoRepository phoneNumbersInfoRepository, IMapper mapper)
        {
            _logger = logger;
            _phoneNumbersInfoRepository = phoneNumbersInfoRepository;
            _mapper = mapper;
        }

        [HttpGet("{phoneNumberId}", Name = "GetPhoneNumber")]
        public async Task<ActionResult<PhoneNumbersDto>> GetPhoneNumber(int personId, int phoneNumberId)
        {
            try
            {
                if (!await _phoneNumbersInfoRepository.CheckPersonAsync(personId))
                {
                    _logger.LogInformation($"Person with id {personId} wasn't found when accessing database.");
                    return NotFound();
                }

                var phoneNumber = await _phoneNumbersInfoRepository.GetPhoneNumberAsync(personId, phoneNumberId);

                if (phoneNumber == null)
                {
                    _logger.LogInformation($"PhoneNumber with id {phoneNumberId} wasn't found when accessing database.");
                    return NotFound();
                }

                return Ok(_mapper.Map<PhoneNumbersDto>(phoneNumber));
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use GET Method to get info about phone numbers. See the message: {e.Message}");
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<PhoneNumbersDto>> CreatePhoneNumber(int personId, CreatePhoneNumbersRequestDto phoneNumber)
        {
            try
            {
                if (!await _phoneNumbersInfoRepository.CheckPersonAsync(personId))
                {
                    _logger.LogInformation($"Person with id {personId} wasn't found when accessing database.");
                    return NotFound();
                }

                var finalPhoneNumber = _mapper.Map<PhoneNumber>(phoneNumber);

                await _phoneNumbersInfoRepository.AddPhoneNumber(personId, finalPhoneNumber);
                await _phoneNumbersInfoRepository.SaveChangesAsync();

                var createdPhoneNumberToReturn = _mapper.Map<PhoneNumbersDto>(finalPhoneNumber);

                return CreatedAtRoute("GetPhoneNumber",
                    new
                    {
                        personId = personId,
                        phoneNumberId = createdPhoneNumberToReturn.Id
                    },
                    createdPhoneNumberToReturn);
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use Post Method to create Phone Number on Person with Id {personId}. See the message: {e.Message}");
                throw;
            }
        }

        [HttpDelete("{phoneNumberId}")]
        public async Task<ActionResult> DeletePhoneNumber(int personId, int phoneNumberId)
        {
            try
            {
                if (!await _phoneNumbersInfoRepository.CheckPersonAsync(personId))
                {
                    _logger.LogInformation($"Person with id {personId} wasn't found when accessing database.");
                    return NotFound();
                }

                var phoneNumber = await _phoneNumbersInfoRepository.GetPhoneNumberAsync(personId, phoneNumberId);
                if (phoneNumber == null)
                {
                    _logger.LogInformation($"'Person' with ID {personId} who would have a number with ID {phoneNumberId} wasn't found when accessing database.");
                    return NotFound();
                }

                _phoneNumbersInfoRepository.DeletePhoneNumber(phoneNumber);
                await _phoneNumbersInfoRepository.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError($"Problem occured while trying to use Delete Method to delete phone number with Id {phoneNumberId} which will be number of a person with Id {personId}. See the message: {e.Message}");
                throw;
            }

        }

        [HttpPut("{phoneNumberId}")]
        public async Task<ActionResult> UpdatePhoneNumber (int personId, int phoneNumberId, UpdatePhoneNumberRequestDto phoneNumber)
        {
            if(!await _phoneNumbersInfoRepository.CheckPersonAsync(personId))
            {
                _logger.LogInformation($"Person with id {personId} wasn't found when accessing database.");
                return NotFound();
            }

            var phoneNumberEntity = await _phoneNumbersInfoRepository.GetPhoneNumberAsync(personId, phoneNumberId);
            if(phoneNumberEntity == null)
            {
                _logger.LogInformation($"Person with id {personId} who would have phone number with Id {phoneNumberId} wasn't found when accessing database.");
                return NotFound();
            }

            _mapper.Map(phoneNumber, phoneNumberEntity);

            await _phoneNumbersInfoRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
