using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadConsoleGame
{
    internal class Gameobjekt
    {
        private ColoredGlyph _mapApperance = new ColoredGlyph();
        public Point Position { get; private set; }
        public ColoredGlyph Apperance { get; set; }

        public Gameobjekt(ColoredGlyph apperance, Point position, IScreenSurface hostingsurface)
        {
            Apperance = apperance;
            Position = position;

            hostingsurface.Surface[position].CopyAppearanceTo(_mapApperance);

            DrawGameObjekt(hostingsurface);
        }
        private void DrawGameObjekt(IScreenSurface screenSurface)
        {
            Apperance.CopyAppearanceTo(screenSurface.Surface[Position]);
            screenSurface.IsDirty = true;
        }
        public bool Move(Point newPosition, Map map)
        {
            if (!map.SurfaceObject.Surface.IsValidCell(newPosition.X, newPosition.Y)) return false;
            if (map.trygetmapobjekt(newPosition, out Gameobjekt foundobjekt))
            {
                if (!foundobjekt.touched(this, map))
                {
                    return false;
                }
            }

            _mapApperance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);
            map.SurfaceObject.Surface[newPosition].CopyAppearanceTo(_mapApperance);

            Position = newPosition;
            DrawGameObjekt(map.SurfaceObject);

            return true;
        }
        public virtual bool touched(Gameobjekt sorce, Map map)
        {
            return false;
        }

    }
}
