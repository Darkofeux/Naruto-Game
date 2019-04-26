namespace NARUTO____.Buffs.Model
{
    public interface IBuff
    {
        decimal AttackMultiplier { get;}
        decimal DamageMultiplier { get; }
        int TourRestants { get; }
    }

}