namespace Tetris
{
    public abstract class Figure
    {
        protected Point[] points = new Point[4];
        
        
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


        public void Move(Direction dir)
        {
            foreach (Point point in points)
            {
                point.Move(dir);
            }
        }


        public abstract void Rotate();
    }
}
