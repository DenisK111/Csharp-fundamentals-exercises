using System.Collections.Generic;

namespace MilitaryElite
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyDictionary<string, ISoldier> Privates { get; }
    }
}