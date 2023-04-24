using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace visualizer
{
    internal class Bubble : ISort
    {
        private bool _sorted = false;
        private int[] array;
        private Graphics graphics;
        private int max;
        Brush BlackBrush = new SolidBrush(Color.Black);
        Brush WhiteBrush = new SolidBrush(Color.White);
        public void bone(int[] array_In, Graphics graphics_In, int max_In)
        {
            array = array_In;
            graphics = graphics_In;
            max = max_In;

            while (!_sorted)
            {
                for (int i = 0; i < array.Count() - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(i, i + 1);
                    }
                }
                _sorted = IsSorted();
            }
        }

        private void Swap(int i, int p)
        {
            int t = array[i];
            array[i] = array[i + 1];
            array[i + 1] = t;


            graphics.FillRectangle(BlackBrush, i, 0, 1, max);
            graphics.FillRectangle(BlackBrush, p, 0, 1, max);

            graphics.FillRectangle(WhiteBrush, i, max - array[i], 1, max);
            graphics.FillRectangle(WhiteBrush, p, max - array[p], 1, max);

        }

        private bool IsSorted()
        {
            for (int i = 0; i < array.Count() - 1; i++)
            {
                if (array[i] > array[i + 1]) return false;
            }
            return true;
        }
    }
}
