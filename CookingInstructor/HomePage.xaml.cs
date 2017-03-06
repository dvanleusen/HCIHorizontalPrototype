using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CookingInstructor
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        private Boolean search;
        private Boolean tutorialOn;
        private CategoryPanel catPane;
        private SearchPanel searchPane;
        private TutorialPanel tutPane;

        public HomePage()
        {
            InitializeComponent();
            search = false;
            catPane = new CategoryPanel();
            searchPane = new SearchPanel();
            tutPane = new TutorialPanel();
        
            /*Hard Coded data to be removed later and replaced with generated data*/
            Category vegan = new Category("Vegan");
            vegan.addRecipe(new RecipeIcon("vegan1.jpg", "Corn Salad"));
            vegan.addRecipe(new RecipeIcon("vegan2.jpg", "Vegan Chili"));
            vegan.addRecipe(new RecipeIcon("vegan3.jpg", "Vegan Pasta"));
            vegan.addRecipe(new RecipeIcon("vegan4.jpg", "Filled Peppers"));
            vegan.addRecipe(new RecipeIcon("vegan5.jpg", "Vegan Noodle Dish"));
            vegan.addRecipe(new RecipeIcon("vegan6.jpg", "Mushroom Stir Fry"));
            vegan.addRecipe(new RecipeIcon("vegan7.jpg", "Vegan Lasagna"));
            vegan.addRecipe(new RecipeIcon("vegan8.jpg", "Tofu Curry"));
            vegan.addRecipe(new RecipeIcon("vegan9.jpg", "Califlower Yellow Curry"));
            vegan.addRecipe(new RecipeIcon("vegan10.jpg", "Bean Stew"));

            Category recentlyAdded = new Category("Recently Added");
            recentlyAdded.addRecipe(new RecipeIcon("recent1.jpg", "Deluxe Pizza"));
            recentlyAdded.addRecipe(new RecipeIcon("recent2.jpg", "Heart Attack Hamburger"));
            recentlyAdded.addRecipe(new RecipeIcon("recent3.jpg", "Deep Dish Pizza"));
            recentlyAdded.addRecipe(new RecipeIcon("recent4.jpg", "Spaghetti"));
            recentlyAdded.addRecipe(new RecipeIcon("recent5.jpg", "Chicken Salad"));
            recentlyAdded.addRecipe(new RecipeIcon("recent6.jpg", "BBQ Ribs"));
            recentlyAdded.addRecipe(new RecipeIcon("recent7.jpg", "Thai Glass Noodle Soup"));
            recentlyAdded.addRecipe(new RecipeIcon("recent8.jpg", "Meatball Appetizer")); 
            recentlyAdded.addRecipe(new RecipeIcon("recent9.jpg", "Spring Rolls"));
            recentlyAdded.addRecipe(new RecipeIcon("recent10.jpg", "Nanaimo Bar"));
            recentlyAdded.addRecipe(new RecipeIcon("recent11.jpg", "Breakfast Burrito"));

            Category myRecipes = new Category("My Recipes");
            myRecipes.addRecipe(new RecipeIcon("myrec1.jpg", "Cashew Stir Fry"));
            myRecipes.addRecipe(new RecipeIcon("myrec2.jpg", "Spaghetti and Meatballs"));
            myRecipes.addRecipe(new RecipeIcon("myrec3.jpg", "Baked Mac and Cheese"));
            myRecipes.addRecipe(new RecipeIcon("myrec4.jpg", "Thin Crust Margherita Pizza"));
            myRecipes.addRecipe(new RecipeIcon("myrec5.jpg", "Cherry Pie"));
            myRecipes.addRecipe(new RecipeIcon("myrec6.jpg", "Pina Colada"));
            myRecipes.addRecipe(new RecipeIcon("myrec7.jpg", "Long Island Iced Tea"));
            myRecipes.addRecipe(new RecipeIcon("myrec8.jpg", "Peanut Butter Cookies"));
            myRecipes.addRecipe(new RecipeIcon("myrec9.jpg", "Lasagna"));
            myRecipes.addRecipe(new RecipeIcon("myrec10.jpg", "Banana Smore"));

            Category chickenDishes = new Category("Chicken Dishes");
            chickenDishes.addRecipe(new RecipeIcon("chicken1.jpg", "Thai Chicken Bites"));
            searchPane.addRecipe(new RecipeIcon("chicken1.jpg", "Thai Chicken Bites"));

            //RecipeIcon chicken2 = ;
            chickenDishes.addRecipe(new RecipeIcon("chicken2.jpg", "Chicken Stir Fry"));
            searchPane.addRecipe(new RecipeIcon("chicken2.jpg", "Chicken Stir Fry"));

           // RecipeIcon chicken3 = ;
            chickenDishes.addRecipe(new RecipeIcon("chicken3.jpg", "Cashew Chicken"));
            searchPane.addRecipe(new RecipeIcon("chicken3.jpg", "Cashew Chicken"));

            //RecipeIcon chicken4 = ;
            chickenDishes.addRecipe(new RecipeIcon("chicken4.jpg", "Tandoori Chicken"));
            searchPane.addRecipe(new RecipeIcon("chicken4.jpg", "Tandoori Chicken"));

           // RecipeIcon chicken5 = new RecipeIcon("chicken5.jpg", "Chicken Nachos");
            chickenDishes.addRecipe(new RecipeIcon("chicken5.jpg", "Chicken Nachos"));
            searchPane.addRecipe(new RecipeIcon("chicken5.jpg", "Chicken Nachos"));

            //RecipeIcon chicken6 = new RecipeIcon("chicken6.jpg", "Thai Chicken Souvlaki");
            chickenDishes.addRecipe(new RecipeIcon("chicken6.jpg", "Thai Chicken Souvlaki"));
            searchPane.addRecipe(new RecipeIcon("chicken6.jpg", "Thai Chicken Souvlaki"));

            //RecipeIcon chicken7 = new RecipeIcon("chicken7.jpg", "Chicken Stew");
            chickenDishes.addRecipe(new RecipeIcon("chicken7.jpg", "Chicken Stew"));
            searchPane.addRecipe(new RecipeIcon("chicken7.jpg", "Chicken Stew"));

           // RecipeIcon chicken8 = new RecipeIcon("chicken8.jpg", "Roasted Chicken");
            chickenDishes.addRecipe(new RecipeIcon("chicken8.jpg", "Roasted Chicken"));
            searchPane.addRecipe(new RecipeIcon("chicken8.jpg", "Roasted Chicken"));

            //RecipeIcon chicken9 = new RecipeIcon("chicken9.jpg", "Chicken Curry");
            chickenDishes.addRecipe(new RecipeIcon("chicken9.jpg", "Chicken Curry"));
            searchPane.addRecipe(new RecipeIcon("chicken9.jpg", "Chicken Curry"));

            //RecipeIcon chicken10 = new RecipeIcon("chicken10.jpg", "Deep Fried Chicken");
            chickenDishes.addRecipe(new RecipeIcon("chicken10.jpg", "Deep Fried Chicken"));
            searchPane.addRecipe(new RecipeIcon("chicken10.jpg", "Deep Fried Chicken"));

            Category dessert = new Category("Dessert");
            dessert.addRecipe(new RecipeIcon("dessert1.jpg", "Chocolate Mint Bars"));
            dessert.addRecipe(new RecipeIcon("dessert2.jpg", "Chocolate Cup Cakes"));
            dessert.addRecipe(new RecipeIcon("dessert3.jpg", "Blueberry Vanilla Pudding"));
            dessert.addRecipe(new RecipeIcon("dessert4.jpg", "Tiramisu"));
            dessert.addRecipe(new RecipeIcon("dessert5.jpg", "Layered Chocolate Cake"));
            dessert.addRecipe(new RecipeIcon("dessert6.jpg", "Red Velvet Cookies"));
            dessert.addRecipe(new RecipeIcon("dessert7.jpg", "Dessert Raspberry Pizza Pie"));
            dessert.addRecipe(new RecipeIcon("dessert8.jpg", "Lemon Pudding"));
            dessert.addRecipe(new RecipeIcon("dessert9.jpg", "Lemon Meringue Tarts"));
            dessert.addRecipe(new RecipeIcon("dessert10.jpg", "Chocolate Fudge"));

            catPane.addCategory(recentlyAdded);
            catPane.addCategory(myRecipes);
            catPane.addCategory(chickenDishes);
            catPane.addCategory(vegan);
            catPane.addCategory(dessert);

            panelGrid.Children.Add(catPane);
    }
    private void button_mouse_enter(object sender, MouseEventArgs e)
    {
        Button btn = sender as Button;
        StackPanel pane = btn.Content as StackPanel;
        Image img = pane.Children[0] as Image;
        string curSrc = img.Source.ToString();
        var src = new Uri(curSrc.Substring(0, curSrc.Length - 4) + "_mouse_enter.png");
        img.Source = new BitmapImage(src);
    }

    private void button_mouse_leave(object sender, MouseEventArgs e)
    {
        Button btn = sender as Button;
        StackPanel pane = btn.Content as StackPanel;
        Image img = pane.Children[0] as Image;
        string curSrc = img.Source.ToString();
        var src = new Uri(curSrc.Substring(0, curSrc.Length - 16) + ".png");
        img.Source = new BitmapImage(src);

    }
    /*A function to toggle between the search and categories view for finding a recipe*/
    private void searchPressed(object sender, RoutedEventArgs e)
    {
            Button btn = sender as Button;
            StackPanel pane = btn.Content as StackPanel;
            Image img = pane.Children[0] as Image;
            TextBlock text = pane.Children[1] as TextBlock;
            if (search)
            {
                panelGrid.Children.Clear();
                panelGrid.Children.Add(catPane);
                img.Source = new BitmapImage(new Uri("pack://application:,,,/search_mouse_enter.png"));
                text.Text = "Search";
            }
            else
            {
                panelGrid.Children.Clear();
                panelGrid.Children.Add(searchPane);
                img.Source = new BitmapImage(new Uri("pack://application:,,,/categories_mouse_enter.png"));
                text.Text = "Groups"; 
            }
            search = !search;
           
    }
    /*A function to toggle the visibility of the tutorial when the button is pressed*/
    private void tutorialPressed(object sender, RoutedEventArgs e)
    {
        if (tutorialOn)
        {
            panelGrid.Children.Remove(tutPane);
        }
        else
        {
            panelGrid.Children.Add(tutPane);
        }
        tutorialOn = !tutorialOn;

    }
   }
}
