using RTOG.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTOG.Business.Interfaces
{
    public interface IAccountService
    {
        public Task<Account> Create(Account newAccount);
        public Task<Account> CreateGuest(string username);
    }
}
