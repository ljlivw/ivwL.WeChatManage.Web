using ivwL.WeChat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Text;

namespace ivwL.WeChat.Dao
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public static readonly LoggerFactory loggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider() });
        private readonly string sqlConn;
        private readonly string sqlDataBaseType;
        public DbContext(string sqlConn, string sqlDataBaseType, int iConnTimeOut = 1000 * 60 * 60)
        {
            this.sqlConn = sqlConn;
            this.sqlDataBaseType = sqlDataBaseType.ToLower();
            this.Database.SetCommandTimeout(iConnTimeOut);
        }

        #region DbSet
        public DbSet<Sys_Info> Sys_Info { get; set; }
        public DbSet<Sys_User> Sys_User { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Sys_Info>().HasKey(a => a.Id);
            mb.Entity<Sys_User>().HasKey(a => a.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseLoggerFactory(loggerFactory);
            switch (sqlDataBaseType)
            {
                case "oracle": break;
                case "sqlserver": ob.UseSqlServer(sqlConn); break;
            }
        }
    }
}
