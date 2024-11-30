using team_project.Models;
namespace team_project.Services
{
    public class AccountService
    {
        private static List<Account> _accounts = new List<Account>
        {
            new Account { Id = 1, Username = "admin", Password = "password123" }
        };

        public string ValidateAccount(string username, string password)
        {
            bool accountMatch = _accounts.Any( account => account.Username == username && account.Password == password);
            if (accountMatch) 
            {
                return "Login Successfull"; // Returns true if the account credentials are valid
            }
            else 
            {
                return "Login failed: Wrong credentials"; // Retruns false if the accound credentials do not match or they do not exist
            }
        }

        public string CreateAccount(string username, string password)
        {
            bool accountMatch = _accounts.Any( account => account.Username == username && account.Password == password);
            if(accountMatch) {
                
                return "This account already exists. Login.";
            }
            else{
                Account accountData = new Account { Id = _accounts.Count() + 1, Username = username, Password = password};
                 _accounts.Add(accountData );

                return "Your account have been successfully created.";
            }
           
        }

        public string DeleteAccount(string username, string password)
        {
            Account? accountMatch = _accounts.Find(account => account.Username == username && account.Password == password);
            if(accountMatch != null) 
            {
                _accounts.Remove(accountMatch);
                return "Account successfully deleted";
            }
            else 
            {
                return "You cannot delete this account either because it either does not belong to you or the account credentials are wrong/invalid.";
            }
        }

       public Account? GetAccount(string username, string password)
        {
            Account? accountData = _accounts.Find(account => account.Username == username && account.Password == password);
            
            if (accountData != null) 
            {
                Console.WriteLine("Login Successfull");
                return accountData;
            }
            else 
            {
                Console.WriteLine("No matching account found");
                return null;
            }
        }

    }
}