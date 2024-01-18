using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    public class EmprestimoCRUD
    {
        private string codigo, codigoEmprestimo;
        private string livro, usuario;
        private string nomeLivro, nomeUsuario;
        private DateTime data, dataDevolucao;
        private int posicao;
        private BancoDados bd;
        private Tela tl;

        public EmprestimoCRUD(BancoDados banco, Tela tela)
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
            this.posicao = bd.buscar("emprestimo", this.codigo);
            if (this.posicao == -1)
            {
                this.entrarDados();
                resp = tl.fazerPergunta(26, 12, "Confirma cadastro (S/N):");
                if (resp.ToUpper() == "S")
                {
                    Emprestimo novoEmprestimo = new Emprestimo(this.codigo, this.livro, this.usuario, this.data, this.dataDevolucao);
                    bd.gravar("emprestimo", novoEmprestimo);

                    // Adiciona automaticamente ao histórico
                    bd.gravar("historico", new Historico(novoEmprestimo.Codigo, novoEmprestimo.Usuario, novoEmprestimo.Livro, novoEmprestimo.Data, novoEmprestimo.DataDevolucao));
                }
            }
        
            else
            {
                // alteração / exclusão
                Emprestimo obj = (Emprestimo)bd.recuperar("emprestimo", this.posicao);
                this.livro = obj.Livro;
                this.usuario = obj.Usuario;
                this.data = obj.Data;
                this.dataDevolucao = obj.DataDevolucao;
                this.nomeLivro = bd.recuperarNome("livro", this.livro);
                this.nomeUsuario = bd.recuperarNome("usuario", this.usuario);

                this.mostrarDados();

                resp = tl.fazerPergunta(26, 12, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(42, 7, 74, 10);
                    this.entrarDados();
                    resp = tl.fazerPergunta(26, 12, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        Emprestimo novoObj = new Emprestimo(this.codigo, this.livro, this.usuario, this.data, this.dataDevolucao);
                        bd.alterar("emprestimo", obj, novoObj);

                        // Atualiza automaticamente o histórico
                        int posicaoHistorico = bd.buscar("historico", this.codigo);
                        if (posicaoHistorico != -1)
                        {
                            bd.alterar("historico", bd.recuperar("historico", posicaoHistorico), new Historico(novoObj.Codigo, novoObj.Usuario, novoObj.Livro, novoObj.Data, novoObj.DataDevolucao));
                        }
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(26, 12, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("emprestimo", obj);

                        // Remove automaticamente do histórico
                        int posicaoHistorico = bd.buscar("historico", this.codigo);
                        if (posicaoHistorico != -1)
                        {
                            bd.excluir("historico", bd.recuperar("historico", posicaoHistorico));
                        }
                    }
                }
            }

            
        }
       
    

        public void montarTela()
        {
            tl.montarMoldura(25, 3, 75, 13, "Emprestimos");
            Console.SetCursorPosition(26, 6);
            Console.Write("Codigo         :");
            Console.SetCursorPosition(26, 7);
            Console.Write("Livro          :");
            Console.SetCursorPosition(26, 8);
            Console.Write("Usuário        :");
            Console.SetCursorPosition(26, 9);
            Console.Write("Data empréstimo:");
            Console.SetCursorPosition(26, 10);
            Console.Write("Data devolução :");
        }

        public void entrarCodigo()
        {
            Console.SetCursorPosition(42, 6);
            this.codigo = Console.ReadLine();
        }

        public void entrarDados()
        {
            Console.SetCursorPosition(42, 7);
            this.livro = Console.ReadLine();
            Console.SetCursorPosition(42 + this.livro.Length, 7);
            Console.Write(" - " + bd.recuperarNome("livro", this.livro));

            Console.SetCursorPosition(42, 8);
            this.usuario = Console.ReadLine();
            Console.SetCursorPosition(42 + this.usuario.Length, 8);
            Console.Write(" - " + bd.recuperarNome("usuario", this.usuario));

            Console.SetCursorPosition(42, 9);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime parsedDate))
            {
                this.data = parsedDate;
                Console.SetCursorPosition(42, 9);
                Console.Write(this.data.ToShortDateString());
            }
            Console.SetCursorPosition(42, 10);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime parsedDate1))
            {
                this.dataDevolucao = parsedDate1;
                Console.SetCursorPosition(42, 10);
                Console.Write(this.dataDevolucao.ToShortDateString());
            }
        }

         public void mostrarDados()
         {
             Console.SetCursorPosition(42, 7);
             Console.Write(this.livro + " - " + this.nomeLivro);
             Console.SetCursorPosition(42, 8);
             Console.Write(this.usuario + " - " + this.nomeUsuario);
             Console.SetCursorPosition(42, 9);
             Console.Write(this.data);
             Console.SetCursorPosition(42, 10);
             Console.Write(this.dataDevolucao);
         }
    }
}
