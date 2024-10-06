using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomeTask.DataAccess.DatabaseContexts;
using HomeTask.DataAccess.Entities;
using HomeTask.DataAccess.Repositories.Interfaces;

namespace HomeTask.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public UserEntity? GetUser(string username)
        {
            return _context.Users
                .AsNoTracking()
                .FirstOrDefault(x => x.Username == username);
        }
        
        public async Task<UserEntity?> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            return await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Username == username, cancellationToken);
        }

        public async Task AddUserAsync(UserEntity user, CancellationToken cancellationToken)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
            _context.Entry(user).State = EntityState.Detached;
        }

        public void UpdateUser(UserEntity user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Entry(user).State = EntityState.Detached;
        }
    }
}