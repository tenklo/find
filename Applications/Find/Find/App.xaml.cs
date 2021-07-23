using System.Windows;

namespace Find
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //It has to be invoked with the Dispatcher (UI Thread) 
            Dispatcher.Invoke(() => new Bootstrapper());
        }
    }
}
