namespace BoardingKennelBookings.Components.Helpers
{
    public class DateHelper
    {
        public static bool IsValidDateRange(DateTime startDate, DateTime endDate)
        {
            Console.WriteLine($"startd {startDate} enddate {endDate} is start lesser? {startDate < endDate}");

            return startDate < endDate;
        }
    }
}
