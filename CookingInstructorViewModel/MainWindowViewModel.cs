using System;
using System.Collections.Generic;
using System.Linq;
using CookingInstructorModel;
using System.Collections.ObjectModel;


namespace CookingInstructorViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        public enum State {Search, Groups, Recipe};
        private readonly DelegateCommand<string> buttonPressCommand;

        private Boolean tutorialOpen;
        private State pageState;
        private ObservableCollection<Recipe> recipes;
        private ObservableCollection<KeyValuePair<String, ObservableCollection<Recipe>>> categories;
        private Recipe selectedRecipe;
        private String sortRecipesBy;
        private String searchText;
        private readonly ObservableCollection<String> sortByOptions;

        public MainWindowViewModel()
        {
            TutorialOpen = false;
            PageState = State.Groups;
            SelectedRecipe = null;
            sortByOptions = new ObservableCollection<string> { "Cook Time", "Prep Time", "A-Z", "Z-A", "Relevance" };
            SortRecipesBy = "Relevance";
            SearchText = "Enter Search Terms";
            Recipes = new ObservableCollection<Recipe>();
            Categories = Data.Instance.Categories;
            
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

        public Recipe SelectedRecipe
        {
            set {

                if (value != null)
                {
                    selectedRecipe = value;
                    OnPropertyChanged("SelectedRecipe");
                    PageState = State.Recipe;
                }
            }
            get {return selectedRecipe; }
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


        private void buttonPress(string btn)
        {
            if (btn.Equals("Search"))
            {
                PageState = State.Search;
            }
            else if (btn.Equals("Groups"))
            {
                PageState = State.Groups;
            }
            else if (btn.Equals("Tutorial"))
            {
                TutorialOpen = !TutorialOpen;
            }
            else if (btn.Equals("Fave"))
            {

            }
            else if (btn.Equals("SearchEntry"))
            {
                Recipes = Data.Instance.Search(SearchText);
            }
        }
    }
}
