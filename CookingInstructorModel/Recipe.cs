using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingInstructorModel
{
    public class Recipe
    {
        public Recipe(String t, String cookT, String prepT, String totTime, int serves, ObservableCollection<String> instruct,ObservableCollection<Ingredient> ingredients, String video, String imagePath)
        {
            Title = t;
            PrepTime = prepT;
            CookTime = cookT;
            TotalTime = totTime;
            ServingSize = serves;
            Ingredients = ingredients;
            Instructions = instruct;
            VideoPath = video;
            ImagePath = imagePath;
        }
        public Recipe(Recipe r):this(r.Title,r.CookTime,r.PrepTime, r.TotalTime, r.ServingSize, r.Instructions, r.IngredientsSafe, r.VideoPath, r.ImagePath)
        {

        }

        private int servingSize;
        public int ServingSize
        {
            get { return servingSize; }
            set { servingSize = value;}
        }

        public void AdjustServingSize(int serves)
        {
            for(int i = 0; i < ingredients.Count; i++)
            {
                ingredients.ElementAt(i).Adjust(serves/ServingSize);
            }
            ServingSize = serves;
        }
        private String title;
        public String Title
        {
            get { return title; }
            set { title = value; }
        }

        private String imagePath;
        public String ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; }
        }

        private String cookTime;
        public String CookTime
        {
            get { return cookTime; }
            set { cookTime = value; }
        }

        private String prepTime;
        public String PrepTime
        {
            get { return prepTime; }
            set { prepTime = value; }
        }
        private String totalTime;
        public String TotalTime
        {
            get { return totalTime; }
            set { totalTime = value; }
        }

        private ObservableCollection<String> instructions;
        public ObservableCollection<String> Instructions
        {
            get { return instructions; }
            set { instructions = value; }
        }
        private ObservableCollection<Ingredient> ingredients;
        public ObservableCollection<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
        private String videoPath;
        public String VideoPath
        {
           get { return videoPath; }
            set { videoPath = value; }
        }
        public ObservableCollection<Ingredient> IngredientsSafe
        {
            get
            {
                ObservableCollection<Ingredient> temp = new ObservableCollection<Ingredient>();
                foreach(Ingredient i in Ingredients)
                {
                    temp.Add(new Ingredient(i));
                }

                return temp;
            }
        }
    }
}
