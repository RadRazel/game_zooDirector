namespace ZooDirector;

public sealed class Трава : Корм
{
    public Трава() : base(25) { }
    public override int NutritionFor(Животное animal) => animal is Слон ? 60 : 0;
}
