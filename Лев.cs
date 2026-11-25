namespace ZooDirector;

public sealed class Лев : Животное
{
    public Лев(string name) : base(name, 100) { }
    public override bool Eat(Корм food) => food.Amount > 0 && GainSatiety(food.NutritionFor(this));
}
