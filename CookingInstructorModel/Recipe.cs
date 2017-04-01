using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingInstructorModel
{
    public class Recipe
    {
        public Recipe(String t, Double cookT, Double prepT, int serves, List<String> instruct,List<Ingredient> ingredients, String video, String imagePath)
        {
            Title = t;
            PrepTime = prepT;
            CookTime = cookT;
            Ingredients = ingredients;
            Instructions = instruct;
            VideoPath = video;
            ImagePath = imagePath;
        }

        private int servingSize;
        public int ServingSize
        {
            get { return servingSize; }
            set { servingSize = value; }
        }

        public void AdjustServingSize(int serves)
        {
            ServingSize = serves;
            for(int i = 0; i < ingredients.Count; i++)
            {
                ingredients.ElementAt(i).Adjust(serves);
            }

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

        private double cookTime;
        public Double CookTime
        {
            get { return cookTime; }
            set { cookTime = value; }
        }

        private double prepTime;
        public Double PrepTime
        {
            get { return prepTime; }
            set { prepTime = value; }
        }

        public Double TotalTime
        {
            get { return cookTime + prepTime; }
        }

        private List<String> instructions;
        public List<String> Instructions
        {
            get { return instructions; }
            set { instructions = value; }
        }
        private List<Ingredient> ingredients;
        public List<Ingredient> Ingredients
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

    }
}
