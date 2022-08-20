using Wincubate.NullObjectExamples;

IAnimalFactory factory = new AnimalFactory();
IAnimal animal = factory.Create("fish");
animal.MakeSound();
