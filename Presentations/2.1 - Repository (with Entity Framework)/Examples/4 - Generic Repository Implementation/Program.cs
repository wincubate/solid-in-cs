using System;
using System.Collections.Generic;
using Wincubate.RepositoryExamples;
using Wincubate.RepositoryExamples.Data;
using Wincubate.RepositoryExamples.Data.EF;

IProductRepository repository = new ProductRepository( new ProductsContext() );

//IProductRepository repository = new InMemoryProductRepository(
//    new Product { Id = 1, Name = "Continuum Transfunctioner", Manufacturer = "Universal Stuff Inc.", Category = Category.Hardware },
//    new Product { Id = 2, Name = "Necronomicon Ex Mortis", Manufacturer = "Deadite Press", Category = Category.Book }
//);

IEnumerable<Product> query = repository.GetForCategory(Category.Book);
foreach (var product in query)
{
    Console.WriteLine(product);
}

Console.WriteLine(repository.GetById(1));
