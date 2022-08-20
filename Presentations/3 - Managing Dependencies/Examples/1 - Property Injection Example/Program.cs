using Wincubate.Module3.ManagingDependencies;

Consumer consumer = new Consumer();
consumer.Dependency = new Implementation1();
consumer.UseDependency();
consumer.Dependency = new Implementation2();
consumer.UseDependency();
