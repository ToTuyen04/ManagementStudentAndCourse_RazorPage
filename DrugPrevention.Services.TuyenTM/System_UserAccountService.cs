using DrugPrevention.Repositories.TuyenTM;
using DrugPrevention.Repositories.TuyenTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.TuyenTM
{
    public class System_UserAccountService
    {
        private readonly System_UserAccountRepository _repository;
        public System_UserAccountService() => _repository ??= new System_UserAccountRepository();
        public async Task<System_UserAccount> GetUserAccount(string username, string password)
        {
            return await _repository.GetUserAccountAsync(username, password);
        }
    }
}
