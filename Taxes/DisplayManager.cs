using System;
using Taxes.Models;
using Taxes.Controllers;

namespace Taxes
{
    class DisplayManager
    {
        private readonly DisplayController _displayController;     

        public DisplayManager(DisplayController displayController)
        {
            _displayController = displayController;
          
        }
        public void DisplayFinalOutput(TaxToDisplay taxToDisplay)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine($"\nAmmontare lordo: €{taxToDisplay.GrossToDisplay}");
            Console.WriteLine("\nMeno detrazioni: \n");
            _displayController.VerifyDisplay(Constants.Messages.IncomeTaxMessage, taxToDisplay.IncomeTaxToDisplay);
            _displayController.VerifyDisplay(Constants.Messages.UniversalSocialChargeMessage, taxToDisplay.UniversalSocialChargeToDisplay);
            _displayController.VerifyDisplay(Constants.Messages.PensionMessage, taxToDisplay.PensionToDisplay);
            _displayController.VerifyDisplay(Constants.Messages.InpsMessage, taxToDisplay.InpsToDisplay);
            Console.WriteLine($"Ammontare netto: €{taxToDisplay.NetToDisplay}");
        }
        public void DisplayFatalError(string error)
        {
            Console.WriteLine(error);
            Console.WriteLine("The program has encountered an error and needs to close");
            Console.ReadLine();
            Environment.Exit(1);
        }
        
    }
}
