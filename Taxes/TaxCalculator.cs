using System;
using System.Collections.Generic;
using Taxes.Models;

namespace Taxes
{
    public class TaxCalculator : Tax
    {
        private readonly TaxToDisplay _taxToDisplay;

        public TaxCalculator(TaxToDisplay taxToDisplay)
        {
            _taxToDisplay = taxToDisplay;
        }

        public TaxToDisplay CalculateTax(List<Tax> taxList, UserInfo userInfo)
        {
            if (taxList == null)
            {
                throw new ArgumentNullException(nameof(taxList));
            }

            CalculateGross(userInfo.HourlyFee,userInfo.HoursWorked);

            foreach (var tax in taxList)
            {
                if (userInfo.WorkersLocation == tax.Country)
                {
                    _taxToDisplay.IncomeTaxToDisplay = VerifyWhatTaxCalcIsNeeded(tax.IncomeTax, tax.IncomeTaxLimit, tax.IncomeTaxPercentageAfterLimit);

                    _taxToDisplay.UniversalSocialChargeToDisplay = VerifyWhatTaxCalcIsNeeded(tax.UniversalSocialCharge,
                        tax.IncomeTaxLimit, tax.UniversalSocialChargePercentageAfterLimit);

                    _taxToDisplay.InpsToDisplay = VerifyWhatTaxCalcIsNeeded(tax.Inps);

                    _taxToDisplay.PensionToDisplay = VerifyWhatTaxCalcIsNeeded(tax.Pension);

                    _taxToDisplay.NetToDisplay = CalculateNet();
                }
            }
            return _taxToDisplay;

        }
        double VerifyWhatTaxCalcIsNeeded(double baseTax = 0, double limit = 0, double overTax = 0)
        {
            if (limit == 0 || baseTax == 0 || overTax == 0)
            {
                return BasicTaxCalculation(baseTax);
            }
            else
            {
                return TaxCalculationWithLimit(baseTax, limit, overTax);
            }
        }

        double BasicTaxCalculation(double baseTax)
        {
            return (baseTax / 100) * _taxToDisplay.GrossToDisplay;
        }

        double TaxCalculationWithLimit(double baseTax, double limit, double overTax)
        {
            if (limit >= _taxToDisplay.GrossToDisplay)
            {
                return BasicTaxCalculation(baseTax);
            }
            else
            {
                var overtaxme = _taxToDisplay.GrossToDisplay - limit;
                return ((baseTax / 100) * limit) + ((overTax / 100) * overtaxme);
            }
        }
        double CalculateNet()
        {
            return _taxToDisplay.GrossToDisplay - _taxToDisplay.IncomeTaxToDisplay
                        - _taxToDisplay.UniversalSocialChargeToDisplay - _taxToDisplay.InpsToDisplay - _taxToDisplay.PensionToDisplay;
        }
        void CalculateGross(double hourlyFee,double hoursWorked)
        {
            _taxToDisplay.GrossToDisplay = hourlyFee * hoursWorked;

        }
    }
}
