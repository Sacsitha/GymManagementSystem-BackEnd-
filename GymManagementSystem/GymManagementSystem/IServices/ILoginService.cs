namespace GymManagementSystem.IServices
{
    public interface ILoginService
    {
        Task<string> Login(string Id, string password);
    }
}
