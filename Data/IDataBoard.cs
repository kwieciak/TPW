﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class IDataBoard
    {
        public abstract int Width {get;}
        public abstract int Height { get;}

        public abstract List<IDataBall> GetAllBalls();
        public abstract void RemoveAllBalls();
        public abstract IDataBall AddDataBall(int xPosition, int yPosition, int radius, int weight, int xSpeed, int ySpeed, object locker, int id);

        public static IDataBoard CreateApi(int boardWidth = 580, int boardHeight = 400)
        {
            return new DataBoard(boardWidth, boardHeight);
        }

    }
}
