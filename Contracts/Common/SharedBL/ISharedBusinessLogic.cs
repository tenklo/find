using System.Collections.Generic;

namespace Contracts.Common.SharedBL
{
    public interface ISharedBusinessLogic
    {
        List<Models.Directory> EnumerateDrives();
    }
}
