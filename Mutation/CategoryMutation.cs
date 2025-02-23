using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Service;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation
{
	public class CategoryMutation : ObjectGraphType
	{
		public CategoryMutation(ICategoryRepository categoryRepository)
		{
			Field<CategoryType>("CreateCategory").Arguments(new QueryArguments(new QueryArgument<CategoryInputType> { Name = "category" }))
			.Resolve(context =>
			{
				return categoryRepository.AddCategory(context.GetArgument<Category>("category"));
			});

			Field<MenuType>("UpdateCategory")
			.Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "categoryId" } , new QueryArgument<CategoryInputType> { Name = "category" }))
			.Resolve(context =>
			{
				var category = context.GetArgument<Category>("category");
				var id = context.GetArgument<int>("categoryId");
				return categoryRepository.UpdateCategory(id,category);	
			});

			Field<StringGraphType>("DeleteMenu").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }))
			.Resolve(context =>
			{
				var categoryid = context.GetArgument<int>("categoryId");
				 categoryRepository.DeleteCategory(categoryid);
				return "The menu against this Id "+ categoryid + "has been deleted";
			});
		}
	}
}
