namespace BoardingKennelBookings.Components.Helpers
{
    public class DateHelper
    {
        public static bool IsValidDateRange(DateTime startDate, DateTime endDate)
        {
            return startDate < endDate;
        }
    }
}
