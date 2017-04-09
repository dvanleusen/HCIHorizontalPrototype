using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CookingInstructorModel
{
   public class Data
    {

        private static Data instance;
        Dictionary<String, ObservableCollection<Recipe>> categories;

        private Data(){
            Categories = new Dictionary<String, ObservableCollection<Recipe>>();
            InitFakeData();
        }

        public static Data Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Data();
                }

                return instance;
            }
        }

        private Dictionary<String, ObservableCollection<Recipe>> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public ObservableCollection<KeyValuePair<String, ObservableCollection<Recipe>>> GetCategories()
        {
            ObservableCollection<KeyValuePair<String, ObservableCollection<Recipe>>> cat = new ObservableCollection<KeyValuePair<string, ObservableCollection<Recipe>>>();

            foreach (KeyValuePair<String, ObservableCollection<Recipe>> pair in categories){
                KeyValuePair<String, ObservableCollection<Recipe>> temp = new KeyValuePair<string, ObservableCollection<Recipe>>(pair.Key, pair.Value);
                cat.Add(temp);
            }
            return cat;
        }

        private ObservableCollection<Recipe> safeList(ObservableCollection<Recipe> recipes)
        {
            ObservableCollection<Recipe> temp = new ObservableCollection<Recipe>();
            foreach(Recipe r in recipes)
            {
                temp.Add(new Recipe(r));
            }
            return temp;
        }
        public ObservableCollection<Recipe> Search(String text, String sortBy)
        {
            if (Categories.ContainsKey(text))
            {
                ObservableCollection<Recipe> temp =  safeList(Categories[text]);
                if (sortBy.Equals("A-Z"))
                {
                    SortAlphabetical(temp, false);
                }
                else if (sortBy.Equals("Z-A"))
                {
                    SortAlphabetical(temp, true);
                }
                return temp;
            }
            return new ObservableCollection<Recipe>();
        }

        private void SortAlphabetical(ObservableCollection<Recipe> recipes, bool reverse)
        {
            for(int i = 0; i < recipes.Count() -1; i++)
            {
                for(int j = 0; j < recipes.Count - i - 1; j++)
                {
                    Recipe r1 = recipes.ElementAt(j);
                    Recipe r2 = recipes.ElementAt(j + 1);
                    if ((r1.Title.CompareTo(r2.Title) > 0 && !reverse) ||(r2.Title.CompareTo(r1.Title) > 0 && reverse))
                    {
                        recipes[j] = r2;
                        recipes[j + 1] = r1;
                    }
                }
            }
        }

        public void Add(String category, Recipe r)
        {
            if (Categories.ContainsKey(category))
            {
                Categories[category].Add(r);
            }
            else
            {
                Categories.Add(category, new ObservableCollection<Recipe>{r});
            }  

        }

        public void Remove(String category, Recipe r)
        {
            if (Categories.ContainsKey(category))
            {
                Categories[category].Remove(r);
            }
            if(Categories[category].Count == 0)
            {
                Categories.Remove(category);
            }
        }
        public bool Contains(String category, Recipe r)
        {
            if (Categories.ContainsKey(category))
            {
                return Categories[category].Contains(r);
            }
            return false;
        }

        public bool Contains(String category)
        {
            return Categories.ContainsKey(category);
        }

        private void InitFakeData()
        {

            ObservableCollection<String> e = new ObservableCollection<String>();
            ObservableCollection<Ingredient> i = new ObservableCollection<Ingredient>();

            //Lemon Chicken (in Recent and Chicken categories)
            ObservableCollection<String> instLemonChicken = new ObservableCollection<String>();
            instLemonChicken.Add("Mix 1 tbsp of soy sauce with 1 lb of chicken breast");
            instLemonChicken.Add("Sprinkle 1 tbsp of salt and pepper on top");
            instLemonChicken.Add("Add 1 egg to the meat and mix well with a spoon");
            instLemonChicken.Add("Add 3 tbsps of corn starch and mix again with a spoon");
            instLemonChicken.Add("Note: Chicken should be well coated at this time");
            instLemonChicken.Add("Heat up some oil on medium or high heat for frying");
            instLemonChicken.Add("Fry each piece thoroughly for 7-8 minutes until the coating turn golden brown");
            instLemonChicken.Add("Put the chicken aside");
            instLemonChicken.Add("Add 1 tbsp of oil to the pot, and heat up on medium or high heat");
            instLemonChicken.Add("Add 1 cup of chicken stock, 1/4 cup of lemon juice, 2 tbsps of sugar, 1 tbsp of honey, and 3 tbsps of slurry to the pot");
            instLemonChicken.Add("Note: If you want, you may add a few slices of lemon");
            instLemonChicken.Add("Boil 5-7 minutes for thicker consistency");
            instLemonChicken.Add("Add approximately 1/4 cup of lemon zest for color and flavor");
            instLemonChicken.Add("Add desired amount of sauce to the chicken and mix well");

            ObservableCollection<Ingredient> ingLemonChicken = new ObservableCollection<Ingredient>
            {
                new Ingredient(1, "lb(s) chicken breast", new ObservableCollection<Ingredient>{new Ingredient(1, "lb(s) turkey breast", null) }),
                new Ingredient(1, "tbsp(s) soy sauce", new ObservableCollection<Ingredient>()),
                new Ingredient(1, "tbsp(s) salt and pepper", new ObservableCollection<Ingredient>()),
                new Ingredient(1, "egg(s)", new ObservableCollection<Ingredient>()),
                new Ingredient(3, "tbsps corn starch", new ObservableCollection<Ingredient>{new Ingredient(3, "tbsps potato starch", null), new Ingredient(3, "tbsps tapioca", null), new Ingredient(3, "tbsps mashed potato granules", null) }),
                new Ingredient(1, "cup(s) chicken stock", new ObservableCollection<Ingredient>()),
                new Ingredient(0.25, "cup(s) lemon juice", new ObservableCollection<Ingredient>()),
                new Ingredient(2, "tbsps sugar", new ObservableCollection<Ingredient>()),
                new Ingredient(3, "tbsps slurry", new ObservableCollection<Ingredient> {new Ingredient(3, "tbsps corn starch and water mix", null) }),
                new Ingredient(0.25, "cup(s) lemon zest", new ObservableCollection<Ingredient>())
            };



            //Roast Chicken (in Chicken catergory)
            ObservableCollection<String> instRoastChicken = new ObservableCollection<String>();
            instRoastChicken.Add("Cut potatoes into wedges and lie them evenly in a deep baking dish");
            instRoastChicken.Add("Add 1 cup of baby carrots or any vegetables of your choice to the dish");
            instRoastChicken.Add("Sprinkle 2 tbsps of salt and pepper evenly on top of veggies");
            instRoastChicken.Add("Add 1 tbsp of olive oil and mix the veggies well");
            instRoastChicken.Add("Put the dish aside and prepare the spice mix");
            instRoastChicken.Add("Add 1 tbsp of chilli powder, 1 tbsp of garlic powder, 1 tbsp of salt and pepper into an empty bowl, and mix well");
            instRoastChicken.Add("Now prepare the chicken by cutting wing tips");
            instRoastChicken.Add("Smudge a even layer of olive oil on the chicken");
            instRoastChicken.Add("Sprinkle the prepared spice mix onto the chicken evenly, smudge a little if necessary");
            instRoastChicken.Add("Cut the lemon in half and squeeze its juice into the chicken");
            instRoastChicken.Add("Cut the onion inhalf and stuff the chicken along with 4-5 garlic cloves");
            instRoastChicken.Add("Tie the legs with aluminum string or foil");
            instRoastChicken.Add("Place the chicken into the deep baking dish, breast side up");
            instRoastChicken.Add("Preheat oven at 385 F");
            instRoastChicken.Add("Bake for 90 minutes");

            ObservableCollection<Ingredient> ingRoastChicken = new ObservableCollection<Ingredient>
            {
                new Ingredient(1, "whole chicken(s)", new ObservableCollection<Ingredient>{new Ingredient(1, "whole turkey(s)", null) }),
                new Ingredient(1, "tbsp(s) chilli powder", new ObservableCollection<Ingredient>{new Ingredient(1, "tbsp(s) paprika", null) }),
                new Ingredient(1, "tbsp(s) garlic powder", new ObservableCollection<Ingredient>()),
                new Ingredient(2, "tbsp(s) salt and pepper", new ObservableCollection<Ingredient>()),
                new Ingredient(1, "tbsp(s) olive oil", new ObservableCollection<Ingredient>()),
                new Ingredient(6, "potatoes", new ObservableCollection<Ingredient>()),
                new Ingredient(1, "cup(s) baby carrots", new ObservableCollection<Ingredient>{new Ingredient(1, "cup(s) any vegetables", null) }),
                new Ingredient(1, "onion(s)", new ObservableCollection<Ingredient>()),
                new Ingredient(1, "lemon(s)", new ObservableCollection<Ingredient>()),
                new Ingredient(5, "garlic cloves", new ObservableCollection<Ingredient>())
            };



            //Corn Salad (in Vegan catergory)
            ObservableCollection<String> instCornSalad = new ObservableCollection<String>();
            instCornSalad.Add("Boil corns for 10 minutes, then cut off kernels");
            instCornSalad.Add("Chop up scallions, tomatoes, parsley, and cilantro");
            instCornSalad.Add("Chop up jalapeno and clean out seeds");
            instCornSalad.Add("Mix all veggies well in a bowl");
            instCornSalad.Add("Cut a lime into half, and squeeze its juice into the bowl");
            instCornSalad.Add("Add a few drops of olive oil");
            instCornSalad.Add("Add a tbsp of salt and pepper");
            instCornSalad.Add("Mix the sald well and evenly");
            instCornSalad.Add("Note: You can put it into the fridge for 15 minutes to bring out the flavours further");

            ObservableCollection<Ingredient> ingCornSalad = new ObservableCollection<Ingredient>
            {
                new Ingredient(3, "yellow corns", new ObservableCollection<Ingredient>{new Ingredient(3, "white corns", null) }),
                new Ingredient(1, "lime(s)", new ObservableCollection<Ingredient> {new Ingredient(1, "lemon(s)", null) }),
                new Ingredient(2, "scallions", new ObservableCollection<Ingredient>()),
                new Ingredient(1, "jalapeno(s)", new ObservableCollection<Ingredient>{new Ingredient(1, "green pepper(s)", null) }),
                new Ingredient(1, "cup(s) cherry tomatoe", new ObservableCollection<Ingredient>{new Ingredient(3, "tomatoes", null) }),
                new Ingredient(0.5, "cup(s) parsley", new ObservableCollection <Ingredient>()),
                new Ingredient(0.5, "cup(s) cilantro", new ObservableCollection <Ingredient>{new Ingredient(1, "cup(s) any vegetables", null) }),
                new Ingredient(1, "tbsp(s) salt and pepper",new ObservableCollection <Ingredient>()),
            };


            //Tiramisu (in Dessert catergory)
            ObservableCollection<String> instTiramisu = new ObservableCollection<String>();
            instTiramisu.Add("Boil 1/2 cup of water and dissolve 2 tbsps of instant espresso, mix well");
            instTiramisu.Add("Optionally, add 50 mLs of Kahlua to the espresso, mix well and let it cool");
            instTiramisu.Add("In a different bowl, mix 6 egg yolks together well and evenly");
            instTiramisu.Add("Add 1 cup of sugar to the mixture");
            instTiramisu.Add("Slowly heat the mixture up on extremely low heat for about 10 minutes while mixing, until the mixture becomes smooth.\nNote: if the mixture becomes too thick, add 2 tbsps of milk.");
            instTiramisu.Add("Let the mixture cooldown, usually should take about 10 minutes as well");
            instTiramisu.Add("Add 1 cup of heavy cream to another empty bowl");
            instTiramisu.Add("Use a mixer or hand mixer to evenly mix the cream");
            instTiramisu.Add("While mixing, add a tbsp of vanilla extract");
            instTiramisu.Add("Mix until you have a nice thick texture for whipped cream");
            instTiramisu.Add("Add about 8 ozs of mascarpone cheese to the cooled egg yolk mixture, mix well");
            instTiramisu.Add("Add whipped cream, and fold the cream in with the mixture, mix well");
            instTiramisu.Add("Soak 2 boxes of Lady Fingers in the expresso mixture for no more than 2 seconds");
            instTiramisu.Add("Put a layer of Lady Fingers at the bottom of a deep baking dish");
            instTiramisu.Add("Evenly put a layer of the mixture over the Lady Fingers");
            instTiramisu.Add("Repeat the layers of Lady Fingers and the mixture on top");
            instTiramisu.Add("Cover the baking dish with aluminum oil and freeze for at least 8 hours");
            instTiramisu.Add("Spread a tbsp of coco powder on each slice of tiramisu");

            ObservableCollection<Ingredient> ingTiramisu = new ObservableCollection<Ingredient>
            {
                new Ingredient(2, "tbsps instant espresso", new ObservableCollection<Ingredient>()),
                new Ingredient(50, "mLs Kahlua", new ObservableCollection<Ingredient>()),
                new Ingredient(6, "egg yolks", new ObservableCollection<Ingredient>()),
                new Ingredient(1, "cup(s) sugar", new ObservableCollection<Ingredient>()),
                new Ingredient(1, "cup(s) heavy cream", new ObservableCollection<Ingredient>()),
                new Ingredient(1, "tbsp(s) vanilla extract", new ObservableCollection<Ingredient>()),
                 new Ingredient(8, "ozs mascarpone cheese", new ObservableCollection<Ingredient>{new Ingredient(8, "ozs ricotta or cream cheese", null) }),
                new Ingredient(2, "boxes Lady Fingers", new ObservableCollection<Ingredient>{new Ingredient(1, "lb(s) of cake baked to crispy", null) }),
                new Ingredient(1, "cup(s) coco powder", new ObservableCollection<Ingredient>())
            };


            Categories.Add("Recently Added", new ObservableCollection<Recipe>());
            Categories.Add("Chicken", new ObservableCollection<Recipe>());
            Categories.Add("Pork", new ObservableCollection<Recipe>());
            Categories.Add("Vegan", new ObservableCollection<Recipe>());
            Categories.Add("Dessert", new ObservableCollection<Recipe>());

            Categories["Recently Added"].Add(new Recipe("Deluxe Pizza", "", "", "", 4, e, i, "", "recent1.jpg"));
            Categories["Recently Added"].Add(new Recipe("Heart Attack Hamburger", "", "", "", 4, e, i, "", "recent2.jpg"));
            Categories["Recently Added"].Add(new Recipe("Deep Dish Pizza", "", "", "", 4, e, i, "", "recent3.jpg"));
            Categories["Recently Added"].Add(new Recipe("Lemon Chicken", "1h30m", "1h", "2h30m", 4, instLemonChicken, ingLemonChicken, "lemonChicken.wmv", "chicken1.jpg"));
            Categories["Recently Added"].Add(new Recipe("Spicy Rice Pork", "1h30m", "1h", "2h30m", 4, e, i, "", "recent4.jpg"));
            Categories["Recently Added"].Add(new Recipe("Pomegranate Salad", "", "", "", 4, e, i, "", "recent5.jpg"));
            Categories["Recently Added"].Add(new Recipe("Barbecued Ribs with Tomato", "", "", "", 4, e, i, "", "recent6.jpg"));
            Categories["Recently Added"].Add(new Recipe("Janyas Thai Noodles", "", "", "", 4, e, i, "", "recent7.jpg"));
            Categories["Recently Added"].Add(new Recipe("Asian Maple Sausage Meatballs", "", "", "", 4, e, i, "", "recent8.jpg"));
            Categories["Recently Added"].Add(new Recipe("Cabbage Spring Rolls", "", "", "", 4, e, i, "", "recent9.jpg"));
            Categories["Recently Added"].Add(new Recipe("Peanut Butter Brownie", "", "", "", 4, e, i, "", "recent10.jpg"));
            Categories["Recently Added"].Add(new Recipe("Vegetable Wrap", "", "", "", 4, e, i, "", "recent11.jpg"));
            //cook prep total
            Categories["Chicken"].Add(new Recipe("Lemon Chicken", "1h30m", "1h", "2h30m", 4, instLemonChicken, ingLemonChicken, "lemonChicken.wmv", "chicken1.jpg"));
            Categories["Chicken"].Add(new Recipe("Chicken Fajitas", "", "", "", 4, e, i, "", "chicken2.jpg"));
            Categories["Chicken"].Add(new Recipe("Bhel Puri", "", "", "", 4, e, i, "", "chicken3.jpg"));
            Categories["Chicken"].Add(new Recipe("Grilled Chicken", "", "", "", 4, e, i, "", "chicken4.jpg"));
            Categories["Chicken"].Add(new Recipe("Chicken Nachos with Black Olives", "", "", "", 4, e, i, "", "chicken5.jpg"));
            Categories["Chicken"].Add(new Recipe("Malaysian Honey Grilled Chicken", "", "", "", 4, e, i, "", "chicken6.jpg"));
            Categories["Chicken"].Add(new Recipe("Chicken Cacciatore", "", "", "", 4, e, i, "", "chicken7.jpg"));
            Categories["Chicken"].Add(new Recipe("Roast Chicken", "1h30m", "30m", "2h", 4, instRoastChicken, ingRoastChicken, "roastChicken.wmv", "chicken8.jpg"));
            Categories["Chicken"].Add(new Recipe("Kuku Paka Kenyan Chicken Curry", "", "", "", 4, e, i, "", "chicken9.jpg"));
            Categories["Chicken"].Add(new Recipe("Soy Garlic Chicken", "", "", "", 4, e, i, "", "chicken10.jpg"));

            Categories["Pork"].Add(new Recipe("Deluxe Pizza", "", "", "", 4, e, i, "", "recent1.jpg"));
            Categories["Pork"].Add(new Recipe("Heart Attack Hamburger", "", "", "", 4, e, i, "", "recent2.jpg"));
            Categories["Pork"].Add(new Recipe("Deep Dish Pizza", "", "", "", 4, e, i, "", "recent3.jpg"));
            Categories["Pork"].Add(new Recipe("Spicy Rice Pork", "", "", "", 4, e, i, "", "recent4.jpg"));
            Categories["Pork"].Add(new Recipe("Barbecued Ribs with Tomato", "", "", "", 4, e, i, "", "recent6.jpg"));
            Categories["Pork"].Add(new Recipe("Asian Maple Sausage Meatballs", "", "", "", 4, e, i, "", "recent8.jpg"));

            Categories["Vegan"].Add(new Recipe("Corn Salad", "0m", "15m", "15m", 4, instCornSalad, ingCornSalad, "cornSalad.wmv", "vegan1.jpg"));
            Categories["Vegan"].Add(new Recipe("Vegan Chili", "", "", "", 4, e, i, "", "vegan2.jpg"));
            Categories["Vegan"].Add(new Recipe("Vegan Pasta", "", "", "", 4, e, i, "", "vegan3.jpg"));
            Categories["Vegan"].Add(new Recipe("Filled Peppers", "", "", "", 4, e, i, "", "vegan4.jpg"));
            Categories["Vegan"].Add(new Recipe("Vegan Noodle Dish", "", "", "", 4, e, i, "", "vegan5.jpg"));
            Categories["Vegan"].Add(new Recipe("Mushroom Stir Fry", "", "", "", 4, e, i, "", "vegan6.jpg"));
            Categories["Vegan"].Add(new Recipe("Vegan Lasagna", "", "", "", 4, e, i, "", "vegan7.jpg"));
            Categories["Vegan"].Add(new Recipe("Tofu Curry", "", "", "", 4, e, i, "", "vegan8.jpg"));
            Categories["Vegan"].Add(new Recipe("Califlower Yellow Curry", "", "", "", 4, e, i, "", "vegan9.jpg"));
            Categories["Vegan"].Add(new Recipe("Bean Stew", "", "", "", 4, e, i, "", "vegan10.jpg"));
            Categories["Vegan"].Add(new Recipe("Pomegranate Salad", "", "", "", 4, e, i, "", "recent5.jpg"));
            Categories["Vegan"].Add(new Recipe("Janyas Thai Noodles", "", "", "", 4, e, i, "", "recent7.jpg"));
            Categories["Vegan"].Add(new Recipe("Cabbage Spring Rolls", "", "", "", 4, e, i, "", "recent9.jpg"));
            Categories["Vegan"].Add(new Recipe("Vegetable Wrap", "", "", "", 4, e, i, "", "recent11.jpg"));

            Categories["Dessert"].Add(new Recipe("Mint Brownie", "", "", "", 4, e, i, "", "dessert1.jpg"));
            Categories["Dessert"].Add(new Recipe("Gluten Free Cupcakes", "", "", "", 4, e, i, "", "dessert2.jpg"));
            Categories["Dessert"].Add(new Recipe("Cherry Pudding", "", "", "", 4, e, i, "", "dessert3.jpg"));
            Categories["Dessert"].Add(new Recipe("Tiramisu", "3h", "30m", "3h30m", 4, instTiramisu, ingTiramisu, "tiramisu.wmv", "dessert4.jpg"));
            Categories["Dessert"].Add(new Recipe("Black Forest Cake", "", "", "", 4, e, i, "", "dessert5.jpg"));
            Categories["Dessert"].Add(new Recipe("Red Velvet Sugar Cupcake", "", "", "", 4, e, i, "", "dessert6.jpg"));
            Categories["Dessert"].Add(new Recipe("Rasberry Pie", "", "", "", 4, e, i, "", "dessert7.jpg"));
            Categories["Dessert"].Add(new Recipe("Mango Mousse Cake", "", "", "", 4, e, i, "", "dessert8.jpg"));
            Categories["Dessert"].Add(new Recipe("Mini Lemon Meringue Pie", "", "", "", 4, e, i, "", "dessert9.jpg"));
            Categories["Dessert"].Add(new Recipe("Old-fashioned Chocolate Fudge", "", "", "", 4, e, i, "", "dessert10.jpg"));
            Categories["Dessert"].Add(new Recipe("Peanut Butter Brownie", "", "", "", 4, e, i, "", "recent10.jpg"));
        }
    }
}
