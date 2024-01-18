using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    internal class Usuario
    {
        private string codigo;
        private string nome;
        private string endereço;
        private string curso;
        private int inicioCurso;
        private int prevFimCurso;
        private TipoUsuario tipo;
        private int limiteEmprestimo;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Endereço { get => endereço; set => endereço = value; }
        public string Curso { get => curso; set => curso = value; }
        public int InicioCurso { get => inicioCurso; set => inicioCurso = value; }
        public int PrevFimCurso { get => prevFimCurso; set => prevFimCurso = value; }
        public TipoUsuario Tipo { get => tipo; set => tipo = value; }
        public int LimiteEmprestimo { get => limiteEmprestimo; set => limiteEmprestimo = value; }

        public Usuario(string cod, string nome, string end, string cur, int ini, int prev, TipoUsuario tip, int limt)
        {
            this.codigo = cod;
            this.nome = nome;
            this.endereço = end;
            this.curso = cur;
            this.inicioCurso = ini;
            this.prevFimCurso = prev;
            this.tipo = tip;
            this.limiteEmprestimo = limt;

            switch (tip)
            {
                case TipoUsuario.Aluno:
                    this.limiteEmprestimo = 3;
                    break;
                case TipoUsuario.Professor:
                case TipoUsuario.Funcionario:
                    this.limiteEmprestimo = int.MaxValue; // ilimitado
                    break;
                default:
                    this.limiteEmprestimo = 0; // Limite padrão
                    break;
            }
        }

        public enum TipoUsuario
        {
            Aluno,
            Professor,
            Funcionario
        }


    }

    
}
