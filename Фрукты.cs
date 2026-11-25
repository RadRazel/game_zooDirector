namespace ZooDirector;

public sealed class Фрукты : Корм
{
    public Фрукты() : base(30) { }
    public override int NutritionFor(Животное animal) => animal is Обезьяна ? 60 : 0;
}
