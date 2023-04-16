using Microsoft.EntityFrameworkCore;
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

            var factions = _dbContext.FactionChoices.ToList();
            var randomIndexF = new Random().Next(0, factions.Count);
            var randomFaction = factions[randomIndexF];

            var newGuest = new Account()
            {
                Username = username,
                IsGuest = true,
                LastActive = DateTime.Now,
                SessionID = Helpers.GetRandomString(),
                SessionDuration = TimeSpan.FromHours(1),
                Player = null,
                SelectedColor = randomColor,
                SelectedFaction= randomFaction

            };

            _dbContext.Accounts.Add(newGuest);
            await _dbContext.SaveChangesAsync();

            return newGuest;
        }

        public async Task<Account> Get(int accountID)
        {
            var account = await _dbContext.Accounts.Where(a => a.ID == accountID)
                                                   .Include(a => a.Player)
                                                   .Include(a => a.SelectedFaction)
                                                   .FirstOrDefaultAsync();
            if (account is null)
                throw new Exception("Account not found");//todo:bljak static string
            return account;
        }

        public async Task<Account> UpdateColor(int accountID, int lobbyID, PlayerColor color)
        {
            var lobby = await _dbContext.Lobbies.Where(l => l.ID == lobbyID)
                                                .Include(l => l.Host)
                                                .ThenInclude(p => p.SelectedColor)
                                                .Include(l => l.Players)
                                                .ThenInclude(p => p.SelectedColor)
                                                .FirstOrDefaultAsync();

            var lobbyPlayers = lobby.Players.Where(p => p.SelectedColor.ID == color.ID && p.ID != accountID);

            if (accountID != lobby.Host.ID && lobby.Host.SelectedColor.ID == color.ID)
                throw new Exception("Color already selected by another member.");

            if (lobbyPlayers.Count() > 0)
                throw new Exception("Color already selected by another member.");

            var account = await Get(accountID);
            account.SelectedColor = color;
            await _dbContext.SaveChangesAsync();
            return account;
        }
        public async Task<Account> UpdateFaction(int accountID, FactionChoice choice)
        {
            var account = await Get(accountID);
            account.SelectedFaction = choice;
            await _dbContext.SaveChangesAsync();
            return account;
        }
    }
}
