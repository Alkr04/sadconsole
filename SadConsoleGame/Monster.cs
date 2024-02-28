using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadConsoleGame
{
    internal class Monster : Gameobjekt
    {
        public Monster(Point position, IScreenSurface hostingsurface)
            :base(new ColoredGlyph(Color.Red,Color.Black, 'M'),position, hostingsurface)
        {

        }
        public override bool touched(Gameobjekt source, Map map)
        {
            return base.touched(source, map);
        }
    }
}
