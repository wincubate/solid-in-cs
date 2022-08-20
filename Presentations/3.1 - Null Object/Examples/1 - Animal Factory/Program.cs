using System.Collections.Generic;
using Wincubate.NullObjectExamples;

IEnumerable<IAnimal> animals = new List<IAnimal>
{
    new Cat(),
    new Dog(),
    new Lion()
};

foreach (IAnimal animal in animals)
{
    animal.MakeSound();
}

//IAnimalFactory factory = new AnimalFactory();
//IAnimal animal = factory.Create("fish");
//animal?.MakeSound();
