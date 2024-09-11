using System.Threading.Tasks;

namespace CleanArchitecture1.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
