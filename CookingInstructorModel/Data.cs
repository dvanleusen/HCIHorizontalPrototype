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

        ObservableCollection<Recipe> recipes;
        ObservableCollection<KeyValuePair<String, ObservableCollection<Recipe>>> categories;
        ObservableCollection<Recipe> myRecipes;

        private Data(){
            myRecipes = new ObservableCollection<Recipe>();
            Categories = new ObservableCollection<KeyValuePair<string, ObservableCollection<Recipe>>>();
            Recipes = new ObservableCollection<Recipe>();
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

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }

        public ObservableCollection<Recipe> MyRecipes
        {
            get { return myRecipes; }
            set { myRecipes = value; }
        }

        public ObservableCollection<KeyValuePair<String, ObservableCollection<Recipe>>> Categories
        {
            get {
                return categories; }
            set { categories = value; }
        }

        public void AddToMyRecipes(Recipe r)
        {
            myRecipes.Add(r);
        }

        public ObservableCollection<Recipe> Search(String text)
        {
            foreach(KeyValuePair<String, ObservableCollection<Recipe>> pair in Categories)
            {
                if (pair.Key.Equals(text)) return pair.Value;
            }
            return new ObservableCollection<Recipe>();
        }
        private void InitFakeData()
        {
            // public Recipe(String t, Double cookT, Double prepT, int serves, List<String> instruct, String video, String imagePath)
            ObservableCollection<Recipe> vegan = new ObservableCollection<Recipe>();
            List<String> e = new List<String>();
            List<Ingredient> i = new List<Ingredient>
            {
                new Ingredient(2,"tsp sugar", new List<Ingredient>()),
                new Ingredient(1, "apple", new List<Ingredient> { new Ingredient(1, "peach", new List<Ingredient>()) }),
                new Ingredient (1, "tbsp butter", new List<Ingredient> {new Ingredient(1, "tbsp margrin", new List<Ingredient>()) }) 
            };
 
            vegan.Add(new Recipe("Corn Salad", 100, 200, 4, e, i, "", "vegan1.jpg"));
            vegan.Add(new Recipe( "Vegan Chili", 100, 200, 4, e, i, "", "vegan2.jpg"));
            vegan.Add(new Recipe("Vegan Pasta", 100, 200, 4, e , i, "", "vegan3.jpg"));
            vegan.Add(new Recipe("Filled Peppers", 100, 200, 4, e, i, "", "vegan4.jpg"));
            vegan.Add(new Recipe("Vegan Noodle Dish", 100, 200, 4, e, i, "", "vegan5.jpg"));
            vegan.Add(new Recipe("Mushroom Stir Fry", 100, 200, 4, e, i , "", "vegan6.jpg"));
            vegan.Add(new Recipe("Vegan Lasagna", 100, 200, 4, e, i, "", "vegan7.jpg" ));
            vegan.Add(new Recipe("Tofu Curry", 100, 200, 4, e, i,  "", "vegan8.jpg"));
            vegan.Add(new Recipe("Califlower Yellow Curry", 100, 200, 4, e, i, "", "vegan9.jpg"));
            vegan.Add(new Recipe("Bean Stew", 100, 200, 4, e, i, "", "vegan10.jpg"));

            Categories.Add(new KeyValuePair<string, ObservableCollection<Recipe>>("Vegan", vegan));

            ObservableCollection<Recipe> recentlyAdded = new ObservableCollection<Recipe>();

            recentlyAdded.Add(new Recipe("Deluxe Pizza", 100, 200, 4, e, i, "", "recent1.jpg"));
            recentlyAdded.Add(new Recipe("Heart Attack Hamburger", 100, 200, 4, e, i,  "", "recent2.jpg"));
            recentlyAdded.Add(new Recipe("Deep Dish Pizza", 100, 200, 4, e, i,  "", "recent3.jpg"));
         
            Categories.Add(new KeyValuePair<string, ObservableCollection<Recipe>>("Recently Added", recentlyAdded));

            Recipes.Add(new Recipe("Califlower Yellow Curry", 100, 200, 4, e, i, "", "vegan9.jpg"));
            Recipes.Add(new Recipe("Bean Stew", 100, 200, 4, e, i, "", "vegan10.jpg"));

        }

    }
}
