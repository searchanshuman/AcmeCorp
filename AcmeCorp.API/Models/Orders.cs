using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AcmeCorp.API.Models
{
    public partial class Orders
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public int CustomerId { get; set; }
        public double Total { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
