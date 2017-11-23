using System;
using System.Collections.Generic;
using Taxes.Models;

namespace Taxes.Controllers
{
    class CountryController
    {
        public string ControlExistence(List<Tax> taxList, string userCountry)
        {
            var valid = 0;

            do
            {
                foreach (Tax tax in taxList)
                {
                    if (userCountry == tax.Country)
                    {
                        ++valid;
                    }
                }
                if (valid == 0)
                {
                    Console.WriteLine("Errore di inserimento: il paese inserito non esiste.\nInseriri nuovamente il paese.");
                    userCountry = Console.ReadLine();
                }
            } while (valid==0);

            return userCountry;
        }
    }
}
