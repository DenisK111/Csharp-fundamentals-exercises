using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Game_OOP.Contracts
{
   public interface IRenderer
    {
        void Render(Body body);
        void Render(IFood food);

        void Clear();
    }
}
