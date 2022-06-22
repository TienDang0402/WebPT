namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public long NewsID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImage { get; set; }

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

        public override bool Equals(object obj)
        {
            return obj is News news &&
                   NewsID == news.NewsID &&
                   Name == news.Name &&
                   MetaTitle == news.MetaTitle &&
                   Description == news.Description &&
                   Images == news.Images &&
                   MoreImage == news.MoreImage &&
                   CategoryID == news.CategoryID &&
                   Detail == news.Detail &&
                   CreateDate == news.CreateDate &&
                   CreateBy == news.CreateBy &&
                   ModifiedDate == news.ModifiedDate &&
                   ModifiedBy == news.ModifiedBy &&
                   MetaKeywords == news.MetaKeywords &&
                   MetaDescriptions == news.MetaDescriptions &&
                   Status == news.Status &&
                   TopHot == news.TopHot;
        }
    }
}
