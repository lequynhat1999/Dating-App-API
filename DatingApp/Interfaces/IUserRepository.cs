using DatingApp.DTOs;
using DatingApp.Entites;

namespace DatingApp.Interfaces
{
    public interface IUserRepository
    {
        Task<MemberDTO> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUserNameAsync(string userName);
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<IEnumerable<MemberDTO>> GetUsersV2Async();
        Task<bool> SaveAllAsync();
        Task Update(AppUser user);
    }
}
