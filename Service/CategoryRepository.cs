using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Service
{
	public class CategoryRepository : ICategoryRepository
	{
		private GraphQLDbContext dbContext;
		public CategoryRepository(GraphQLDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public Category AddCategory(Category category)
		{
			dbContext.Categories.Add(category);
			dbContext.SaveChanges();
			return category;
		}
		public void DeleteCategory(int id)
		{
			var category = dbContext.Categories.FirstOrDefault(c => c.Id == id);
			dbContext.Categories.Remove(category);
			dbContext.SaveChanges();
		}

		public List<Category> GetCategories()
		{
			return dbContext.Categories.ToList();
		}

		public Category GetCategoryById(int id)
		{
			return dbContext.Categories.FirstOrDefault(x => x.Id == id);
		}

		public Category UpdateCategory(int id, Category category)
		{
			var newcat = dbContext.Categories.FirstOrDefault(x => x.Id == id);
			newcat.Name = category.Name;
			newcat.ImageUrl = category.ImageUrl;
			dbContext.SaveChanges();
			return category;
		}
	}
}
