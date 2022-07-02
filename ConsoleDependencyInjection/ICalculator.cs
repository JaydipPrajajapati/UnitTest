using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDependencyInjection
{
    public interface ICalculator
    {
        public int Add(int x, int y);

        public int Divide(int x, int y);
    }
}
