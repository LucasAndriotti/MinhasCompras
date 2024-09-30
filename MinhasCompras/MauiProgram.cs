using Microsoft.Extensions.Logging; // Importa o namespace para logging

namespace MinhasCompras
{
    public static class MauiProgram
    {
        // Método responsável por criar e configurar a aplicação Maui
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder(); // Cria um construtor para a aplicação Maui
            builder
                .UseMauiApp<App>() // Define a classe principal da aplicação como App
                .ConfigureFonts(fonts => // Configura as fontes utilizadas na aplicação
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); // Adiciona a fonte Regular
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold"); // Adiciona a fonte Semibold
                });

#if DEBUG
            builder.Logging.AddDebug(); // Adiciona logging de depuração se a aplicação estiver em modo DEBUG
#endif

            return builder.Build(); // Constrói e retorna a aplicação Maui configurada
        }
    }
}

