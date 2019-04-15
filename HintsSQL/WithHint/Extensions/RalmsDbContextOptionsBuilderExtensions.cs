using Microsoft.EntityFrameworkCore.Infrastructure;
using Ralms.EntityFrameworkCore.Extensions;

namespace Microsoft.EntityFrameworkCore
{
    public static class RalmsDbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder RalmsExtendFunctions(this DbContextOptionsBuilder optionsBuilder)
        {
            var extension = optionsBuilder.Options.FindExtension<RalmsExOptionsExtension>()
                ?? new RalmsExOptionsExtension();

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);

            return optionsBuilder;
        }

        public static DbContextOptionsBuilder<TContext> RalmsExtendFunctions<TContext>(
            this DbContextOptionsBuilder<TContext> optionsBuilder)
            where TContext : DbContext
            => (DbContextOptionsBuilder<TContext>)RalmsExtendFunctions((DbContextOptionsBuilder)optionsBuilder);

#warning Use in the future!
        public static DbContextOptionsBuilder<TContext> RalmsExtendSqlServer<TContext>(
            this DbContextOptionsBuilder<TContext> optionsBuilder)
            where TContext : DbContext
            => (DbContextOptionsBuilder<TContext>)RalmsExtendFunctions((DbContextOptionsBuilder)optionsBuilder);

        public static DbContextOptionsBuilder<TContext> RalmsExtendSqlite<TContext>(
           this DbContextOptionsBuilder<TContext> optionsBuilder)
           where TContext : DbContext
           => (DbContextOptionsBuilder<TContext>)RalmsExtendFunctions((DbContextOptionsBuilder)optionsBuilder);

        public static DbContextOptionsBuilder<TContext> RalmsExtendFirebird<TContext>(
           this DbContextOptionsBuilder<TContext> optionsBuilder)
           where TContext : DbContext
           => (DbContextOptionsBuilder<TContext>)RalmsExtendFunctions((DbContextOptionsBuilder)optionsBuilder);

        public static DbContextOptionsBuilder<TContext> RalmsExtendPostgres<TContext>(
           this DbContextOptionsBuilder<TContext> optionsBuilder)
           where TContext : DbContext
           => (DbContextOptionsBuilder<TContext>)RalmsExtendFunctions((DbContextOptionsBuilder)optionsBuilder);
    }
}
