namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAcc")]
    public partial class UserAcc
    {
        [Key]
        public long UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }

        public DateTime? CreateDate { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool? Status { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserAcc acc &&
                   UserID == acc.UserID &&
                   UserName == acc.UserName &&
                   Password == acc.Password &&
                   Name == acc.Name &&
                   Address == acc.Address &&
                   Email == acc.Email &&
                   Phone == acc.Phone &&
                   CreateDate == acc.CreateDate &&
                   CreateBy == acc.CreateBy &&
                   ModifiedDate == acc.ModifiedDate &&
                   ModifiedBy == acc.ModifiedBy &&
                   Status == acc.Status;
        }
    }
}
