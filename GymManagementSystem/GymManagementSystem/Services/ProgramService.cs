using GymManagementSystem.DTO.RequestDTO;
using GymManagementSystem.DTO.Response_DTO;
using GymManagementSystem.Entities;
using GymManagementSystem.IRepositories;
using GymManagementSystem.IServices;

namespace GymManagementSystem.Services
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _programRepository;

        public ProgramService(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }
        public async Task<string> AddProgram(ProgramRequestDTO programRequestDTO)
        {
            WorkoutProgram program = new WorkoutProgram()
            {
                Name = programRequestDTO.Name,
                Description = programRequestDTO.Description,
                CreatedDate = DateTime.Now,
                Status = true
            };
            var data = await _programRepository.CreateProgram(program);
            foreach (var image in programRequestDTO.Images)
            {
                ProgramImages newimage = new ProgramImages()
                {
                    ImagePath = image.ImagePath,
                    alternative = image.alternative,
                    ProgramId = data.Id,
                    Program = data
                };
                var programImage = await _programRepository.CreateImage(newimage);
            }
            if (data is WorkoutProgram)
            {
                return "Program Added Successfully";
            }
            else
            {
                return "Try again";
            }
        }
        public async Task<List<ProgramResponseDTO>> GetAllPrograms()
        {
            List<ProgramResponseDTO> programResponses = new List<ProgramResponseDTO>();
            var data = await _programRepository.GetAllWorkoutProgram();
            foreach (var program in data)
            {
                var imageList = new List<ProgramImageResponseDTO>();
                List<SubscriptionResponseDTO> programSubscriptions = new List<SubscriptionResponseDTO>();
                foreach (var subscription in program.Subscriptions)
                {
                    var programPaymentList = await GetProgramPayments(subscription.Id, program.Id);
                    var subscriptionResponse = new SubscriptionResponseDTO()
                    {
                        Id = subscription.Id,
                        Name = subscription.Name,
                        Description = subscription.Description,
                        IsNewSubscription = (subscription.Date.Year == DateTime.Now.Year && subscription.Date.Month == DateTime.Now.Month) ? true : false,
                        IsSpecialOffer = subscription.IsSpecialOffer,
                        Duration = subscription.Duration,
                        Payments = programPaymentList
                    };
                    programSubscriptions.Add(subscriptionResponse);
                }

                foreach (var image in program.Images)
                {
                    var imageResponseDTO = new ProgramImageResponseDTO(image.ImagePath, image.alternative);
                    imageList.Add(imageResponseDTO);
                }
                ProgramResponseDTO response = new ProgramResponseDTO()
                {

                    Id = program.Id,
                    Name = program.Name,
                    Description = program.Description,
                    Images = imageList,
                    Subscriptions = programSubscriptions
                };
                programResponses.Add(response);
            }
            return programResponses;
        }
        public async Task<ProgramResponseDTO> GetSingleProgram(Guid Id)
        {
            var data = await _programRepository.GetWorkoutProgram(Id);

            var imageList = new List<ProgramImageResponseDTO>();
            List<SubscriptionResponseDTO> programSubscriptions = new List<SubscriptionResponseDTO>();
            foreach (var subscription in data.Subscriptions)
            {
                var programPaymentList = await GetProgramPayments(subscription.Id, data.Id);
                var subscriptionResponse = new SubscriptionResponseDTO()
                {
                    Id = subscription.Id,
                    Name = subscription.Name,
                    Description = subscription.Description,
                    IsNewSubscription = (subscription.Date.Year == DateTime.Now.Year && subscription.Date.Month == DateTime.Now.Month) ? true : false,
                    IsSpecialOffer = subscription.IsSpecialOffer,
                    Duration = subscription.Duration,
                    Payments = programPaymentList
                };
                programSubscriptions.Add(subscriptionResponse);
            }
            foreach (var image in data.Images)
            {
                var imageResponseDTO = new ProgramImageResponseDTO(image.ImagePath, image.alternative);
                imageList.Add(imageResponseDTO);
            }
            ProgramResponseDTO response = new ProgramResponseDTO()
            {
                Id = data.Id,
                Name = data.Name,
                Description = data.Description,
                Images = imageList,
                Subscriptions = programSubscriptions
            };
            return response;
        }
        public async Task<string> DeleteProgram(Guid id)
        {
            var data =await _programRepository.GetWorkoutProgram(id);
            data.Status=false;
            var updatedProgram=await _programRepository.UpdateProgram(data);
            if (updatedProgram is WorkoutProgram)
            {
                return "Program is deleted successfully";
            }
            else
            {
                return "Try Again";
            }
        }
        public async Task<string> UpdateProgram(Guid id,ProgramRequestDTO programRequestDTO)
        {
            var data = await _programRepository.GetWorkoutProgram(id);
            data.Name = programRequestDTO.Name;
            data.Description = programRequestDTO.Description;
            var updatedProgram = await _programRepository.UpdateProgram(data);
            if (updatedProgram is WorkoutProgram)
            {
                return "Program is Updated successfully";
            }
            else
            {
                return "Try Again";
            }
        }
        public async Task<string> UpdateProgramPayment(Guid id,decimal Amount)
        {
            var data=await _programRepository.GetProgramPayment(id);
            data.Status = false;
            var deletePayment=await _programRepository.UpdateProgramPayment(data);
            var newPayment = new ProgramPayment()
            {
                Amount = Amount,
                ProgramId = data.ProgramId,
                SubscriptionPaymentId = data.SubscriptionPaymentId,
                Program = data.Program,
                SubscriptionPayment = data.SubscriptionPayment
            };
            var programPayment =await _programRepository.CreateProgramPayment(newPayment);
            if (programPayment is ProgramPayment)
            {
                return "Program Payment is Updated successfully";
            }
            else
            {
                return "Try Again";
            }
        }

        public async Task<List<ProgramPaymentResponseDTO>> GetProgramPayments(Guid SubscriptionId, Guid ProgramId)
        {
            var data = await _programRepository.GetSubscription(SubscriptionId);
            var programPaymentList = new List<ProgramPaymentResponseDTO>();
            foreach (var paymentType in data.SubscriptionPayments)
            {
                var programPayment = await _programRepository.GetProgramPayment(ProgramId, paymentType.Id);
                ProgramPaymentResponseDTO responseDTO = new ProgramPaymentResponseDTO()
                {
                    Id = programPayment.Id,
                    Amount = programPayment.Amount,
                    PaymentType = paymentType.PaymentType
                };
                programPaymentList.Add(responseDTO);
            }
            return programPaymentList;
        }
    }
}
