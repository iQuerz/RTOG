using RTOG.Business.Infrastructure;
using RTOG.Business.Infrastructure.Messages;
using RTOG.Data.Models;
using RTOG.Data.Persistence;

namespace RTOG.Business.Services
{
    public class AccountService
    {
        private readonly AppDbContext _dbContext;
        public AccountService(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task Create(Account newAccount)
        {
            if (newAccount.IsGuest == false)
            {
                var accSameUsername = _dbContext.Accounts.Where(a => a.Username == newAccount.Username).FirstOrDefault();
                if (accSameUsername is not null)
                    throw new Exception(Messages.UsernameExists);
            }

            newAccount.LastActive = DateTime.Now;
            newAccount.SessionID = Helpers.GetRandomString();

            _dbContext.Accounts.Add(newAccount);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Account> CreateGuest(string username)
        {
            var newGuest = new Account()
            {
                Username = username,
                IsGuest = true,
                LastActive = DateTime.Now,
                SessionID = Helpers.GetRandomString()
            };

            _dbContext.Accounts.Add(newGuest);
            await _dbContext.SaveChangesAsync();

            return newGuest;
        }
    }
}
