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
        Dictionary<String, List<Recipe>> categories;

        private Data(){
            Categories = new Dictionary<String, List<Recipe>>();
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

        private Dictionary<String, List<Recipe>> Categories
        {
            get { return categories; }
            set { categories = value; }
        }

        public ObservableCollection<KeyValuePair<String, ObservableCollection<Recipe>>> GetCategories()
        {
            ObservableCollection<KeyValuePair<String, ObservableCollection<Recipe>>> cat = new ObservableCollection<KeyValuePair<string, ObservableCollection<Recipe>>>();

            foreach (KeyValuePair<String, List<Recipe>> pair in categories){
                KeyValuePair<String, ObservableCollection<Recipe>> temp = new KeyValuePair<string, ObservableCollection<Recipe>>(pair.Key, new ObservableCollection<Recipe>(pair.Value));
                cat.Add(temp);
            }
            return cat;
        }

        public ObservableCollection<Recipe> Search(String text)
        {
            if (Categories.ContainsKey(text))
            {
                return new ObservableCollection<Recipe>(Categories[text]);
            }
            return new ObservableCollection<Recipe>();
        }

        public void Add(String category, Recipe r)
        {
            if (Categories.ContainsKey(category))
            {
                Categories[category].Add(r);
            }
            else
            {
                Categories.Add(category, new List<Recipe> {r});
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

        private void InitFakeData()
        {

            List<String> e = new List<String>();
            List<Ingredient> i = new List<Ingredient>
            {
                new Ingredient(2,"tsp sugar", new List<Ingredient>()),
                new Ingredient(1, "apple", new List<Ingredient> { new Ingredient(1, "peach", null), new Ingredient(4, "cups apple juice", null) }),
                new Ingredient (1, "tbsp butter", new List<Ingredient> {new Ingredient(1, "tbsp margrin", null) })
            };

            Categories.Add("Recently Added", new List<Recipe>());
            Categories.Add("Vegan", new List<Recipe>());

            Categories["Vegan"].Add(new Recipe("Corn Salad", 100, 200, 4, e, i, "", "vegan1.jpg"));
            Categories["Vegan"].Add(new Recipe("Vegan Chili", 100, 200, 4, e, i, "", "vegan2.jpg"));
            Categories["Vegan"].Add(new Recipe("Vegan Pasta", 100, 200, 4, e, i, "", "vegan3.jpg"));
            Categories["Vegan"].Add(new Recipe("Filled Peppers", 100, 200, 4, e, i, "", "vegan4.jpg"));
            Categories["Vegan"].Add(new Recipe("Vegan Noodle Dish", 100, 200, 4, e, i, "", "vegan5.jpg"));
            Categories["Vegan"].Add(new Recipe("Mushroom Stir Fry", 100, 200, 4, e, i, "", "vegan6.jpg"));
            Categories["Vegan"].Add(new Recipe("Vegan Lasagna", 100, 200, 4, e, i, "", "vegan7.jpg"));
            Categories["Vegan"].Add(new Recipe("Tofu Curry", 100, 200, 4, e, i, "", "vegan8.jpg"));
            Categories["Vegan"].Add(new Recipe("Califlower Yellow Curry", 100, 200, 4, e, i, "", "vegan9.jpg"));
            Categories["Vegan"].Add(new Recipe("Bean Stew", 100, 200, 4, e, i, "", "vegan10.jpg"));


            Categories["Recently Added"].Add(new Recipe("Deluxe Pizza", 100, 200, 4, e, i, "", "recent1.jpg"));
            Categories["Recently Added"].Add(new Recipe("Heart Attack Hamburger", 100, 200, 4, e, i, "", "recent2.jpg"));
            Categories["Recently Added"].Add(new Recipe("Deep Dish Pizza", 100, 200, 4, e, i, "", "recent3.jpg"));
        }
    }
}
