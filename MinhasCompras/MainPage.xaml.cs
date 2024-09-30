using System.Collections.ObjectModel; // Importa a classe ObservableCollection
using MinhasCompras.Models; // Importa o namespace que contém as models do aplicativo

namespace MinhasCompras
{
    public partial class MainPage : ContentPage
    {
        // Cria uma coleção observável para armazenar produtos
        ObservableCollection<Produto> lista_produtos = new ObservableCollection<Produto>();

        public MainPage()
        {
            InitializeComponent(); // Inicializa os componentes da interface da página
            lst_produtos.ItemsSource = lista_produtos; // Define a fonte de dados da lista de produtos
        }

        // Evento acionado ao clicar em um botão da barra de ferramentas
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            // Implementação futura pode ser adicionada aqui
        }

        // Evento que é acionado quando o texto do campo de pesquisa é modificado
        private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string q = e.NewTextValue; // Captura o novo texto do campo de pesquisa
            lista_produtos.Clear(); // Limpa a lista atual de produtos exibidos

            // Busca produtos no banco de dados que correspondem ao texto de pesquisa
            List<Produto> tmp = await App.Database.Search(q);
            foreach (Produto p in tmp)
            {
                lista_produtos.Add(p); // Adiciona os produtos encontrados à lista
            }
        }

        // Evento acionado quando um item da lista de produtos é selecionado
        private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Produto? p = e.SelectedItem as Produto; // Obtém o produto que foi selecionado

            // Navega para a página de edição do produto, passando o produto como contexto
            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p
            });
        }

        // Evento que é acionado ao clicar em um item do menu
        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                MenuItem selecionado = (MenuItem)sender; // Obtém o item do menu que foi clicado
                Produto p = selecionado.BindingContext as Produto; // Obtém o produto correspondente ao item do menu
                bool confirm = await DisplayAlert("Tem Certeza?", "Remover Produto", "Sim", "Não"); // Solicita confirmação para remoção

                if (confirm)
                {
                    await App.Database.Delete(p.Id); // Remove o produto do banco de dados
                    await DisplayAlert("Sucesso!", "Produto removido com sucesso", "OK"); // Mensagem de sucesso
                    lista_produtos.Remove(p); // Remove o produto da lista exibida
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "Fechar"); // Exibe mensagem de erro, se ocorrer
            }
        }

        // Evento para calcular e exibir o total dos produtos
        private void ToolbarItem_Clicked_Somar(object sender, EventArgs e)
        {
            double soma = lista_produtos.Sum(i => i.Total); // Calcula a soma dos totais dos produtos
            string msg = $"O total dos produtos é {soma:C}"; // Formata a mensagem com o total
            DisplayAlert("Resultado", msg, "Fechar"); // Exibe a mensagem com o total
        }

        // Evento acionado ao clicar para adicionar um novo produto
        private async void ToolbarItem_Clicked_Add(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.NovoProduto()); // Navega para a página de criação de novo produto
        }

        // Método chamado quando a página está prestes a aparecer
        protected async override void OnAppearing()
        {
            if (lista_produtos.Count == 0) // Verifica se a lista de produtos está vazia
            {
                List<Produto> tmp = await App.Database.GetAll(); // Obtém todos os produtos do banco de dados
                foreach (Produto p in tmp)
                {
                    lista_produtos.Add(p); // Adiciona os produtos à lista exibida
                }
            }
        }
    }
}
