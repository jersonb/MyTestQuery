/**
* Ajuste o DbContextOptionsBuilder para o banco de dados a ser utilizado incluindo a string de conexão
* Importe a lib do context e substitua
* Remova inserção de exemplo e realize a consulta desejada
* Os métodos que geram vizualização estão na classe Extensions
*/
var optionsBuilder = new DbContextOptionsBuilder()
    .UseInMemoryDatabase(Guid.NewGuid().ToString());

var context = Extensions.CreateContext<ExemploContext>(optionsBuilder);

context.AddRange(Exemplo.Exemplos);
context.SaveChanges();

var query = context.Exemplo;

query.ToListAsync3();