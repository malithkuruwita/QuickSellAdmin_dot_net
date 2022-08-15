using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickSellAdmin.ListModels
{
    public class vipdate
    {
        public int Id { get; set; }

        public string Title { get; set; }

        
        public string AddPlaced { get; set; }

        
        public string EndDate { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Contact1 { get; set; }

        public string Contact2 { get; set; }

        public string MainCategory { get; set; }

        public string SubCategory { get; set; }

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