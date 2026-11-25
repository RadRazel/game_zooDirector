namespace ZooDirector;

public class Директор
{
    private readonly string name;
    private readonly Зоопарк zoo;
    public int Money { get; private set; }
    public Директор(string name, int money, Зоопарк zoo)
    {
        this.name = string.IsNullOrWhiteSpace(name) ? "Директор" : name.Trim();
        Money = money;
        this.zoo = zoo;
    }
    public string GetName() => name;
    public bool BuyFood(Корм food, int amount)
    {
        if (zoo.Finished || !zoo.FoodStock.Contains(food) || amount <= 0) return false;
        long cost = (long)amount * food.UnitPrice;
        if (cost > Money || amount > int.MaxValue - food.Amount) return false;
        food.Add(amount);
        Money -= (int)cost;
        return true;
    }
}
/* «Главная форма отвечает за графический интерфейс. Она
показывает данные и передаёт действия пользователя классам
Директор и Зоопарк . Основная логика приложения находится в
этих классах». */
