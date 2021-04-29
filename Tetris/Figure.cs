namespace Tetris
{
    public abstract class Figure
    {
        const int LENGHT = 4;
        protected Point[] points = new Point[LENGHT];
        
        
        public void Draw()
        {
            foreach (Point point in points)
            {
                point.Draw();
            }
        }


        public void Hide()
        {
            foreach (Point point in points)
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

        
        public void TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);

            if (VerifyPosition(clone))
            {
                points = clone;
            }
            Draw();
        }

        
        public void TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);

            if (VerifyPosition(clone))
            {
                points = clone;
            }
            Draw();
        }

        private bool VerifyPosition(Point[] pList)
        {
            foreach (var p in pList)
            {
                if (p.x < 0 || p.y < 0 || p.x >= Field.Width - 1 || p.y >= Field.Hight - 1)
                {
                    return false;
                }
            }

            return true;
        }

        private Point[] Clone()
        {
            var newPoints = new Point[LENGHT];
            for (int i = 0; i < LENGHT; i++)
            {
                newPoints[i] = new Point(points[i]);
            }

            return newPoints;
        }


        public abstract void Rotate(Point[] pList);
    }
}
