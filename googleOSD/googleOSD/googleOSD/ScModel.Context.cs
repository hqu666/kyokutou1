﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GoogleOSD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SceduleEntities : DbContext
    {
        public SceduleEntities()
            : base("name=SceduleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Companys> Companys { get; set; }
        public virtual DbSet<t_events> t_events { get; set; }
        public virtual DbSet<t_project_base> t_project_base { get; set; }
    }
}
