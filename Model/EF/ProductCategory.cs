namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        [Key]
        public long CategoryID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string MetaTitle { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(100)]
        public string SeoTitle { get; set; }

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

        public bool? ShownOnHome { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductCategory category &&
                   CategoryID == category.CategoryID &&
                   Name == category.Name &&
                   MetaTitle == category.MetaTitle &&
                   DisplayOrder == category.DisplayOrder &&
                   SeoTitle == category.SeoTitle &&
                   CreateDate == category.CreateDate &&
                   CreateBy == category.CreateBy &&
                   ModifiedDate == category.ModifiedDate &&
                   ModifiedBy == category.ModifiedBy &&
                   MetaKeywords == category.MetaKeywords &&
                   MetaDescriptions == category.MetaDescriptions &&
                   Status == category.Status &&
                   ShownOnHome == category.ShownOnHome;
        }
    }
}
