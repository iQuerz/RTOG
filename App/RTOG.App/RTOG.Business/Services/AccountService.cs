using RTOG.Business.Infrastructure;
using RTOG.Business.Infrastructure.Messages;
using RTOG.Business.Interfaces;
using RTOG.Data.Models;
using RTOG.Data.Persistence;

namespace RTOG.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _dbContext;
        public AccountService(AppDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Account> Create(Account newAccount)
        {
            newAccount.IsGuest = false;
            newAccount.LastActive = DateTime.Now;
            newAccount.SessionID = Helpers.GetRandomString();

            _dbContext.Accounts.Add(newAccount);
            await _dbContext.SaveChangesAsync();

            return newAccount;
        }

        public async Task<Account> CreateGuest(string username)
        {
            var colors = _dbContext.PlayerColors.ToList();
            var randomIndex = new Random().Next(0, colors.Count);
            var randomColor = colors[randomIndex];

            var newGuest = new Account()
            {
                Username = username,
                IsGuest = true,
                LastActive = DateTime.Now,
                SessionID = Helpers.GetRandomString(),
                SessionDuration = TimeSpan.FromHours(1),
                Player = null,
                SelectedColor = randomColor
            };

            _dbContext.Accounts.Add(newGuest);
            await _dbContext.SaveChangesAsync();

            return newGuest;
        }

        public async Task<Account> Get(int accountID)
        {
            var account = await _dbContext.Accounts.FindAsync(accountID);
            if (account is null)
                throw new Exception("Account not found");//todo:bljak static string
            return account;
        }

        public async Task<Account> UpdateColor(int accountID, PlayerColor color)
        {
            var account = await Get(accountID);
            account.SelectedColor = color;
            await _dbContext.SaveChangesAsync();
            return account;
        }
    }
}
