namespace DrinksInfo
{
    public class UserInput
    {
        DrinksService drinksService = new();

        public void GetCategoriesInput()
        {
            drinksService.GetCategories();
        }
    }
}
