using System;
using System.Collections.Generic;
using System.Linq;
using CookingInstructorModel;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace CookingInstructorViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        public enum State {Search, Groups, Recipe};
        private readonly DelegateCommand<string> buttonPressCommand;

        private Data recipeData;
        private Boolean tutorialOpen;
        private State pageState;
        private ObservableCollection<Recipe> recipes;
        private ObservableCollection<KeyValuePair<String, ObservableCollection<Recipe>>> categories;
        private Recipe selectedRecipe;
        private String sortRecipesBy;
        private String searchText;
        private Boolean error;
        private readonly ObservableCollection<String> sortByOptions;
        private Boolean selectedInFavourites;

        public MainWindowViewModel()
        {
            recipeData = Data.Instance;
            Error = false;
            TutorialOpen = false;
            PageState = State.Groups;
            SelectedRecipe = null;
            sortByOptions = new ObservableCollection<string> { "Cook Time", "Prep Time", "A-Z", "Z-A", "Relevance" };
            SortRecipesBy = "Relevance";
            SearchText = "";
            Recipes = new ObservableCollection<Recipe>();
            Categories = recipeData.GetCategories();
            buttonPressCommand = new DelegateCommand<string>(buttonPress);
        }

        public DelegateCommand<string> ButtonPressed
        {
            get { return buttonPressCommand; }
        }

        public Boolean TutorialOpen
        {
            get { return tutorialOpen; }
            set { tutorialOpen = value;
                OnPropertyChanged("TutorialOpen");
            }
        }
        public State PageState
        {
            get { return pageState; }
            set { pageState = value;
                OnPropertyChanged("PageState");
            }
        }
        public ObservableCollection<KeyValuePair<String, ObservableCollection<Recipe>>> Categories
        {
            get{ return categories;}
            set { categories = value;
                OnPropertyChanged("Categories");
            }
        }

        public ObservableCollection<Recipe> Recipes
        {
            get { return recipes; }
            set { recipes = value;
                OnPropertyChanged("Recipes");
            }
        }

        public Boolean RecipesEmpty
        {
            get { return Recipes.Count == 0; }
        }

        public Recipe SelectedRecipe
        {
            set {
                if (value != null)
                {
                    selectedRecipe = value;
                    OnPropertyChanged("SelectedRecipe");
                    PageState = State.Recipe;
                    SelectedInFavourites = recipeData.Contains("My Recipes", SelectedRecipe);
                    SelectedRecipeTitle = selectedRecipe.Title;
                    SelectedRecipeCookTime = selectedRecipe.CookTime;
                    SelectedRecipePrepTime = selectedRecipe.PrepTime;
                    SelectedRecipeTotalTime = selectedRecipe.TotalTime;
                    SelectedRecipeVideoPath = selectedRecipe.VideoPath;
                    SelectedRecipeIngredients = selectedRecipe.IngredientsSafe;
                    SelectedRecipeInstructions = selectedRecipe.Instructions;
                    SelectedRecipeServingSize = selectedRecipe.ServingSize.ToString();
                    Error = false;
                }
            }
            get {return selectedRecipe; }
        }

        private String serves;
        public String SelectedRecipeServingSize
        {
            get { return serves; }
            set
          { serves = value;
                OnPropertyChanged("SelectedRecipeServingSize");
            }
        }
        private String title;
        public String SelectedRecipeTitle
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("SelectedRecipeTitle");
            }
        }
        private String cookT;
        public String SelectedRecipeCookTime
        {
            get { return cookT; }
            set
            {
                cookT = value;
                OnPropertyChanged("SelectedRecipeCookTime");
            }
        }
        private String prepTime;
        public String SelectedRecipePrepTime
        {
            get { return prepTime; }
            set { prepTime = value;
                OnPropertyChanged("SelectedRecipePrepTime");
            }
        }

        private String totTime;
        public String SelectedRecipeTotalTime
        {
            get { return totTime; }
            set { totTime = value;
                OnPropertyChanged("SelectedRecipeTotalTime");
            }
        }
        private String vidPath;
        public String SelectedRecipeVideoPath
        {
            get { return vidPath; }
            set { vidPath = value;
                OnPropertyChanged("SelectedRecipeVideoPath");
            }
        }
        private ObservableCollection<String> instruct;
        public ObservableCollection<String> SelectedRecipeInstructions
        {
            get { return instruct; }
            set { instruct = value;
                OnPropertyChanged("SelectedRecipeInstructions");
            }
        }
        private ObservableCollection<Ingredient> ingredient;
        public ObservableCollection<Ingredient> SelectedRecipeIngredients
        {
            get { return ingredient; }
            set
            {
                ingredient = value;
                OnPropertyChanged("SelectedRecipeIngredients");
            }
        }
        public Boolean SelectedInFavourites
        {
            get { return selectedInFavourites; }
            set { selectedInFavourites = value;
                OnPropertyChanged("SelectedInFavourites");
            }
        }
        public String SortRecipesBy
        {
            get { return sortRecipesBy; }
            set { sortRecipesBy = value;
                OnPropertyChanged("SortRecipesBy");
            }
        }

        public ObservableCollection<String> SortByOptions
        {
            get { return sortByOptions; }
        }
 
        public String SearchText
        {
            get { return searchText; }
            set { searchText = value;
                OnPropertyChanged("SearchText");
            }
        }
        public Boolean Error
        {
            set { error = value;
                OnPropertyChanged("Error");
            }
            get { return error; }
        }


        private void buttonPress(string btn)
        {
            if (btn.Equals("Search"))
            {
                OnPropertyChanged("RecipesEmpty");
                PageState = State.Search;
            }
            else if (btn.Equals("Groups"))
            {
                Categories = recipeData.GetCategories();
                PageState = State.Groups;
            }
            else if (btn.Equals("Tutorial"))
            {
                TutorialOpen = !TutorialOpen;
            }
            else if (btn.Equals("Fave"))
            {

                if(recipeData.Contains("My Recipes", SelectedRecipe))
                {
                    recipeData.Remove("My Recipes", SelectedRecipe);
                    SelectedInFavourites = false;
                }
                else
                {
                    recipeData.Add("My Recipes", SelectedRecipe);
                    SelectedInFavourites = true;
                }
                Categories = recipeData.GetCategories();
            }
            else if (btn.Equals("SearchEntry"))
            {
                Recipes = recipeData.Search(SearchText);
                OnPropertyChanged("RecipesEmpty");
            }
            else if (btn.Equals("Serves"))
            {
                if (validInput(SelectedRecipeServingSize))
                {
                    AdjustServingSize(Convert.ToInt32(SelectedRecipeServingSize));
                    Error = false;
                }
                else
                {
                    Error = true;
                }
            }
        }

        private void AdjustServingSize(int newVal)
        {
            ObservableCollection<Ingredient> temp = selectedRecipe.IngredientsSafe;
            if (selectedRecipe.ServingSize != 0)
            {
                foreach (Ingredient i in temp)
                {
                    i.Adjust((Double)newVal / (Double)selectedRecipe.ServingSize);
                }
            }
            SelectedRecipeIngredients = temp;
        }

        private Boolean validInput(String input)
        {
            if (input[0] == '0') return false;
            foreach(Char c in input)
            {
                if (c < '/' || c > ':') return false;
            }

            return true;
        }

    }
}
