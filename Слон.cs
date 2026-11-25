namespace ZooDirector;

public sealed class Слон : Животное
{
    public Слон(string name) : base(name, 150) { }
    public override bool Eat(Корм food) => food.Amount > 0 && GainSatiety(food.NutritionFor(this));
}
