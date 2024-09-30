using MinhasCompras.Helpers; // Importa a classe de helpers que contém a lógica para acesso ao banco de dados

namespace MinhasCompras
{
    public partial class App : Application
    {
        // Declara uma variável estática para o helper do banco de dados
        static SQLiteDatabaseHelper database;

        // Propriedade para acessar a instância do helper do banco de dados
        public static SQLiteDatabaseHelper Database
        {
            get
            {
                // Verifica se a instância do banco de dados já foi criada
                if (database == null)
                {
                    // Define o caminho do banco de dados no armazenamento local do dispositivo
                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "arquivo.db3");
                    // Cria uma nova instância do helper do banco de dados usando o caminho especificado
                    database = new SQLiteDatabaseHelper(path);
                }
                // Retorna a instância existente do helper do banco de dados
                return database;
            }
        }

        public App()
        {
            InitializeComponent(); // Inicializa os componentes principais da aplicação

            // Define a cultura atual para "pt-BR" (Português - Brasil)
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");

            // Define a página inicial da aplicação como AppShell
            MainPage = new AppShell();
        }
    }
}
