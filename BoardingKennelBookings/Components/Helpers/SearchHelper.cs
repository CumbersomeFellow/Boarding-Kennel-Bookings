using Microsoft.AspNetCore.Components;

namespace BoardingKennelBookings.Components.Helpers
{
    public class SearchHelper
    {
        public static List<T> Search<T>(string searchedTerm, List<T> searchList, Func<T, string> nameSelector)
        {
            List<T> result = new List<T>();

            foreach (var item in searchList) { 
                if (nameSelector(item).ToLower().Contains(searchedTerm.ToLower()))
                {
                    result.Add(item);
                }             
            }

            return result;
        }

        public static string CombineFirstLastName(string firstname, string lastname) { 
            return firstname + " " + lastname;
        }
    }
}
