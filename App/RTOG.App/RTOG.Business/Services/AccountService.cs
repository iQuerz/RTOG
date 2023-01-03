using RTOG.Business.Infrastructure;
using RTOG.Business.Infrastructure.Messages;
using RTOG.Data.Models;
using RTOG.Data.Persistence;

namespace RTOG.Business.Services
{
    internal class AccountService
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

            newAccount.CreationDate = DateTime.Now;
            newAccount.SessionID = Helpers.GetRandomString();

            _dbContext.Accounts.Add(newAccount);
            await _dbContext.SaveChangesAsync();
        }
    }
}
