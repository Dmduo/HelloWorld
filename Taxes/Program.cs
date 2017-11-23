using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Taxes.Controllers;
using Taxes.Models;

namespace Taxes

{
    public class Program
    {
        public Program()
        {
        }
        static void Main(string[] args)
        {
            
            IReader reader = new ExcelReader();

            var taxList = new List<Tax>();

            var userInfo = new UserInfo();
            var taxToDisplay = new TaxToDisplay();
            var countryController = new CountryController();
            var inputReader = new InputReader(new DoubleController(), new CountryController());
            var taxCalculator = new TaxCalculator(new TaxToDisplay());
            var displayManager = new DisplayManager(new DisplayController());

            try
            {
                taxList = reader.Open();
            }
            catch(COMException ex)
            {
                displayManager.DisplayFatalError(ex.Message);
            }

            userInfo = inputReader.ReadInput(taxList);
            taxToDisplay = taxCalculator.CalculateTax(taxList, userInfo);
            displayManager.DisplayFinalOutput(taxToDisplay);

            Console.ReadLine();
        }
    }
}