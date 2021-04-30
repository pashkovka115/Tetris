namespace Tetris
{
    public abstract class Figure
    {
        const int LENGHT = 4;
        public Point[] Points = new Point[LENGHT];


        public void Draw()
        {
            foreach (Point point in Points)
            {
                point.Draw();
            }
        }


        public void Hide()
        {
            foreach (Point point in Points)
            {
                point.Hide();
            }
        }


        /*public void Move(Direction dir)
        {
            Hide();
            foreach (Point point in points)
            {
                point.Move(dir);
            }
            Draw();
        }*/


        public void Move(Point[] pList, Direction dir)
        {
            foreach (Point point in pList)
            {
                point.Move(dir);
            }
        }


        public Result TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);

            var result = VerifyPosition(clone);
            if (result == Result.Success)
            {
                Points = clone;
            }
            Draw();

            return result;
        }


        public Result TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);

            var result = VerifyPosition(clone);
            if (result == Result.Success)
            {
                Points = clone;
            }
            Draw();
            
            return result;
        }

        private Result VerifyPosition(Point[] pList)
        {
            foreach (var p in pList)
            {
                if (p.y >= Field.Hight)
                {
                    return Result.DownBorderStrike;
                }

                if (p.x >= Field.Width)
                {
                    return Result.BorderStrike;
                }

                if (Field.CheckStrike(p))
                {
                    return Result.HeapStrike;
                }
            }

            return Result.Success;
        }

        private Point[] Clone()
        {
            var newPoints = new Point[LENGHT];
            for (int i = 0; i < LENGHT; i++)
            {
                newPoints[i] = new Point(Points[i]);
            }

            return newPoints;
        }


        public abstract void Rotate(Point[] pList);
    }
}