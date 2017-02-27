using TJY.Blog.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TJY.Blog.Data.ModelMap;


namespace TJY.Blog.Data
{
    internal class EFDatabaseContext : DbContext
    {
        public EFDatabaseContext() : base("name=EFDatabaseContext")
        {
            //实体模型改变时，自动迁移到最新版本
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDatabaseContext, Migrations.Configuration>());
            //实体模型改变时，重建数据库
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFDatabaseContext>());
        }

        public DbSet<Account> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> ArticleCategories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticleMap());
            modelBuilder.Configurations.Add(new CommentMap());

            //指定单数形式的表名
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //移除一对多的级联删除约定，想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //多对多启用级联删除约定，不想级联删除可以在删除前判断关联的数据进行拦截
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
