using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    public class Emprestimo
    {
        private string codigo;
        private string livro, usuario;
        private DateTime data, dataDevolucao;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Livro { get => livro; set => livro = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public DateTime Data { get => data; set => data = value; }
        public DateTime DataDevolucao { get => dataDevolucao; set => dataDevolucao = value; }

        public Emprestimo(string cod, string liv, string usu, DateTime dat, DateTime dev)
        {
            this.codigo = cod;
            this.livro = liv;
            this.usuario = usu;
            this.data = dat;
            this.dataDevolucao = dev;
        }
    }
}

