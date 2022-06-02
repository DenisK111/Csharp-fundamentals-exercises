namespace MilitaryElite
{
    public interface ISpecialisedSoldier : IPrivate
    {
        CorpsEnum Corps { get; }
    }
}