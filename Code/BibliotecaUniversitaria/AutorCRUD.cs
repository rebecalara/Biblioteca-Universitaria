using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    public class AutorCRUD
    {
        private string codigo, nome, nacionalidade;
        private BancoDados bd;
        private Tela tl;
        private int posicao;


        public AutorCRUD(BancoDados banco, Tela tela)
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
            this.posicao = bd.buscar("autor", this.codigo);

            if (this.posicao == -1)
            {
                // cadastro
                resp = tl.fazerPergunta(26, 10, "Registro NÃO encontrado. Deseja cadastrar (S/N):");
                if (resp.ToUpper() == "S")
                {
                    this.entrarDados();
                    resp = tl.fazerPergunta(26, 10, "Confirma cadastro (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.gravar("autor", new Autor(this.codigo, this.nome, this.nacionalidade));
                    }
                }
            }
            else
            {
                // alteração / exclusão
                Autor obj = (Autor)bd.recuperar("autor", this.posicao);
                this.nome = obj.Nome;
                this.nacionalidade = obj.Nacionalidade;

                this.mostrarDados();
                resp = tl.fazerPergunta(26, 10, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(42, 7, 74, 8);
                    this.entrarDados();
                    resp = tl.fazerPergunta(26, 10, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        Autor novoObj = new Autor(this.codigo, this.nome, this.nacionalidade);
                        bd.alterar("autor", obj, novoObj);
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(26, 10, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("autor", obj);
                    }
                }
            }

        }

        public void montarTela()
        {
            tl.montarMoldura(25, 3, 75, 11, "Cadastro de Autores");
            Console.SetCursorPosition(26, 6);
            Console.Write("Codigo        :");
            Console.SetCursorPosition(26, 7);
            Console.Write("Nome          :");
            Console.SetCursorPosition(26, 8);
            Console.Write("Nacionalidade :");
        }

        public void entrarCodigo()
        {
            Console.SetCursorPosition(42, 6);
            this.codigo = Console.ReadLine();
        }

        public void entrarDados()
        {
            Console.SetCursorPosition(42, 7);
            this.nome = Console.ReadLine();
            Console.SetCursorPosition(42, 8);
            this.nacionalidade = Console.ReadLine();
        }

        public void mostrarDados()
        {
            Console.SetCursorPosition(42, 7);
            Console.Write(this.nome);
            Console.SetCursorPosition(42, 8);
            Console.Write(this.nacionalidade);
        }
    }
}
