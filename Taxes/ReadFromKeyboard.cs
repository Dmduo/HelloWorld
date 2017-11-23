using System;
using System.Collections.Generic;
using Taxes.Controllers;
using Taxes.Models;

namespace Taxes
{
    class InputReader
    {
        private readonly DoubleController _doubleController;
        private readonly CountryController _countryController;

        public InputReader(DoubleController doubleController, CountryController countryController)
        {
            _doubleController = doubleController;
            _countryController = countryController;
        }

        public UserInfo ReadInput(List<Tax> taxList)
        {
            var userInfo = new UserInfo();

            Console.WriteLine("Inserisci le ore lavorate: ");
            userInfo.HoursWorked = _doubleController.Controller();
            Console.WriteLine("Inserisci il costo orario: ");
            userInfo.HourlyFee = _doubleController.Controller();
            Console.WriteLine("Inserisci la locazione dell'impiegato: ");
            userInfo.WorkersLocation = Console.ReadLine();
            userInfo.WorkersLocation = userInfo.WorkersLocation.ToLower();

            userInfo.WorkersLocation = _countryController.ControlExistence(taxList, userInfo.WorkersLocation);
           
            return userInfo;

            
        }
    }
}
