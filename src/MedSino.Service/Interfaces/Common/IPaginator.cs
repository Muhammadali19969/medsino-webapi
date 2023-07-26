using MedSino.DataAccess.Utils;

namespace MedSino.Service.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);

}
