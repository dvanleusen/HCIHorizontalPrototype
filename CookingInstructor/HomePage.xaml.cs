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
        public HomePage()
        {
            InitializeComponent();
        
            Category vegan = new Category("Vegan");
            vegan.addRecipe(new RecipeIcon("vegan1.jpg", ""));
            vegan.addRecipe(new RecipeIcon("vegan2.jpg", ""));
            vegan.addRecipe(new RecipeIcon("vegan3.jpg", ""));
            vegan.addRecipe(new RecipeIcon("vegan4.jpg", ""));
            vegan.addRecipe(new RecipeIcon("vegan5.jpg", ""));
            vegan.addRecipe(new RecipeIcon("vegan6.jpg", ""));
            vegan.addRecipe(new RecipeIcon("vegan7.jpg", ""));
            vegan.addRecipe(new RecipeIcon("vegan8.jpg", ""));
            vegan.addRecipe(new RecipeIcon("vegan9.jpg", ""));
            vegan.addRecipe(new RecipeIcon("vegan10.jpg", ""));

            Category recentlyAdded = new Category("Recently Added");
            recentlyAdded.addRecipe(new RecipeIcon("recent1.jpg", ""));
            recentlyAdded.addRecipe(new RecipeIcon("recent2.jpg", ""));
            recentlyAdded.addRecipe(new RecipeIcon("recent3.jpg", ""));
            recentlyAdded.addRecipe(new RecipeIcon("recent4.jpg", ""));
            recentlyAdded.addRecipe(new RecipeIcon("recent5.jpg", ""));
            recentlyAdded.addRecipe(new RecipeIcon("recent6.jpg", ""));
            recentlyAdded.addRecipe(new RecipeIcon("recent7.jpg", ""));
            recentlyAdded.addRecipe(new RecipeIcon("recent8.jpg", ""));
            recentlyAdded.addRecipe(new RecipeIcon("recent9.jpg", ""));
            recentlyAdded.addRecipe(new RecipeIcon("recent10.jpg", ""));
            recentlyAdded.addRecipe(new RecipeIcon("recent11.jpg", ""));

            Category myRecipes = new Category("My Recipes");
            myRecipes.addRecipe(new RecipeIcon("myrec1.jpg", ""));
            myRecipes.addRecipe(new RecipeIcon("myrec2.jpg", ""));
            myRecipes.addRecipe(new RecipeIcon("myrec3.jpg", ""));
            myRecipes.addRecipe(new RecipeIcon("myrec4.jpg", ""));
            myRecipes.addRecipe(new RecipeIcon("myrec5.jpg", ""));
            myRecipes.addRecipe(new RecipeIcon("myrec6.jpg", ""));
            myRecipes.addRecipe(new RecipeIcon("myrec7.jpg", ""));
            myRecipes.addRecipe(new RecipeIcon("myrec8.jpg", ""));
            myRecipes.addRecipe(new RecipeIcon("myrec9.jpg", ""));
            myRecipes.addRecipe(new RecipeIcon("myrec10.jpg", ""));

            Category chickenDishes = new Category("Chicken Dishes");
            chickenDishes.addRecipe(new RecipeIcon("chicken1.jpg", ""));
            chickenDishes.addRecipe(new RecipeIcon("chicken2.jpg", ""));
            chickenDishes.addRecipe(new RecipeIcon("chicken3.jpg", ""));
            chickenDishes.addRecipe(new RecipeIcon("chicken4.jpg", ""));
            chickenDishes.addRecipe(new RecipeIcon("chicken5.jpg", ""));
            chickenDishes.addRecipe(new RecipeIcon("chicken6.jpg", ""));
            chickenDishes.addRecipe(new RecipeIcon("chicken7.jpg", ""));
            chickenDishes.addRecipe(new RecipeIcon("chicken8.jpg", ""));
            chickenDishes.addRecipe(new RecipeIcon("chicken9.jpg", ""));
            chickenDishes.addRecipe(new RecipeIcon("chicken10.jpg", ""));

            Category dessert = new Category("Dessert");
            dessert.addRecipe(new RecipeIcon("dessert1.jpg", "Chocolate Mint Bars"));
            dessert.addRecipe(new RecipeIcon("dessert2.jpg", ""));
            dessert.addRecipe(new RecipeIcon("dessert3.jpg", ""));
            dessert.addRecipe(new RecipeIcon("dessert4.jpg", ""));
            dessert.addRecipe(new RecipeIcon("dessert5.jpg", ""));
            dessert.addRecipe(new RecipeIcon("dessert6.jpg", ""));
            dessert.addRecipe(new RecipeIcon("dessert7.jpg", ""));
            dessert.addRecipe(new RecipeIcon("dessert8.jpg", ""));
            dessert.addRecipe(new RecipeIcon("dessert9.jpg", ""));
            dessert.addRecipe(new RecipeIcon("dessert10.jpg", ""));

            addCategory(recentlyAdded);
            addCategory(myRecipes);
            addCategory(chickenDishes);
            addCategory(vegan);
            addCategory(dessert);
    }
    public void addCategory(Category cat)
    {
        ListBoxItem i = new ListBoxItem();
        i.Content = cat;
        listBox.Items.Add(i);
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
}
}
