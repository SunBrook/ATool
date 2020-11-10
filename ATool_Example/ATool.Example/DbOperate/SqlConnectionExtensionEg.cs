using System.Collections.Generic;
using System.Data.SqlClient;

namespace ATool.Example.DbOperate
{
    public class SqlConnectionExtensionEg
    {
        /// <summary>
        /// 批量插入数据
        /// </summary>
        public static void BulkCopyEg()
        {
            List<User> usersToInsert = new List<User>
            {
                new User {Id = 1, Name = "so1", Age = 18, CityId = 1},
                new User {Id = 2, Name = "so2", Age = 19, CityId = 2},
                new User {Id = 3, Name = "so3", Age = 20, CityId = 3},
                new User {Id = 4, Name = "so4", Age = 21, CityId = 4}
            };
            
            string connString = "Data Source = .;Initial Catalog = Chloe;Integrated Security = SSPI;";
            
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.BulkCopy(usersToInsert, 20000, "Users");
            }
        }

        class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int? Age { get; set; }
            public int? CityId { get; set; }
        }
    }
}