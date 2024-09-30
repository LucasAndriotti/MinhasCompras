using MinhasCompras.Models; // Importa o namespace que cont�m a classe Produto

namespace MinhasCompras.Views; // Define o namespace para a view EditarProduto

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
    {
        InitializeComponent(); // Inicializa os componentes da interface da p�gina
    }

    // Evento disparado ao clicar em um item da barra de ferramentas
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Obt�m o produto atualmente vinculado ao contexto da p�gina
            Produto produto_anexado = BindingContext as Produto;

            // Cria um novo objeto Produto com os dados que foram atualizados
            Produto p = new Produto()
            {
                Id = produto_anexado.Id, // Mant�m o ID do produto original para atualiza��o
                Descricao = txt_descricao.Text, // Recupera a descri��o do campo de texto
                Preco = Convert.ToDouble(txt_preco.Text), // Converte o pre�o inserido para double
                Quantidade = Convert.ToDouble(txt_quantidade.Text), // Converte a quantidade inserida para double
            };

            // Atualiza o produto no banco de dados
            await App.Database.Update(p);
            // Exibe um alerta de sucesso ao usu�rio
            await DisplayAlert("Sucesso", "Produto atualizado com sucesso", "OK");
            // Navega de volta para a p�gina principal
            await Navigation.PushAsync(new MainPage());
        }
        catch (Exception ex)
        {
            // Em caso de erro, exibe um alerta com a mensagem do erro
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}

