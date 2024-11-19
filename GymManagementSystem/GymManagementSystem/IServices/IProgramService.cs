using GymManagementSystem.DTO.RequestDTO;
using GymManagementSystem.DTO.Response_DTO;

namespace GymManagementSystem.IServices
{
    public interface IProgramService
    {
        Task<string> UpdateProgramPayment(Guid id, decimal Amount);
        Task<string> UpdateProgram(Guid id, ProgramRequestDTO programRequestDTO);
        Task<string> DeleteProgram(Guid id);
        Task<ProgramResponseDTO> GetSingleProgram(Guid Id);
        Task<List<ProgramResponseDTO>> GetAllPrograms();
        Task<string> AddProgram(ProgramRequestDTO programRequestDTO);
    }
}
