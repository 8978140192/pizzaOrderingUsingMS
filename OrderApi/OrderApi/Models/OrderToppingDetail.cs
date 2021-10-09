using System;
using System.Collections.Generic;

#nullable disable

namespace OrderApi.Models
{
    public partial class OrderToppingDetail
    {
        public int ItemId { get; set; }
        public string ToppingId { get; set; }

        public virtual OrderDetail Item { get; set; }
    }
}
