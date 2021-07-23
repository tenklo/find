using Contracts.Common.SharedBL;
using Contracts.Common.SharedVM;
using Contracts.Modules.Find.FindVM;
using SharedViewModel;
using SimpleInjector;
using System.Threading;

namespace Find
{
    public class Bootstrapper
    {
        private readonly Container _container;

        public Bootstrapper()
        {
            _container = new Container();

            InitializeDependencies();
            LaunchApplication();
        }

        private void InitializeDependencies()
        {
            _container.Register<IFileViewModel, FileViewModel>(Lifestyle.Singleton);
            _container.Register<IDirectoryViewModel, DirectoryViewModel>(Lifestyle.Singleton);

            _container.Register<ISharedBusinessLogic, SharedBusinessLogic.SharedBusinessLogic>(Lifestyle.Singleton);

#if DEBUG
            _container.Verify();
#endif

        }

        public void LaunchApplication()
        {
            var window = new MainWindow();
            var findViewModelInstance = new FindViewModel.FindViewModel(_container.GetInstance<ISharedBusinessLogic>());
            window.DataContext = findViewModelInstance;
            window.Show();
        }
    }
}
