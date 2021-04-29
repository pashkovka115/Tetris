using System;

namespace Tetris
{
    public static class Field
    {
        private static int _width = 40;
        private static int _hight = 30;

        public static int Hight
        {
            get
            {
                return _hight;
            }
            set
            {
                _hight = value;
                Console.SetWindowSize(_width, Field._hight);
                Console.SetBufferSize(_width, Field._hight);
            }
        }
        
        public static int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                Console.SetWindowSize(_width, Field._hight);
                Console.SetBufferSize(_width, Field._hight);
            }
        }


        /*public static int GetWidth()
        {
            return _width; 
        }

        public static void SetWidth(int value)
        {
            _width = value;
            Console.SetWindowSize(_width, Field.HIGHT);
            Console.SetBufferSize(_width, 30);
        }*/
    }
}