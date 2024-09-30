namespace MinhasCompras.Views; // Define o namespace para as views do aplicativo
using MinhasCompras.Models; // Importa o namespace que contém a classe Produto

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent(); // Inicializa os componentes da interface da página
    }

    // Evento que é acionado ao clicar em um item da barra de ferramentas
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Cria um novo objeto Produto com os dados fornecidos pelo usuário
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text, // Recupera a descrição do produto do campo de texto
                Quantidade = Convert.ToDouble(txt_quantidade.Text), // Converte a quantidade informada para double
                Preco = Convert.ToDouble(txt_preco.Text), // Converte o preço informado para double
            };

            // Insere o novo produto no banco de dados
            await App.Database.Insert(p);
            // Exibe uma mensagem de confirmação ao usuário
            await DisplayAlert("Sucesso", "Produto adicionado com sucesso", "OK");
            // Navega de volta para a página principal
            await Navigation.PushAsync(new MainPage());
        }
        catch (Exception ex)
        {
            // Se ocorrer um erro, exibe uma mensagem informativa
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }
}
