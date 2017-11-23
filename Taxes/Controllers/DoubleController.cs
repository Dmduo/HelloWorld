using System;

namespace Taxes.Controllers
{
    class DoubleController
    {
        public double Controller()
        {
            var valid = false;
            var messageCounter = 0;
            double value;

            do
            {
                if (messageCounter == 0)
                {
                    valid = double.TryParse(Console.ReadLine(), out value);
                    ++messageCounter;
                }
                else
                {
                    
                    Console.WriteLine("Valore inserito invalido.Questo valore deve essere compostro solo da cifre.\nInserire un nuovo valore ");

                    valid = double.TryParse(Console.ReadLine(), out value);
                }
            } while (!valid);
            
            return value;
        }
        
    }
}
