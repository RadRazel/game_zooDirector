namespace ZooDirector;

public sealed class Мясо : Корм
{
    public Мясо() : base(45) { }
    public override int NutritionFor(Животное animal) => animal switch { Лев => 60, Обезьяна => 15, _ => 0 };
}
