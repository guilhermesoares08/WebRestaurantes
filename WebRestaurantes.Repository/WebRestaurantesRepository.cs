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
        public async Task<bool> SaveChangesAsync()
        {
            // retorno maior que 0 adicionou no bd
            return (await _webRestaurantesContext.SaveChangesAsync()) > 0;
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _webRestaurantesContext.RemoveRange(entityArray);
        }

        public async Task<List<Restaurant>> GetAllRestaurantAsync(bool includeImages = true)
        {
            IQueryable<Restaurant> query = _webRestaurantesContext.Restaurants;
            query = query.Include(d => d.Address);
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
            query = query.Include(r => r.Address)
                            .ThenInclude(a => a.City)
                            .ThenInclude(c => c.State);

            query = query.Include(r => r.Extensions)
                            .ThenInclude(r => r.DomainValue);
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
            query = query.Include(r => r.Images).Include(r => r.Address);
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