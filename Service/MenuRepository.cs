using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Service
{
	public class MenuRepository : IMenuRepository
	{
		private GraphQLDbContext _dbContext;
		public MenuRepository(GraphQLDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Menu AddMenu(Menu menu)
		{
			_dbContext.Menus.Add(menu);
			_dbContext.SaveChanges();
			return menu;
		}

		public void DeleteMenu(int id)
		{
			var delete = _dbContext.Menus.Find(id);
			_dbContext.Remove(delete);
			_dbContext.SaveChanges();
		}

		public List<Menu> GetAllMenu()
		{
			return _dbContext.Menus.ToList();
		}

		public Menu GetMenuById(int id)
		{
			return _dbContext.Menus.FirstOrDefault(m => m.Id == id);
		}

		public Menu UpdateMenu(int id, Menu menu)
		{
			var update = _dbContext.Menus.Find(id);
			update.Name = menu.Name;
			update.Description = menu.Description;
			update.Price = menu.Price;
			_dbContext.SaveChanges();
			return menu;
		}
	}
}