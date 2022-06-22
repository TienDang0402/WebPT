namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public long ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public int? Quantity { get; set; }

        public long? CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public DateTime? CreateDate { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(100)]
        public string MetaKeywords { get; set; }

        [StringLength(100)]
        public string MetaDescriptions { get; set; }

        public bool? Status { get; set; }

        public DateTime? TopHot { get; set; }

        [StringLength(250)]
        public string Image2 { get; set; }

        [StringLength(250)]
        public string Image3 { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   ID == product.ID &&
                   Name == product.Name &&
                   Code == product.Code &&
                   MetaTitle == product.MetaTitle &&
                   Description == product.Description &&
                   Images == product.Images &&
                   MoreImage == product.MoreImage &&
                   Price == product.Price &&
                   PromotionPrice == product.PromotionPrice &&
                   Quantity == product.Quantity &&
                   CategoryID == product.CategoryID &&
                   Detail == product.Detail &&
                   CreateDate == product.CreateDate &&
                   CreateBy == product.CreateBy &&
                   ModifiedDate == product.ModifiedDate &&
                   ModifiedBy == product.ModifiedBy &&
                   MetaKeywords == product.MetaKeywords &&
                   MetaDescriptions == product.MetaDescriptions &&
                   Status == product.Status &&
                   TopHot == product.TopHot &&
                   Image2 == product.Image2 &&
                   Image3 == product.Image3;
        }
    }
}
