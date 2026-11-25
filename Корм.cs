namespace ZooDirector;

public abstract class Корм
{
    public int Amount { get; private set; }
    public int UnitPrice { get; }
    protected Корм(int price) => UnitPrice = price;
    public abstract int NutritionFor(Животное animal);
    public void Add(int amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
        Amount = checked(Amount + amount);
    }
    public bool TakeOne()
    {
        if (Amount == 0) return false;
        Amount--;
        return true;
    }
    public override string ToString() => $"{GetType().Name}: {Amount} порц., цена {UnitPrice}";
}
