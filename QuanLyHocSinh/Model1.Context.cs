﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyHocSinh
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuanLyHocSinhEntities : DbContext
    {
        public QuanLyHocSinhEntities()
            : base("name=QuanLyHocSinhEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BangDiem> BangDiems { get; set; }
        public virtual DbSet<GiaoVien> GiaoViens { get; set; }
        public virtual DbSet<HocSinh> HocSinhs { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
    }
}