namespace QuickSellAdmin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vipDetail
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AddPlaced { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Contact1 { get; set; }

        public string Contact2 { get; set; }

        public string MainCategory { get; set; }

        public string SubCategory { get; set; }

        public byte[] Img1 { get; set; }

        public byte[] Img2 { get; set; }

        public byte[] Img3 { get; set; }

        public byte[] Img4 { get; set; }

        public byte[] Img5 { get; set; }

        public string ShortCode { get; set; }

        public string Brand { get; set; }

        public string ModelYear { get; set; }

        public string Model { get; set; }

        public string EngineCapacity { get; set; }

        public string Mileage { get; set; }

        public string Condition { get; set; }

        public bool Negotiable { get; set; }

        public bool Status { get; set; }

        public int UserID { get; set; }
    }
}
