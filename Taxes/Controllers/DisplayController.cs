using System;

namespace Taxes.Controllers
{
    class DisplayController
    {
        public void VerifyDisplay(string message, double taxToDisplay)
        {
            if (taxToDisplay != 0)
            {
                Console.WriteLine($"{message} €{taxToDisplay} ");
            }
        }
    }
}
