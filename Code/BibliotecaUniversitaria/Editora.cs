using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    public class Editora
    {
        private string codigo, nome;

        public string Codigo { get => codigo; private set => codigo = value; }
        public string Nome { get => nome; private set => nome = value; }

        public Editora(string cod, string nom)
        {
            this.codigo = cod;
            this.nome = nom;
        }

    }
}
