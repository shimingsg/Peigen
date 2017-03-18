using Dapper.Contrib.Extensions;
using Peigen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peigen.Repository
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext() : base("MicroWeiXin_DB")
        {

        }

        public DbSet<PublicNumberEntity> PublicNumberDbSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PublicNumberMap());
            base.OnModelCreating(modelBuilder);            
        }


        public static SqlConnection GetDefaultConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MicroWeiXin_DB"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        /// <summary>
        /// 获取entity type所对应的数据库表名称  entity内加[Table]
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTableName(Type type)
        {
            var tableattr = type.GetCustomAttributes(false).Where(attr => attr.GetType().Name == "TableAttribute").SingleOrDefault() as dynamic;
            if (tableattr != null)
                return tableattr.Name;
            return type.Name;
        }

        /// <summary>
        /// Init Dapper TableNameMapper
        /// </summary>
        public static void InitDapperTableNameMapper()
        {
            SqlMapperExtensions.TableNameMapper += new SqlMapperExtensions.TableNameMapperDelegate((Type type) =>
            {
                return GetTableName(type);
            });
        }
    }
}
