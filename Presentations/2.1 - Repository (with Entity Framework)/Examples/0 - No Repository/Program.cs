using System;
using System.Linq;
using Wincubate.RepositoryExamples.Data;
using Wincubate.RepositoryExamples.Data.EF;

using ProductsContext context = new();

var query = context
    .Products
    .Where(p => p.Category == Category.Book);

foreach (var product in query)
{
    Console.WriteLine(product);
}

