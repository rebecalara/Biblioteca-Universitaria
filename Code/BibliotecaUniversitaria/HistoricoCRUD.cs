using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    internal class HistoricoCRUD
    {
        private string codigoEmprestimo, livro, usuario;
        private DateTime dataEmprestimo, dataDevolucao;
        private BancoDados bd;
        private Tela tl;

        public HistoricoCRUD(BancoDados banco, Tela tela)
        {
            this.bd = banco;
            this.tl = tela;
        }

        public void executarCRUD()
        {
            List<string> historicoMenu = new List<string>
            {
            "1 - Histórico de todos os usuários",
            "0 - Voltar"
            };

            while (true)
            {
                tl.montarTelaSistema("Histórico de Empréstimos");
                string opHistorico = tl.mostrarMenu(historicoMenu, 3, 3);

                if (opHistorico == "0") break;
                if (opHistorico == "1") exibirHistoricoTodosUsuarios();
            }
        }

        private void exibirHistoricoTodosUsuarios()
        {
            List<Historico> historicoCompleto = obterHistoricoCompleto();
            exibirHistorico(historicoCompleto);
        }

        private void exibirHistorico(List<Historico> historico)
        {
            tl.montarMoldura(3, 8, 79, 24, "Histórico de Empréstimos");

            if (historico.Count == 0)
            {
                Console.SetCursorPosition(4, 11);
                Console.WriteLine("Nenhum histórico encontrado.");
            }
            else
            {

                int linhaAtual = 11;

                foreach (var item in historico)
                {
                    Console.SetCursorPosition(4, linhaAtual);
                    Console.WriteLine($"Código: {item.CodigoEmprestimo}");

                    Console.SetCursorPosition(4, linhaAtual + 1);
                    string codigoLivro = item.Livro;
                    string nomeLivro = bd.recuperarNome("livro", codigoLivro);
                    Console.WriteLine($"Livro: {codigoLivro} - {nomeLivro}");


                    Console.SetCursorPosition(4, linhaAtual + 2);
                    string codigoUsuario = item.Usuario;
                    string nomeUsuario = bd.recuperarNome("usuario", codigoUsuario);
                    Console.WriteLine($"Usuário: {codigoUsuario} - {nomeUsuario}");


                    Console.SetCursorPosition(4, linhaAtual + 3);
                    Console.WriteLine($"Data Empréstimo: {item.DataEmprestimo}");
                    Console.SetCursorPosition(4, linhaAtual + 4);
                    Console.WriteLine($"Data Devolução: {item.DataDevolucao}");

                    linhaAtual += 7;
                }
            }

            Console.ReadLine();
        }

        public List<Historico> obterHistoricoCompleto()
        {
            return bd.historicos;
        }

    }
}