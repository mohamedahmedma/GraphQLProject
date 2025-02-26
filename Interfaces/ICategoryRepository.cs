﻿using GraphQLProject.Models;

namespace GraphQLProject.Interfaces
{
	public interface ICategoryRepository
	{
		List<Category> GetCategories();
		Category GetCategoryById(int id);
		Category AddCategory(Category category);
		Category UpdateCategory(int id , Category category);
		void DeleteCategory(int id);
	}
}
