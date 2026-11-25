namespace ZooDirector;

public class Зоопарк
{
    private readonly List<Животное> animals = new()
    {
        new Лев("Симба"), new Лев("Нала"), new Слон("Дамбо"),
        new Обезьяна("Чичи"), new Обезьяна("Бонго"), new Обезьяна("Кики")
    };
    private readonly List<Корм> foodStock = new() { new Мясо(), new Трава(), new Фрукты() };
    public IReadOnlyList<Животное> Animals => animals.AsReadOnly();
    public IReadOnlyList<Корм> FoodStock => foodStock.AsReadOnly();
    public int Day { get; private set; } = 1;
    public const int LastDay = 10;
    public bool Finished => Day > LastDay || animals.Count == 0;
    public bool FeedAnimal(Животное target)
    {
        if (Finished || !animals.Contains(target)) return false;
        var food = foodStock.Where(f => f.Amount > 0 && f.NutritionFor(target) > 0)
                            .OrderByDescending(f => f.NutritionFor(target)).FirstOrDefault();
        if (food == null || !target.Eat(food)) return false;
        return food.TakeOne();
    }
    public void NextDay()
    {
        if (Finished) return;
        foreach (var animal in animals) animal.DecreaseSatiety();
        animals.RemoveAll(a => a.GetSatiety() == 0);
        Day++;
    }
    public double GetAverageSatiety() => animals.Count == 0 ? 0 : animals.Average(a => a.GetSatiety());
}
