using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.DTOs;
using DatingApp.Entites;
using DatingApp.EntityFramework;
using DatingApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatingAppContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DatingAppContext datingAppContext, IMapper mapper)
        {
            _context = datingAppContext;
            _mapper = mapper;
        }
        public async Task<MemberDTO> GetUserByIdAsync(int id)
        {
            return await _context.Users
                .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(user => user.ID == id);
        }

        public async Task<AppUser> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users
                .Include(user => user.Photos)
                .SingleOrDefaultAsync(user => user.UserName.ToLower().Trim() == userName.ToLower().Trim());
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _context.Users
                .Include(user => user.Photos)
                .ToListAsync();
        }

        public async Task<IEnumerable<MemberDTO>> GetUsersV2Async()
        {
            return await _context.Users
                .ProjectTo<MemberDTO>(_mapper.ConfigurationProvider)
                .Take(10)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
            //await _context.SaveChangesAsync();
        }
    }
}
