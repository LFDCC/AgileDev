using AgileDev.Application.App;
using AgileDev.Core.Record;
using AgileDev.Entity;

namespace AgileDev.Application.Record
{
    public class RecordAppServices : AppServices<T_Record>, IRecordAppServices
    {
        IRecordBaseServices recordServices;

        public RecordAppServices(IRecordBaseServices _recordServices)
        {
            recordServices = _recordServices;
        }

    }
}
