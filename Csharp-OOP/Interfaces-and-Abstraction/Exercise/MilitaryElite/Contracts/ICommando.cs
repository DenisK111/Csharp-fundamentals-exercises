using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyDictionary<string, StateEnum> Missions { get; }

        void CompleteMission(string codeName);
    }
}