using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiplomenP.Models;
using DiplomenP.Data;
using DiplomenP.Interfaces;

namespace DiplomenP.Services
{
    public class UserService : Controller, IUserService
    {

        private readonly ApplicationDbContext _context;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserStore<User> _userStore;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(ApplicationDbContext context, UserManager<User> userManager,
            IUserStore<User> userStore,
            SignInManager<User> signInManager,
            IEmailSender emailSender, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _httpContextAccessor = httpContextAccessor;
        }

        /*

        // Създаване на нов потребител
        public async Task<string> CreateApplicationUser(User user, String Password)
        {
            _context.DetachAllEntities();
            user.FirstName.Trim();
            user.LastName.Trim();
            // Използване на метода CreateAsync от UserManager за създаване на нов потребител
            IdentityResult result = await _userManager.CreateAsync(user, Password);
            // Отделяне на потребителя от локалния контекст

            if (!result.Succeeded)
            {
                // Връщане на първата грешка от резултата
                return result.Errors.ToList().First().Description;
            }
            else
            {
                _ = await _userManager.AddToRoleAsync(user, "User");
                // Успешно създаден потребител
                return "Успешно създаден потребител!";
            }
        }

        // Изтриване на потребител
        public async Task<string> DeleteApplicationUser(User user)
        {
            try
            {
                _context.DetachAllEntities();
                // Търсене на потребителя в локалния контекст
                User? local = _context.Set<User>()
                    .Local
                    .FirstOrDefault(entry => entry.Id.Equals(user.Id));

                // Проверка дали local не е null
                if (local != null)
                {
                    // Отделяне
                    _context.Entry(local).State = EntityState.Detached;
                }

                // Задаване на флаг за изтриване
                _context.Entry(user).State = EntityState.Deleted;

                // Запазване на промените
                _ = _context.SaveChanges();
                return "Успешно изтриване!";
            }
            catch (DbUpdateException)
            {
                return "Неуспешно изтриване, понеже потребителят е свързан с проект/задача!";
            }
            catch
            {
                return "Неуспешно изтриване!";
            }
        }

        // Връща списък с всички потребители
        public List<User> GetAllUsers()
        {
            List<User> users = _context.Users.AsNoTracking().ToList();
            return users;
        }

        // Връща един потребител по зададен Id
        public async Task<User> GetApplicationUserByIdAsync(string Id)
        {
            _context.DetachAllEntities();
            // Търси в локалната база данни за потребител с зададеното Id
            User? local = _context.Users.AsNoTracking().FirstOrDefault(entry => entry.Id.Equals(Id));

            return local;
        }

        public async Task<User> GetApplicationUserByUsernameAsync(string Username)
        {
            _context.DetachAllEntities();
            User? local = _context.Set<User>().Local.FirstOrDefault(entry => entry.UserName.Equals(Username));
            // check if local is not null
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            User user = _context.Users.Where(x => x.UserName == Username).AsNoTracking().FirstOrDefault();// await _userManager.FindByNameAsync(Username);
            return user;
        }

        public async Task UpdateApplicationUser(User user)
        {
            _context.DetachAllEntities();
            user.FirstName.Trim();
            user.LastName.Trim();
            User? local = _context.Set<User>().Local.FirstOrDefault(entry => entry.Id.Equals(user.Id));
            // check if local is not null
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            _context.Entry(user).State = EntityState.Modified;

            _ = _context.SaveChanges();

            if (user.Role == "Admin" && !await IsInRoleAsync(user, "Admin"))
            {
                if (await IsInRoleAsync(user, "User"))
                {
                    await RemoveRoleAsync(user, "User");
                }
                await AddRoleAsync(user, "Admin");
            }
            else if (user.Role == "User" && (await IsInRoleAsync(user, "Admin")))
            {
                if (await IsInRoleAsync(user, "Admin"))
                {
                    await RemoveRoleAsync(user, "Admin");
                }
                await AddRoleAsync(user, "User");
            }
        }


        public User GetLoggedUser()
        {
            _context.DetachAllEntities();
            using ApplicationDbContext context = _context.Clone();
            context.DetachAllEntities();
            User? user = context.Users.SingleOrDefault(x => x.UserName == _httpContextAccessor.HttpContext.User.Identity.Name);

            return user;

        }




        public bool IsLoggedUserAdmin()
        {


            return _httpContextAccessor.HttpContext.User.IsInRole("Admin");




        }

        public async void Login(string username, string password, bool rememberMe)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: true);
            if (!result.Succeeded)
            {
                // handle failed login attempt
            }
        }
        public void Logout()
        {
            _ = _signInManager.SignOutAsync();
        }

        public async Task AddRoleAsync(User user, string role)
        {
            _ = await _userManager.AddToRoleAsync(user, role);
        }

        public async Task RemoveRoleAsync(User user, string role)
        {
            _ = await _userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task<IList<string>> GetRoleAsync(User user)
        {

            return user != null ? await _userManager.GetRolesAsync(user) : new List<string>();
        }

        public async Task<bool> IsInRoleAsync(User user, string role)
        {
            return (await GetRoleAsync(user)).Contains(role);
        }

        */

        
    }
}
