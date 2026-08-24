using Microsoft.AspNetCore.Mvc;

namespace BoardingKennelBookings.Components.Models
{
    public class OwnersSearcnModel
    {


        [BindProperty(SupportsGet = true)]
        public string? SearchOwnerNameString { get; set; }
    }
}
