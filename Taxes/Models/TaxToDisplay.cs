using System.Collections.Generic;

namespace Taxes.Models
{
    public class TaxToDisplay
    {
        public double GrossToDisplay { get; set; }                                           

        public double NetToDisplay { get; set; }                                            
        
        public double IncomeTaxToDisplay { get; set; }
        public double InpsToDisplay { get; set; }                                             
        public double PensionToDisplay { get; set; }                                        
        public double UniversalSocialChargeToDisplay { get; set; }
    }
}
