﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace SadConsoleGame
{
    internal class Map
    {
        private List<Gameobjekt> _mapobjekts;
        private ScreenSurface _mapSurface;


        public IReadOnlyList<Gameobjekt> gameobjekts => _mapobjekts.AsReadOnly();
        public ScreenSurface SurfaceObject => _mapSurface;
        public Gameobjekt UserControlledObject { get; set; }

        public Map(int mapWidth, int mapHeight)
        {
            _mapobjekts = new List<Gameobjekt>();
            _mapSurface = new ScreenSurface(mapWidth, mapHeight);
            _mapSurface.UseMouse = false;

            FillBackground();

            UserControlledObject = new Gameobjekt(new ColoredGlyph(Color.White, Color.Black, 2), _mapSurface.Surface.Area.Center, _mapSurface);

            for (int i = 0; i < 5; i++)
            {
                CreateTreasure();
                CreateMonster();
            }
        }

        private void FillBackground()
        {
            Color[] colors = new[] { Color.LightGreen, Color.Coral, Color.CornflowerBlue, Color.DarkGreen };
            float[] colorStops = new[] { 0f, 0.35f, 0.75f, 1f };

            Algorithms.GradientFill(_mapSurface.FontSize,
                                    _mapSurface.Surface.Area.Center,
                                    _mapSurface.Surface.Width / 3,
                                    45,
                                    _mapSurface.Surface.Area,
                                    new Gradient(colors, colorStops),
                                    (x, y, color) => _mapSurface.Surface[x, y].Background = color);
        }
        private void CreateTreasure()
        {
            for (int i = 1; i < 100; i++)
            {
                Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width), Game.Instance.Random.Next(0, _mapSurface.Height));

                bool foundobjekt = _mapobjekts.Any(obj => obj.Position == randomPosition);
                if (foundobjekt) continue;

                Treasure treasur = new Treasure(randomPosition, _mapSurface);
                _mapobjekts.Add(treasur);
                break;
            }
        }
        private void CreateMonster()
        {
            for (int i = 0; 1 < 100; i++)
            {
                Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width), Game.Instance.Random.Next(0, _mapSurface.Height));

                bool foundobjekt = _mapobjekts.Any(obj => obj.Position == randomPosition);
                if (foundobjekt) continue;

                Monster monster = new Monster(randomPosition, _mapSurface);
                _mapobjekts.Add(monster);
                break;
            }
        }
        public bool trygetmapobjekt(Point position, [NotNullWhen(true)] out Gameobjekt? gameobjekt)
        {
            foreach (var othergameobjekts in _mapobjekts)
            {
                if (othergameobjekts.Position == position)
                {
                    gameobjekt = othergameobjekts;
                    return true;
                }

            }
                gameobjekt = null;
                return false;
        }
        public void RemoveMapObjekt(Gameobjekt mapobjekt)
        {
            if (_mapobjekts.Contains(mapobjekt))
            {
                _mapobjekts.Remove(mapobjekt);
                mapobjekt.RestoreMap(this);
            }
        }
    }
}
