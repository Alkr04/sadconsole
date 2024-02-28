using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadConsoleGame
{
    internal class Treasure : Gameobjekt
    {
        public Treasure(Point position, IScreenSurface hostingsurface)
            : base(new ColoredGlyph(Color.Yellow, Color.Black, 'V'), position, hostingsurface)
        {

        }
        public override bool touched(Gameobjekt source, Map map)
        {
            if(source == map.UserControlledObject)
            {
                map.RemoveMapObjekt(this);
                return true;
            }
            return false;
        }
    }
}
