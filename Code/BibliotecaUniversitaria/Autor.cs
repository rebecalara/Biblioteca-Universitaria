using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    public class Autor
    {
        private string codigo;
        private string nome;
        private string nacionalidade;

        public string Codigo { get => codigo; private set => codigo = value; }
        public string Nome { get => nome; private set => nome = value; }
        public string Nacionalidade { get => nacionalidade; private set => nacionalidade = value; }

        public Autor(string cod, string nom, string nac)
        {
            this.codigo = cod;
            this.nome = nom;
            this.nacionalidade = nac;
        }
    }
}
