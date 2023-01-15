using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceHunterFilter.Visuals
{
    internal class ProgressBar
    {
        public int BarSize { get; set; } = 50;
        public string ModuleName { get; set; } = string.Empty;

        public ProgressBar(string moduleName = "")
        {
            ModuleName = moduleName;
            SetupProgressBar();
        }

        private void SetupProgressBar()
        {
            Console.WriteLine();
            Console.CursorVisible = false;
            int top = Console.GetCursorPosition().Top;
            Console.SetCursorPosition(0, top);

            Console.Write('[');
            Console.SetCursorPosition(BarSize, top);
            Console.Write(']');

            if (!String.IsNullOrEmpty(ModuleName))
                Console.Write(" - " + ModuleName);

            Console.SetCursorPosition(1, top);
        }

        private void Progress()
        {
            int top = Console.GetCursorPosition().Top;
            int left = Console.GetCursorPosition().Left;
            Console.SetCursorPosition(left, top);
        }

        public void Show(int index, int max)
        {
            if (index > 0)
            {
                int percentage = max / BarSize;
                if (index % percentage == 0)
                {
                    Progress();
                    Console.Write("-");
                }
            }
        }
    }
}
