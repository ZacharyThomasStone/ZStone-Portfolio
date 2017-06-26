using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        string path = @"C:\Data\SGBank\Accounts.txt";
        


        public Account LoadAccount(string AccountNumber)
        {
            if(!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {

                       
                    string[] fields = line.Split(',');
                    if (fields[0] == AccountNumber)
                    {
                        Account tempAccount = new Account();
                        tempAccount.AccountNumber = fields[0];
                        tempAccount.Name = fields[1];
                        tempAccount.Balance = decimal.Parse(fields[2]);

                        switch (fields[3])
                        {
                            case "F":
                                tempAccount.Type = AccountType.Free;
                                break;
                            case "B":
                                tempAccount.Type = AccountType.Basic;
                                break;
                            case "P":
                                tempAccount.Type = AccountType.Premium;
                                break;
                        }
                        return tempAccount;

                    }
                    
                }
              
                
            }
            return null;
        }
        //Load file into a list of accounts
        //Loop through accounts, find (if account == one i am saving)
        //if found change the account information to == the same account info we passed in. 

        //Loop through it again, but save it to txt file. Use streamwrite 
        public void SaveAccount(Account account)
        {
            List<Account> accounts = new List<Account>();
            //Load file into a list of accounts
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {


                    string[] fields = line.Split(',');
                    if (fields[0] == account.AccountNumber)
                    {
                        Account tempAccount = new Account();
                        tempAccount.AccountNumber = fields[0];
                        tempAccount.Name = fields[1];
                        tempAccount.Balance = decimal.Parse(fields[2]);

                        switch (fields[3])
                        {
                            case "F":
                                tempAccount.Type = AccountType.Free;
                                break;
                            case "B":
                                tempAccount.Type = AccountType.Basic;
                                break;
                            case "P":
                                tempAccount.Type = AccountType.Premium;
                                break;
                        }
                        accounts.Add(tempAccount);
                        
                        //Loop through accounts, find (if account == one i am saving)
                        foreach(var specificAccount in accounts)
                        {
                            if (specificAccount == account)
                            {
                                tempAccount = account;

                            }

                        }
                
                    }

                }
                reader.Close();
                //successfuly writes to txt file, but appends at the bottom for account and leaves old account info. 
            
                    string type;
                    

                    
                    switch(account.Type)
                    {
                        case AccountType.Basic:
                            type = "B";
                            var allLines = File.ReadAllLines(path);
                            allLines[2] = ($"{account.AccountNumber},{account.Name},{account.Balance},{type}");
                            File.WriteAllLines(path, allLines);
                            break;
                        case AccountType.Free:
                            type = "F";
                            allLines = File.ReadAllLines(path);
                            allLines[1] = ($"{account.AccountNumber},{account.Name},{account.Balance},{type}");
                            File.WriteAllLines(path, allLines);
                            break;
                        case AccountType.Premium:
                            type = "P";
                            allLines = File.ReadAllLines(path);
                            allLines[3] = ($"{account.AccountNumber},{account.Name},{account.Balance},{type}");
                            File.WriteAllLines(path, allLines);
                            break;
                    

                    }
                  

                

            }
      
        }


    }

    
}

