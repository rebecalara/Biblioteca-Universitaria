using BibliotecaUniversitaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    public class EditoraCRUD
    {
        private string codigo, nome;
        private BancoDados bd;
        private Tela tl;
        private int posicao;


        public EditoraCRUD(BancoDados banco, Tela tela)
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
            this.posicao = bd.buscar("editora", this.codigo);

            if (this.posicao == -1)
            {
                // cadastro
                resp = tl.fazerPergunta(26, 9, "Registro NÃO encontrado. Deseja cadastrar (S/N):");
                if (resp.ToUpper() == "S")
                {
                    this.entrarDados();
                    resp = tl.fazerPergunta(26, 9, "Confirma cadastro (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.gravar("editora", new Editora(this.codigo, this.nome));
                    }
                }
            }
            else
            {
                // alteração / exclusão
                Editora obj = (Editora)bd.recuperar("editora", this.posicao);
                nome = obj.Nome;

                this.mostrarDados();
                resp = tl.fazerPergunta(26, 9, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(35, 7, 74, 8);
                    this.entrarDados();
                    resp = tl.fazerPergunta(26, 9, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        Editora novoObj = new Editora(this.codigo, this.nome);
                        bd.alterar("editora", obj, novoObj);
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(26, 9, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("editora", obj);
                    }
                }
            }

        }

        public void montarTela()
        {
            tl.montarMoldura(25, 3, 75, 10, "Cadastro de Editoras");
            Console.SetCursorPosition(26, 6);
            Console.Write("Codigo :");
            Console.SetCursorPosition(26, 7);
            Console.Write("Nome   :");
        }

        public void entrarCodigo()
        {
            Console.SetCursorPosition(35, 6);
            this.codigo = Console.ReadLine();
        }

        public void entrarDados()
        {
            Console.SetCursorPosition(35, 7);
            this.nome = Console.ReadLine();
        }

        public void mostrarDados()
        {
            Console.SetCursorPosition(35, 7);
            Console.Write(this.nome);
        }
    }
}
