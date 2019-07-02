using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Entities
{
    public class User
    {
        String id { get; set; } 
        String Username {get; set;}
        String FirstName { get; set; }
        String LastName { get; set; }
        bool IsEnabled { get; set; }
        DateTimeOffset CreatedDateUtc { get; set; }
        DateTimeOffset LastLoggedInDateUtc { get; set; }
    }
}
