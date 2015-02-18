﻿using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace TowerDefenseGame.Models.Enemies
{
    using System.Windows.Media;
    using TowerDefenseGame.Core;

    public class BasicEnemy : Enemy
    {
        private const int EnemyLifePoints = 50;
        private const int EnemySpeed = 1;

        private static readonly BitmapImage EnemySpriteSheet = new BitmapImage(
            new Uri(@"..\..\Resources\goblinsword.png",
                    UriKind.Relative));

        public BasicEnemy(double x, double y)
            : base(
                x, y, Constants.FieldSegmentSize, Constants.FieldSegmentSize, BasicEnemy.EnemyLifePoints, BasicEnemy.EnemySpeed,
                EnemySpriteSheet)
        {

        }
    }
}
