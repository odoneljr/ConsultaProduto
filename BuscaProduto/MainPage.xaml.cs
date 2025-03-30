using BuscaProduto.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace BuscaProduto
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Produto> produtos = new ObservableCollection<Produto>();
        private ObservableCollection<Produto> produtosFiltrados = new ObservableCollection<Produto>();
        
        public MainPage()
        {
            InitializeComponent();

            // Adicione alguns produtos de exemplo
            produtos.Add(new Produto { Nome = "Produto A", Descricao = "Descrição do Produto A" });
            produtos.Add(new Produto { Nome = "Produto B", Descricao = "Descrição do Produto B" });
            produtos.Add(new Produto { Nome = "Produto C", Descricao = "Descrição do Produto C" });

            // Inicialmente, exiba todos os produtos
            produtosFiltrados = new ObservableCollection<Produto>(produtos);
            ListaProdutos.ItemsSource = produtosFiltrados;
        }

        // COLOQUE O CÓDIGO AQUI:
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string textoPesquisa = e.NewTextValue;

            if (string.IsNullOrWhiteSpace(textoPesquisa))
            {
                // Se a pesquisa estiver vazia, exiba todos os produtos
                produtosFiltrados.Clear();
                foreach (var produto in produtos)
                {
                    produtosFiltrados.Add(produto);
                }
            }
            else
            {
                // Filtre os produtos com base no texto da pesquisa
                var resultados = produtos.Where(p => p.Nome.Contains(textoPesquisa, StringComparison.OrdinalIgnoreCase)).ToList();

                produtosFiltrados.Clear();
                foreach (var produto in resultados)
                {
                    produtosFiltrados.Add(produto);
                }
            }
        }

    }

}
