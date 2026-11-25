namespace ZooDirector;

public sealed class Обезьяна : Животное
{
    public Обезьяна(string name) : base(name, 80) { }
    public override bool Eat(Корм food) => food.Amount > 0 && GainSatiety(food.NutritionFor(this));
}
