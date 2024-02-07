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
        public bool Move(Point newPosition, IScreenSurface screenSurface)
        {
            if (!screenSurface.Surface.IsValidCell(newPosition.X, newPosition.Y)) return false;
            _mapApperance.CopyAppearanceTo(screenSurface.Surface[Position]);
            screenSurface.Surface[newPosition].CopyAppearanceTo(_mapApperance);

            Position = newPosition;
            DrawGameObjekt(screenSurface);

            return true;
        }

    }
}
