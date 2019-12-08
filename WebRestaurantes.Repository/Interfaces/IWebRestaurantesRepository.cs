using System.Threading.Tasks;
using WebRestaurantes.Domain;
using System.Collections.Generic;

namespace WebRestaurantes.Repository.Interfaces
{
    public interface IWebRestaurantesRepository
    {
          void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task <bool> SaveChangesAsync();

        Task <List<Restaurant>> GetAllRestaurantAsync(bool includeImages = false);

        Task <Restaurant> GetRestaurantAsyncById(int id, bool includeImages = false);

        Task<List<Restaurant>> GetRestaurantAsyncByText(string text);
    }
}