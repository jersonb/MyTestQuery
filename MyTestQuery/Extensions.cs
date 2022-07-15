namespace MyTestQuery.Extension
{
    public static class Extensions
    {
        public static void ToListAsync<T>(this IQueryable<T> query)
        {
            ExecuteAsync(query, EntityFrameworkQueryableExtensions.ToListAsync(query));
        }

        public static void FirstOrDefaultAsync<T>(this IQueryable<T> query)
        {
            ExecuteAsync(query, EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(query));
        }

        public static void FirstAsync<T>(this IQueryable<T> query)
        {
            ExecuteAsync(query, EntityFrameworkQueryableExtensions.FirstAsync(query));
        }

        public static void SingleOrDefaultAsync<T>(this IQueryable<T> query)
        {
            ExecuteAsync(query, EntityFrameworkQueryableExtensions.SingleOrDefaultAsync(query));
        }

        private static void ExecuteAsync<T>(IQueryable<T> query, Task<T> result)
        {
            PrintResult(query, result.GetAwaiter().GetResult());
        }

        private static void ExecuteAsync<T>(IQueryable<T> query, Task<List<T>> result)
        {
            PrintResult(query, result.GetAwaiter().GetResult().ToArray());
        }

        private static void PrintResult<T>(IQueryable<T> query, params T[] result)
        {
            PrintLineColor(query.ToQueryString().Replace(" AND", "\nAND"), ConsoleColor.DarkGray);
            Console.WriteLine();
            printLine();

            var i = 0;
            var jsonOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            foreach (var x in result)
            {
                var color = ConsoleColor.White;

                if (i % 2 == 0)
                    color = ConsoleColor.Yellow;

                PrintLineColor(@$"""{typeof(T).Name}_{i++}"" : {JsonSerializer.Serialize(x, jsonOptions)}", color);

                printLine();
            }

            static void printLine()
                => PrintLineColor(new string('-', 80), ConsoleColor.DarkMagenta);
        }

        private static void PrintLineColor(string text, ConsoleColor color)
        {
            Console.ResetColor();
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static T CreateContext<T>(DbContextOptionsBuilder optionsBuilder) where T : DbContext
        {
            var context = Activator.CreateInstance(typeof(T), optionsBuilder.Options) ?? throw new InvalidCastException();
            return (T)context;
        }
    }
}