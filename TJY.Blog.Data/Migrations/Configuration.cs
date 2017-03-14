namespace TJY.Blog.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TJY.Blog.Data.EFDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TJY.Blog.Data.EFDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //context.Accounts.AddOrUpdate(
            //  new Model.Account
            //  {
            //      LoginName = "admin",
            //      Password = "123456",
            //      NickName = "Kevin Tang",
            //      Email = "kevintangtjy@163.com"
            //  });
            //context.SaveChanges();
        }
    }
}
