using System;

// Клас для моделювання автомобіля
public class Car
{
    public string Model { get; private set; } // Модель автомобіля
    public double Fuel { get; private set; } // Кількість палива
    public double Mileage { get; private set; } // Пробіг автомобіля

    // Конструктор для ініціалізації автомобіля
    public Car(string model, double fuel)
    {
        Model = model;
        Fuel = fuel;
        Mileage = 0;
    }

    // Метод для їзди на автомобілі
    public void Drive(double distance)
    {
        if (Fuel <= 0)
        {
            Console.WriteLine("Not enough fuel to drive.");
            return;
        }

        Mileage += distance;
        Fuel -= distance * 0.1; // Витрата палива 0.1 літрів на км
        if (Fuel < 0)
        {
            Fuel = 0;
        }

        Console.WriteLine($"Drove {distance} km. Current mileage: {Mileage} km. Fuel left: {Fuel} liters.");
    }

    // Метод для заправки автомобіля
    public void Refuel(double liters)
    {
        Fuel += liters;
        Console.WriteLine($"Refueled {liters} liters. Current fuel: {Fuel} liters.");
    }

    // Метод для обслуговування автомобіля
    public void Service()
    {
        Console.WriteLine("Car has been serviced.");
    }
}

// Клас для моделювання водія
public class Driver
{
    public string Name { get; private set; } // Ім'я водія

    // Конструктор для ініціалізації водія
    public Driver(string name)
    {
        Name = name;
    }

    // Метод для їзди на автомобілі
    public void DriveCar(Car car, double distance)
    {
        Console.WriteLine($"{Name} is driving the car.");
        car.Drive(distance);
    }

    // Метод для заправки автомобіля
    public void RefuelCar(Car car, double liters)
    {
        Console.WriteLine($"{Name} is refueling the car.");
        car.Refuel(liters);
    }

    // Метод для обслуговування автомобіля
    public void ServiceCar(Car car)
    {
        Console.WriteLine($"{Name} is servicing the car.");
        car.Service();
    }
}

// Основний клас програми
class Program
{
    static void Main(string[] args)
    {
        // Створення об'єкту автомобіля з початковим запасом палива 50 літрів
        Car myCar = new Car("Toyota Camry", 50);

        // Створення об'єкту водія
        Driver driver = new Driver("John Doe");

        // Симуляція подій життя автомобіля
        driver.DriveCar(myCar, 100); // Водій їде на 100 км
        driver.RefuelCar(myCar, 20); // Водій заправляє автомобіль на 20 літрів
        driver.DriveCar(myCar, 50);  // Водій їде на 50 км
        driver.ServiceCar(myCar);    // Водій обслуговує автомобіль

        // Завершення симуляції
        Console.WriteLine("Simulation complete. Press any key to exit.");
        Console.ReadKey();
    }
}
