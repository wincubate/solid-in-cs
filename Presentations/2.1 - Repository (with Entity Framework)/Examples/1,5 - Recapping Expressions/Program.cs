using System;

Func<int, int, int> add = (x, y) => x + y;
Console.WriteLine(add);

//Expression<Func<int, int, int>> addTree = ( x, y ) => x + y;
//Func<int, int, int> add = addTree.Compile();
//Console.WriteLine(add(5, 7));
