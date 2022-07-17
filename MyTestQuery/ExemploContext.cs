namespace MyTestQuery
{
    public class Exemplo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exemplo2 MyExemplo { get; set; }

        public static List<Exemplo> Exemplos => new()
        {
            new Exemplo
            {
                Name = "teste1",
                MyExemplo = new()
            },
            new Exemplo
            {
                Name = "teste2",
                MyExemplo = new()
            }
        };
    }

    public class Exemplo2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ExemploContext : DbContext
    {
        public ExemploContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Exemplo> Exemplo { get; set; }
    }
}