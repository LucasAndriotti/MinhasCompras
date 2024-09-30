namespace MinhasCompras.Views; // Define o namespace para as views do aplicativo
using MinhasCompras.Models; // Importa o namespace que cont�m a classe Produto

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent(); // Inicializa os componentes da interface da p�gina
    }

    // Evento que � acionado ao clicar em um item da barra de ferramentas
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Cria um novo objeto Produto com os dados fornecidos pelo usu�rio
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text, // Recupera a descri��o do produto do campo de texto
                Quantidade = Convert.ToDouble(txt_quantidade.Text), // Converte a quantidade informada para double
                Preco = Convert.ToDouble(txt_preco.Text), // Converte o pre�o informado para double
            };

            // Insere o novo produto no banco de dados
            await App.Database.Insert(p);
            // Exibe uma mensagem de confirma��o ao usu�rio
            await DisplayAlert("Sucesso", "Produto adicionado com sucesso", "OK");
            // Navega de volta para a p�gina principal
            await Navigation.PushAsync(new MainPage());
        }
        catch (Exception ex)
        {
            // Se ocorrer um erro, exibe uma mensagem informativa
            await DisplayAlert("Erro", ex.Message, "Fechar");
        }
    }
}
