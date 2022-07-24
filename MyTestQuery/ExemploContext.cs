namespace MyTestQuery
{
    public class Exemplo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MyExemploId { get; set; }
        public Exemplo2 MyExemplo { get; set; }
        public ICollection<Exemplo3> Exemplo3s { get; set; }

        public static List<Exemplo> Exemplos => new()
        {
            new Exemplo
            {
                Name = "teste1",
                MyExemplo = new Exemplo2
                {
                    Name = "teste3"
                },

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

    public class Exemplo3
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exemplo Exemplo { get; set; }
    }

    public class ExemploContext : DbContext
    {
        public ExemploContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Exemplo> Exemplo { get; set; }
    }
}