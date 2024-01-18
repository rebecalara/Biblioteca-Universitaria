using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    internal class UsuarioCRUD
    {
        private string codigo;
        private string nome;
        private string endereço;
        private string curso;
        private int inicioCurso;
        private int prevFimCurso;
        private Usuario.TipoUsuario tipo;
        public int limiteEmprestimo;
        private BancoDados bd;
        private Tela tl;
        private int posicao;

        public UsuarioCRUD(BancoDados banco, Tela tela)
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
            this.posicao = bd.buscar("usuario", this.codigo);

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
                        bd.gravar("usuario", new Usuario(this.codigo, this.nome, this.endereço, this.curso, this.inicioCurso, this.prevFimCurso, this.tipo));
                    }
                }
            }
            else
            {
                // alteração / exclusão
                Usuario obj = (Usuario)bd.recuperar("usuario", this.posicao);
                this.nome = obj.Nome;
                this.endereço = obj.Endereço;
                this.curso = obj.Curso;
                this.inicioCurso = obj.InicioCurso;
                this.prevFimCurso = obj.PrevFimCurso;
                this.tipo = obj.Tipo;
                this.limiteEmprestimo = obj.LimiteEmprestimo;

                this.mostrarDados();

                resp = tl.fazerPergunta(26, 15, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(42, 7, 74, 13);
                    this.entrarDados();
                    resp = tl.fazerPergunta(26, 15, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        Usuario novoObj = new Usuario(this.codigo, this.nome, this.endereço, this.curso, this.inicioCurso, this.prevFimCurso, this.tipo);
                        bd.alterar("usuario", obj, novoObj);
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(26, 15, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("usuario", obj);
                    }
                }
            }

        }

        public void montarTela()
        {
            tl.montarMoldura(25, 3, 75, 16, "Cadastro de Usuario");
            Console.SetCursorPosition(26, 6);
            Console.Write("Codigo         :");
            Console.SetCursorPosition(26, 7);
            Console.Write("Nome Completo  :");
            Console.SetCursorPosition(26, 8);
            Console.Write("Endereço       :");
            Console.SetCursorPosition(26, 9);
            Console.Write("Curso          :");
            Console.SetCursorPosition(26, 10);
            Console.Write("Inicio do Curso:");
            Console.SetCursorPosition(26, 11);
            Console.Write("Prev. Fim Curso:");
            Console.SetCursorPosition(26, 12);
            Console.Write("Tipo de Usuário:");
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
            this.endereço = Console.ReadLine();
            Console.SetCursorPosition(42, 9);
            this.curso = Console.ReadLine();
            Console.SetCursorPosition(42, 10);
            this.inicioCurso = int.Parse(Console.ReadLine());
            Console.SetCursorPosition(42, 11);
            this.prevFimCurso = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(42, 12);
            string tipoStr = Console.ReadLine();

            // Converte a string para o tipo Usuario.TipoUsuario
            if (Enum.TryParse(tipoStr, out Usuario.TipoUsuario tipoUsuario))
            {
                this.tipo = tipoUsuario;
            }
            else
            {
                Console.SetCursorPosition(26, 13);
                Console.WriteLine("Tipo de usuário inválido. Usando tipo padrão!");
                this.tipo = Usuario.TipoUsuario.Aluno; // Pode ser outro valor padrão se desejar
            }
        }

        public void mostrarDados()
        {
            Console.SetCursorPosition(42, 7);
            Console.Write(this.nome);
            Console.SetCursorPosition(42, 8);
            Console.Write(this.endereço);
            Console.SetCursorPosition(42, 9);
            Console.Write(this.curso);
            Console.SetCursorPosition(42, 10);
            Console.Write(this.inicioCurso);
            Console.SetCursorPosition(42, 11);
            Console.Write(this.prevFimCurso);
            Console.SetCursorPosition(42, 12);
            Console.Write(this.tipo);
            Console.SetCursorPosition(26, 13);
            Console.Write("Emprest. Limite: " + this.limiteEmprestimo);
        }
    }
}

