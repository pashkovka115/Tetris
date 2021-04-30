using System.Runtime.Intrinsics.X86;

namespace Tetris
{
    public class Stick : Figure
    {
        public Stick(int x, int y, char sym)
        {
            Points[0] = new Point(x, y, sym);
            Points[1] = new Point(x, y + 1, sym);
            Points[2] = new Point(x, y + 2, sym);
            Points[3] = new Point(x, y + 3, sym);
            Draw();
        }

        public override void Rotate(Point[] pList)
        {
            // если вертикально
            if (pList[0].x == pList[1].x)
            {
                RotateHorisontal(pList);
            }
            else
            {
                RotateVertical(pList);
            }
        }

        private void RotateVertical(Point[] pList)
        {
            for (int i = 0; i < pList.Length; i++)
            {
                pList[i].x = pList[0].x;
                pList[i].y = pList[0].y + i;
            }
        }

        private void RotateHorisontal(Point[] pList)
        {
            for (int i = 0; i < pList.Length; i++)
            {
                pList[i].y = pList[0].y;
                pList[i].x = pList[0].x + i;
            }
        }
    }
}