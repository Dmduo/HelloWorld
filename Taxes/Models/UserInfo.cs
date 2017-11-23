namespace Taxes.Models
{
    //POCO Plain Old Clr Object
    public class UserInfo
    {
        public double HoursWorked { get; set; }
        public double HourlyFee { get; set; }                                 //The User needs to input this information
        public string WorkersLocation { get; set; }
        public string Benefits { get; set;}
        public string NothingToSee {get;set;} 
    }
}
