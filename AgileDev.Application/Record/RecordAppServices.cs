using AgileDev.Application.Record;
using AgileDev.Core.Entity;
using AgileDev.Core.Record;
using AgileDev.Core.User;

namespace AgileDev.Application.User
{
    public class RecordAppServices : AppServices<T_Record>, IRecordAppServices
    {
        private IRecordBaseServices recordServices { get; }
        public RecordAppServices(IRecordBaseServices _recordServices)
        {
            recordServices = _recordServices;
        }

    }
}
