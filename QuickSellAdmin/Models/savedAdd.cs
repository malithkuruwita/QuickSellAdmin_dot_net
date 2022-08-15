namespace QuickSellAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class savedAdd
    {
        public int Id { get; set; }

        public int AddID { get; set; }

        public int UseriD { get; set; }
    }
}
