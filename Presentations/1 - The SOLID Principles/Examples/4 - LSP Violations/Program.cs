using Wincubate.Module1;
using Wincubate.Module1.Domain;

Rectangle rectangle = new Square(4);
rectangle.Height = 5;
Console.WriteLine(rectangle);

Car car = new ElectricCar(); // new Car();
car.TurnIgnitionKey();
Console.WriteLine(car.IsEngineRunning);

ModifiableStockPosition position = new("WCB", 42);
position.ModifyTicker("MSFT");
Console.WriteLine(position);
