namespace DrinksInfo
{
    public class UserInput
    {
        DrinksService drinksService = new();

        public void GetCategoriesInput()
        {
            var categories = drinksService.GetCategories();

            Console.WriteLine("Choose category:");

            string category = Console.ReadLine();

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category");
                category = Console.ReadLine();
            }

            if(!categories.Any(x => x.strCategory == category))
            {
                Console.Write("Category doesn't exist.");
                GetCategoriesInput();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            var drinks = DrinksService.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category menu by typing 0:");

            string drink = Console.ReadLine();

            if (drink == "0") GetCategoriesInput();

            while (!Validator.IsIdValid(drink))
            {
                Console.Write("\nInvalid drink");
                drink = Console.ReadLine();
            }

            if (!drinks.Any(x => x.idDrink == drink))
            {
                Console.Write("Drink doesn't exist.");
                GetDrinksInput(category);

            }
            drinksService.GetDrink(drink);

            Console.Write("Press any key to go back");
            Console.ReadKey();
            if (!Console.KeyAvailable) GetCategoriesInput();
        }



    }
}
