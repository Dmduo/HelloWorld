namespace Taxes.Models
{
    public class Tax
    {
        public double Gross { get; set; }                                           //I need to calculate this value by multiplying oreLavorate and costoOrario

        public double Net { get; set; }                                            //I need to calculate this value by extracting all the taxes from my lordo

        public string Country { get; set; }
        public double IncomeTax { get; set; }
        public double Inps { get; set; }                                            //The 5 main variables one is the country where the taxes need to be calculated 
        public double Pension { get; set; }                                        //The other 4 variables are the main 4 taxes that we need to verify are present in
        public double UniversalSocialCharge { get; set; }                          //the selected country.

        public double IncomeTaxPercentageAfterLimit { get; set; }                                  //Optional variables not needed in order to calculate our main variables
        public double IncomeTaxLimit { get; set; }                                //This variables establish the limit after which our tax rate need to go up
        public double UniversalSocialChargePercentageAfterLimit { get; set; }                             //by a certain percentage
        public double UniversalSocialChargeLimit { get; set; }
    }
}
