﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    internal class Board : LogicAbstractAPI
    {
        public int sizeX { get; set; }
        public int sizeY { get; set; }
        public List<Ball> Balls { get; set; }

        public Board(int sizeX, int sizeY) {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            Balls = new List<Ball>();
        }

        public override void AddBalls(int number, int radius)
        {
            for(int i = 0; i < number; i++)
            {
                Random random = new Random();
                int x = random.Next(radius,sizeX-radius);
                int y = random.Next(radius,sizeY-radius);
                Ball ball = new Ball(x, y, radius);
                Balls.Add(ball);
            }
        }


        public override void MoveBalls()
        {
            foreach(Ball b in Balls)
            {
                b.RandomizeSpeed(-5,5);
                b.moveBall();
            }
        }

        public override List<List<int>> GetAllBallsPosition()
        {
            List<List<int>> positions = new List<List<int>>();
            foreach (Ball b in Balls)
            {
                List<int> BallPosition = new List<int>
                {
                    b.PosX,
                    b.PosY
                };
                positions.Add(BallPosition);
            }
            return positions;
        }

        public override void ClearBoard()
        {
            Balls.Clear();
        }
    }
}
