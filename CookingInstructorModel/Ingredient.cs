using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingInstructorModel
{
    public class Ingredient
    {
        public Ingredient(Double quantity, String item, List<Ingredient> subs)
        {
            Quantity = quantity;
            Item = item;
            Substitutions = subs;
        }
        private Double quantity;
        public Double Quantity{
            get {return quantity;}
            set { quantity = value;}
        }
        private String item;
        public String Item
        {
            get { return item; }
            set { item = value; }
        }
        private List<Ingredient> substitutions;
        public List<Ingredient> Substitutions
        {
            get { return substitutions; }
            set { substitutions = value; }
        } 
        public void Adjust(int val)
        {
            Quantity *= val;
            foreach(Ingredient i in Substitutions)
            {
                i.Adjust(val);
            }
        }
        public String Content
        {
            get { return Convert.ToString(Quantity) + " " + Item; }
        }

    }
}
