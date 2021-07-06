namespace FindViewModel
{
    public class FindViewModel
    {
        public FindViewModel()
        {
            FindBusinessLogic.FindBusinessLogic findUpdaterBusinessLogic = new FindBusinessLogic.FindBusinessLogic();
            SharedBusinessLogic.SharedBusinessLogic sharedBusinessLogic = new SharedBusinessLogic.SharedBusinessLogic();
            findUpdaterBusinessLogic.MonitorFileSystem(sharedBusinessLogic.EnumerateDrives());
        }
    }
}
