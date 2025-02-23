using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Service;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation
{
	public class MenuMutation : ObjectGraphType
	{
		public MenuMutation(IMenuRepository menu)
		{
			Field<MenuType>("CreateMenu").Arguments(new QueryArguments(new QueryArgument<MenuInputType> { Name = "menu" }))
			.Resolve(context =>
			{
				return menu.AddMenu(context.GetArgument<Menu>("menu"));
			});

			Field<MenuType>("UpdateMenu")
			.Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" } , new QueryArgument<MenuInputType> { Name = "menu" }))
			.Resolve(context =>
			{
				var menuu = context.GetArgument<Menu>("menu");
				var id = context.GetArgument<int>("menuId");
				return menu.UpdateMenu(id,menuu);	
			});

			Field<StringGraphType>("DeleteMenu").Arguments(new QueryArguments(new QueryArgument<IntGraphType> { Name = "menuId" }))
			.Resolve(context =>
			{
				var menuid = context.GetArgument<int>("menuId");
				 menu.DeleteMenu(menuid);
				return "The menu against this Id "+menuid + "has been deleted";
			});
		}
	}
}
