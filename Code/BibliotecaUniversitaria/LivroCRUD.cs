using BibliotecaUniversitaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    public class LivroCRUD
    {
        private string codigo, titulo, autor, editora, classificacao, idioma, midia;
        private string autorNome, editoraNome;
        private int posicao;
        private BancoDados bd;
        private Tela tl;
        private int anoEdicao;

        public LivroCRUD(BancoDados banco, Tela tela)
        {
            this.bd = banco;
            this.tl = tela;
        }

        public void executarCRUD()
        {
            string resp;
            this.posicao = -1;

            this.montarTela();
            this.entrarCodigo();
            this.posicao = bd.buscar("livro", this.codigo);

            if (this.posicao == -1)
            {
                // cadastro
                resp = tl.fazerPergunta(26, 15, "Registro NÃO encontrado. Deseja cadastrar (S/N):");
                if (resp.ToUpper() == "S")
                {
                    this.entrarDados();
                    resp = tl.fazerPergunta(26, 15, "Confirma cadastro (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.gravar("livro", new Livro(this.codigo, this.titulo, this.autor, this.editora, this.classificacao, this.idioma, this.midia, this.anoEdicao));
                    }
                }
            }
            else
            {
                // alteração / exclusão
                Livro obj = (Livro)bd.recuperar("livro", this.posicao);
                this.titulo = obj.Titulo;
                this.autor = obj.Autor;
                this.editora = obj.Editora;
                this.classificacao = obj.Classificacao;
                this.idioma = obj.Idioma;
                this.midia = obj.Midia;
                this.anoEdicao = obj.AnoEdicao;
                this.autorNome = bd.recuperarNome("autor", this.autor);
                this.editoraNome = bd.recuperarNome("editora", this.editora);

                this.mostrarDados();
                resp = tl.fazerPergunta(26, 15, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(42, 7, 74, 13);
                    this.entrarDados();
                    resp = tl.fazerPergunta(26, 15, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        Livro novoObj = new Livro(this.codigo, this.titulo, this.autor, this.editora, this.classificacao, this.idioma, this.midia, this.anoEdicao);
                        bd.alterar("livro", obj, novoObj);
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(26, 15, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("livro", obj);
                    }
                }
            }

        }

        public void montarTela()
        {
            tl.montarMoldura(25, 3, 75, 16, "Cadastro de Livros");
            Console.SetCursorPosition(26, 6);
            Console.Write("Codigo       :");
            Console.SetCursorPosition( 26, 7);
            Console.Write("Título       :");
            Console.SetCursorPosition(26, 8);
            Console.Write("Autor        :");
            Console.SetCursorPosition(26, 9);
            Console.Write("Editora      :");
            Console.SetCursorPosition(26, 10);
            Console.Write("Classificação:");
            Console.SetCursorPosition(26, 11);
            Console.Write("Idioma       :");
            Console.SetCursorPosition(26, 12);
            Console.Write("Midia        :");
            Console.SetCursorPosition(26, 13);
            Console.Write("Ano de edição:");

        }

        public void entrarCodigo()
        {
            Console.SetCursorPosition(42, 6);
            this.codigo = Console.ReadLine();
        }

        public void entrarDados()
        {
            Console.SetCursorPosition(42, 7);
            this.titulo = Console.ReadLine();

            Console.SetCursorPosition(42, 8);
            this.autor = Console.ReadLine();
            Console.SetCursorPosition(42 + this.autor.Length, 8);
            Console.Write(" - " + bd.recuperarNome("autor", this.autor));

            Console.SetCursorPosition(42, 9);
            this.editora = Console.ReadLine();
            Console.SetCursorPosition(42 + this.editora.Length, 9);
            Console.Write(" - " + bd.recuperarNome("editora", this.editora));

            Console.SetCursorPosition(42, 10);
            this.classificacao = Console.ReadLine();

            Console.SetCursorPosition(42, 11);
            this.idioma = Console.ReadLine();

            Console.SetCursorPosition(42, 12);
            this.midia = Console.ReadLine();

            Console.SetCursorPosition(42, 13);
            this.anoEdicao = int.Parse(Console.ReadLine());
        }

        public void mostrarDados()
        {
            Console.SetCursorPosition(42, 7);
            Console.Write(this.titulo);
            Console.SetCursorPosition(42, 8);
            Console.Write(this.autor + " - " + this.autorNome);
            Console.SetCursorPosition(42, 9);
            Console.Write(this.editora + " - " + this.editoraNome);
            Console.SetCursorPosition(42, 10);
            Console.Write(this.classificacao);
            Console.SetCursorPosition(42, 11);
            Console.Write(this.idioma);
            Console.SetCursorPosition(42, 12);
            Console.Write(this.midia);
            Console.SetCursorPosition(42, 13);
            Console.Write(this.anoEdicao);
        }
    }
}
