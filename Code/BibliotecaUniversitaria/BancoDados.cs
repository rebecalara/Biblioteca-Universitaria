using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUniversitaria
{
    // esta classe fornece serviço de guarda dos dados
    public class BancoDados
    {
        List<Editora> editoras = new List<Editora>();
        List<Autor> autores = new List<Autor>();
        List<Livro> livros = new List<Livro>();
        List<Usuario> usuarios = new List<Usuario>();
        internal List<Emprestimo> emprestimos = new List<Emprestimo>();
        internal List<Historico> historicos = new List<Historico>(); 

        public BancoDados()
        {
            this.editoras.Add(new Editora("001", "Rocco"));

            this.autores.Add(new Autor("001", "Francisco Bolart", "Francês"));
            this.autores.Add(new Autor("002", "Alexandre Otrowiecki", "Brasileiro"));

            this.usuarios.Add(new Usuario("001", "Rebeca Lara de Souza", "R. Frederico, 396 - Santo Antonio", "Engenharia de Software", 2023, 2026, Usuario.TipoUsuario.Aluno));
            this.usuarios.Add(new Usuario("002", "Stéfani Paula Sant'ana ", "R. Palmeiras, 490 - América", "Engenharia de Software", 2023, 2026, Usuario.TipoUsuario.Aluno));
            this.usuarios.Add(new Usuario("003", "Paulo Manseira", "R. Visconde, 427 - Centro", "Engenharia de Software", -1, -1, Usuario.TipoUsuario.Professor));
            this.usuarios.Add(new Usuario("004", "Laíza Carolina da Silva", "R. Taunay, 437 - Centro", null, -1,-1, Usuario.TipoUsuario.Funcionario));

            this.livros.Add(new Livro("001", "A Dama", "1", "1", "Romance", "Português", "Físico", 2012));

            this.emprestimos.Add(new Emprestimo("001", "001", "001", new DateTime(2023, 11, 29), new DateTime(2023, 12, 04)));

            this.historicos.Add(new Historico("001", "001", "001", new DateTime(2023, 11, 29), new DateTime(2023, 12, 04)));
            this.historicos.Add(new Historico("002", "002", "001", new DateTime(2023, 12, 02), new DateTime(2023, 12, 10)));
        }


        public int buscar(string onde, string oque)
        {
            int posicao = -1;

            if (onde == "editora") posicao = this.editoras.FindIndex(o => o.Codigo == oque);

            if (onde == "autor") posicao = this.autores.FindIndex(o => o.Codigo == oque);

            if (onde == "livro") posicao = this.livros.FindIndex(o => o.Codigo == oque);

            if (onde == "usuario") posicao = this.usuarios.FindIndex(o => o.Codigo == oque);

            if (onde == "emprestimo") posicao = this.emprestimos.FindIndex(o => o.Codigo == oque);

            return posicao;
        }


        public object recuperar(string onde, int qual)
        {
            Object obj = null;
            if (onde == "editora") obj = this.editoras[qual];
            if (onde == "autor") obj = this.autores[qual];
            if (onde == "livro") obj = this.livros[qual];
            if (onde == "usuario") obj = this.usuarios[qual];
            if (onde == "emprestimo") obj = this.emprestimos[qual];
            return obj;
        }


        public void gravar(string onde, Object oque)
        {
            if (onde == "editora") this.editoras.Add((Editora)oque);
            if (onde == "autor") this.autores.Add((Autor)oque);
            if (onde == "livro") this.livros.Add((Livro)oque);
            if (onde == "usuario") this.usuarios.Add((Usuario)oque);
            if (onde == "emprestimo") this.emprestimos.Add((Emprestimo)oque);
        }


        public void alterar(string onde, Object oque, Object novo)
        {
            if (onde == "editora")
            {
                int x = this.buscar("editora", ((Editora)oque).Codigo);
                this.editoras[x] = (Editora)novo;
            }

            if (onde == "autor")
            {
                int x = this.buscar("autor", ((Autor)oque).Codigo);
                this.autores[x] = (Autor)novo;
            }

            if (onde == "livro")
            {
                int x = this.buscar("livro", ((Livro)oque).Codigo);
                this.livros[x] = (Livro)novo;
            }

            if (onde == "usuario")
            {
                int x = this.buscar("usuario", ((Usuario)oque).Codigo);
                this.usuarios[x] = (Usuario)novo;
            }

            if (onde == "emprestimo")
            {
                int x = this.buscar("emprestimo", ((Emprestimo)oque).Codigo);
                this.emprestimos[x] = (Emprestimo)novo;
            }
        }


        public void excluir(string onde, Object oque)
        {
            if (onde == "editora") this.editoras.Remove((Editora)oque);
            if (onde == "autor") this.autores.Remove((Autor)oque);
            if (onde == "livro") this.livros.Remove((Livro)oque);
            if (onde == "usuario") this.usuarios.Remove((Usuario)oque);
            if (onde == "emprestimo") this.emprestimos.Remove((Emprestimo)oque);
        }


        public string recuperarNome(string onde, string oque)
        {
            string result = "Não cadastrado";
            int pos = this.buscar(onde, oque);

            if (pos >= 0)
            {
                if (onde == "autor") result = this.autores[pos].Nome;
                if (onde == "editora") result = this.editoras[pos].Nome;
                if (onde == "livro") result = this.livros[pos].Titulo;
                if (onde == "usuario") result = this.usuarios[pos].Nome;
            }

            return result;
        }

    }
}

