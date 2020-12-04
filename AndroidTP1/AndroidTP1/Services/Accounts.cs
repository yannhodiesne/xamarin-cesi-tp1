using System.Collections.Generic;
using System.Linq;
using AndroidTP1.Models;

namespace AndroidTP1.Services
{
    public static class Accounts
    {
        private static List<Account> DbMock { get; } = new List<Account>();

        public static List<Account> AllAccounts => new List<Account>(DbMock);

        public static AccountsResponse Add(Account account)
        {
            if (DbMock.Any(a => a.Login == account.Login))
                return new AccountsResponse("Cet identifiant est déjà utilisé");

            if (DbMock.Any(a => a.Name == account.Name))
                return new AccountsResponse("Ce nom d'utilisateur est déjà utilisé");

            DbMock.Add(account);
            return new AccountsResponse(account);
        }

        public static AccountsResponse Remove(string login)
        {
            var account = DbMock.FirstOrDefault(a => a.Login == login);

            if (account == null)
                return new AccountsResponse("Impossible de trouver cet utilisateur");

            DbMock.Remove(account);
            return new AccountsResponse(account);
        }

        public static AccountsResponse Login(string login, string password)
        {
            var account = DbMock.FirstOrDefault(a => a.Login == login);

            if (account == null)
                return new AccountsResponse("Impossible de trouver cet utilisateur");

            if (account.Password != password)
                return new AccountsResponse("Le mot de passe est invalide");

            return new AccountsResponse(account);
        }
    }

    public class AccountsResponse
    {
        public bool Success => Account != null;
        public string Message { get; }
        public Account Account { get; }

        public AccountsResponse(string message)
        {
            Message = message;
        }

        public AccountsResponse(Account account)
        {
            Account = account;
        }
    }
}
