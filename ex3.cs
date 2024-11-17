using System;
using System.Collections;
using System.Collections.Generic;
using static ex2;

public class CarCatalog : IEnumerable<Car>
{
    private Car[] _cars;

    public CarCatalog(Car[] cars)
    {
        _cars = cars;
    }
    // Прямой проход с первого элемента до последнего
    public IEnumerator<Car> GetEnumerator()
    {
        for (int i = 0; i < _cars.Length; i++)
        {
            yield return _cars[i];
        }
    }
    // Обратный проход от последнего к первому
    public IEnumerable<Car> Reverse()
    {
        for (int i = _cars.Length - 1; i >= 0; i--)
        {
            yield return _cars[i];
        }
    }
    // Проход по элементам массива с фильтром по году выпуска
    public IEnumerable<Car> FilterByProductionYear(int year)
    {
        foreach (var car in _cars)
        {
            if (car.ProductionYear == year)
            {
                yield return car;
            }
        }
    }
    // Проход по элементам массива с фильтром по максимальной скорости
    public IEnumerable<Car> FilterByMaxSpeed(int maxSpeed)
    {
        foreach (var car in _cars)
        {
            if (car.MaxSpeed == maxSpeed)
            {
                yield return car;
            }
        }
    }
    // Явная реализация интерфейса IEnumerable для совместимости с неуниверсальными коллекциями
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
