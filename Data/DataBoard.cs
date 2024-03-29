﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace Data
{
    internal class DataBoard:IDataBoard
    {
        public override int Width { get;}
        public override int Height { get;}

        private List<IDataBall> Balls = new List<IDataBall>();

        private DataLogger _logger = new DataLogger();

        public DataBoard(int width, int height) {
            Width = width; 
            Height = height;
            _logger.AddBoard(this);
        }


        public override List<IDataBall> GetAllBalls()
        {
            return Balls;
        }
        public override void RemoveAllBalls()
        {
            Balls.Clear();
        }

        public override IDataBall AddDataBall(int xPosition, int yPosition, int radius, int weight, int xSpeed, int ySpeed, object locker, int id)
        {
            IDataBall ballData = new DataBall(xPosition, yPosition, radius, weight, xSpeed, ySpeed, _logger, id);
            Balls.Add(ballData);
            return ballData;
        }

    }
}
