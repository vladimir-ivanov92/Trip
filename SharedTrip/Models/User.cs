using SIS.MvcFramework;
using System;
using System.Collections.Generic;

namespace SharedTrip.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.UserTrips = new HashSet<UserTrip>();
            Id = Guid.NewGuid().ToString();
        }
     
        public virtual ICollection<UserTrip> UserTrips { get; set; }
    }
}
