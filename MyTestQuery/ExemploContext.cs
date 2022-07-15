namespace MyTestQuery
{
    public class Exemplo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Exemplo> Exemplos => new()
        {
            new Exemplo
            {
                Name = "teste1"
            },
            new Exemplo
            {
                Name = "teste2"
            }
        };
    }

    public class ExemploContext : DbContext
    {
        public ExemploContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Exemplo> Exemplo { get; set; }
    }
}