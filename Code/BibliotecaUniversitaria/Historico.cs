using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    internal class Historico
    {
        private string codigoEmprestimo, livro, usuario;
        private DateTime dataEmprestimo, dataDevolucao;

        public string CodigoEmprestimo { get => codigoEmprestimo; set => codigoEmprestimo = value; }
        public string Livro { get => livro; set => livro = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public DateTime DataEmprestimo { get => dataEmprestimo; set => dataEmprestimo = value; }
        public DateTime DataDevolucao { get => dataDevolucao; set => dataDevolucao = value; }

        public Historico(string codEmp, string usu, string liv, DateTime data, DateTime dev)
        {
            this.codigoEmprestimo = codEmp;
            this.usuario = usu;
            this.livro = liv;
            this.dataEmprestimo = data;
            this.dataDevolucao = dev;
        }

    }
}
