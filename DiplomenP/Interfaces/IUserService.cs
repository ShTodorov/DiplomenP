using DiplomenP.Models;

namespace DiplomenP.Interfaces
{
    public interface IUserService
    {
        /*

        Task<string> CreateApplicationUser(User user, String Password);
        Task<string> DeleteApplicationUser(User user);
        List<User> GetAllUsers();
        Task<User> GetApplicationUserByIdAsync(string Id);
        Task<User> GetApplicationUserByUsernameAsync(string Username);
        Task UpdateApplicationUser(User user);
        
        bool IsLoggedUserAdmin();
        void Login(string username, string password, bool rememberMe);
        void Logout();
        Task AddRoleAsync(User user, string role);
        Task RemoveRoleAsync(User user, string role);
        Task<IList<string>> GetRoleAsync(User user);

        */
        string? GetLoggedUserId();
    }
}
