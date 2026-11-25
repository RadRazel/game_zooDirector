namespace ZooDirector;

public abstract class Животное
{
    private readonly string name;
    protected int satiety;
    protected readonly int maxSatiety;
    protected Животное(string name, int maximum)
    {
        this.name = name;
        maxSatiety = maximum;
        satiety = Random.Shared.Next(maximum / 2, maximum * 4 / 5 + 1);
    }
    public abstract bool Eat(Корм food);
    protected bool GainSatiety(int gain)
    {
        if (gain <= 0 || satiety == 0 || satiety == maxSatiety) return false;
        satiety = Math.Min(maxSatiety, satiety + gain);
        return true;
    }
    public int GetSatiety() => satiety;
    public void DecreaseSatiety() => satiety = Math.Max(0, satiety - Random.Shared.Next(10, 21));
    public override string ToString() => $"{GetType().Name} {name}: {satiety}/{maxSatiety}";
}
