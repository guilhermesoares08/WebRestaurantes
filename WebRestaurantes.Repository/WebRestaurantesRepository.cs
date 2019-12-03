using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebRestaurantes.Domain;
using WebRestaurantes.Repository.DataContext;
using System.Text.Json.Serialization;

namespace WebRestaurantes.Repository
{
    public class WebRestaurantesRepository : Interfaces.IWebRestaurantesRepository
    {
        private readonly WebRestaurantesContext _webRestaurantesContext;
        public WebRestaurantesRepository(WebRestaurantesContext WebRestaurantesContext)
        {
            _webRestaurantesContext = WebRestaurantesContext;
            _webRestaurantesContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            _webRestaurantesContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _webRestaurantesContext.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _webRestaurantesContext.Update(entity);
        }
        public async Task<bool> SaveChanges()
        {
            // retorno maior que 0 adicionou no bd
            return (await _webRestaurantesContext.SaveChangesAsync()) > 0;
        }

        public async Task<List<Restaurant>> GetAllRestaurantAsync(bool includeImages = true)
        {
            IQueryable<Restaurant> query = _webRestaurantesContext.Restaurants;
            if (includeImages)
            {
                query = query.Include(r => r.Images);
            }
            query = query.AsNoTracking().OrderBy(p => p.Description);
            return await query.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantAsyncById(int id, bool includeImages = true)
        {
            IQueryable<Restaurant> query = _webRestaurantesContext.Restaurants;
            if (includeImages)
            {
                query = query.Include(r => r.Images);
            }
            query = query.AsNoTracking().Where(r => r.Id.Equals(id));
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Restaurant>> GetRestaurantAsyncByText(string text)
        {
            IQueryable<Restaurant> query = _webRestaurantesContext.Restaurants;
            query = query.Include(r => r.Images);
            if (!string.IsNullOrEmpty(text))
            {
                text = text.ToLower();

                query = query.AsNoTracking().Where(r => r.Description.ToLower().Contains(text));

            }
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }
    }
}