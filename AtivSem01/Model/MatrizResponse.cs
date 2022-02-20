using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivSem01.Model
{
    class MatrizResponse
    {
        public int[,] Matriz { get; set; }
        public bool MatrizPreenchida { get; set; }
        public int Linha { get; set; }
        public int Coluna { get; set; }
    }
}
