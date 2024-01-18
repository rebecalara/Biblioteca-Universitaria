using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    public class Livro
    {
        private string codigo;
        private string titulo;
        private string autor;
        private string editora;
        private string classificacao;
        private string idioma;
        private string midia;
        private int anoEdicao;

        public string Codigo { get => codigo; private set => codigo = value; }
        public string Titulo { get => titulo; private set => titulo = value; }
        public string Autor { get => autor; private set => autor = value; }
        public string Editora { get => editora; private set => editora = value; }
        public string Classificacao { get => classificacao; private set => classificacao = value; }
        public string Idioma { get => idioma; private set => idioma = value; }
        public string Midia { get => midia; private set => midia = value; }
        public int AnoEdicao { get => anoEdicao; private set => anoEdicao = value; }
        

        public Livro(string cod, string tit, string aut, string edi, string clas, string idi, string mid, int ano)
        {
            this.codigo = cod;
            this.titulo = tit;
            this.autor = aut;
            this.editora = edi;
            this.classificacao = clas;
            this.idioma = idi;
            this.midia = mid;
            this.anoEdicao = ano;
        }
    }
}
