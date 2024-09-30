using MinhasCompras.Models; // Importa o namespace que contém a classe Produto

namespace MinhasCompras.Views; // Define o namespace para a view EditarProduto

public partial class EditarProduto : ContentPage
{
    public EditarProduto()
    {
        InitializeComponent(); // Inicializa os componentes da interface da página
    }

    // Evento disparado ao clicar em um item da barra de ferramentas
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Obtém o produto atualmente vinculado ao contexto da página
            Produto produto_anexado = BindingContext as Produto;

            // Cria um novo objeto Produto com os dados que foram atualizados
            Produto p = new Produto()
            {
                Id = produto_anexado.Id, // Mantém o ID do produto original para atualização
                Descricao = txt_descricao.Text, // Recupera a descrição do campo de texto
                Preco = Convert.ToDouble(txt_preco.Text), // Converte o preço inserido para double
                Quantidade = Convert.ToDouble(txt_quantidade.Text), // Converte a quantidade inserida para double
            };

            // Atualiza o produto no banco de dados
            await App.Database.Update(p);
            // Exibe um alerta de sucesso ao usuário
            await DisplayAlert("Sucesso", "Produto atualizado com sucesso", "OK");
            // Navega de volta para a página principal
            await Navigation.PushAsync(new MainPage());
        }
        catch (Exception ex)
        {
            // Em caso de erro, exibe um alerta com a mensagem do erro
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}

