using BibliotecaUniversitaria;

Tela tela = new Tela();
BancoDados bancoDados = new BancoDados();
EditoraCRUD editora = new EditoraCRUD(bancoDados, tela);
AutorCRUD autor = new AutorCRUD(bancoDados, tela);
LivroCRUD livro = new LivroCRUD(bancoDados, tela);
UsuarioCRUD usuario = new UsuarioCRUD(bancoDados, tela);
EmprestimoCRUD emprestimo = new EmprestimoCRUD(bancoDados, tela);
HistoricoCRUD historico = new HistoricoCRUD(bancoDados, tela);

List<string> menu = new List<string>();
menu.Add("1 - Editoras ");
menu.Add("2 - Autores  ");
menu.Add("3 - Livros   ");
menu.Add("4 - Usuarios");
menu.Add("5 - Emprestimo");
menu.Add("6 - Histórico");
menu.Add("0 - Sair");

string op;

while (true)
{
    tela.montarTelaSistema("Biblioteca Universitária");
    op = tela.mostrarMenu(menu, 3, 3);

    if (op == "0") break;
    if (op == "1") editora.executarCRUD();
    if (op == "2") autor.executarCRUD();
    if (op == "3") livro.executarCRUD();
    if (op == "4") usuario.executarCRUD();
    if (op == "5") emprestimo.executarCRUD();
    if (op == "6") historico.executarCRUD();
}