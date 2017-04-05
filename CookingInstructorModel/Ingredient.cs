using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingInstructorModel
{
    public class Ingredient
    {
        public Ingredient(Double quantity, String item, ObservableCollection<Ingredient> subs)
        {
            Quantity = quantity;
            Item = item;
            Substitutions = subs;
        }
        public Ingredient(Ingredient i):this(i.Quantity, i.Item, i.SubstitutionsSafe)
        {

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
        private ObservableCollection<Ingredient> substitutions;
        public ObservableCollection<Ingredient> Substitutions
        {
            get { return substitutions; }
            set { substitutions = value; }
        }
        public ObservableCollection<Ingredient> SubstitutionsSafe
        {
            get
            {
                if(Substitutions != null)
                {
                    ObservableCollection<Ingredient> temp = new ObservableCollection<Ingredient>();
                    foreach (Ingredient i in Substitutions)
                    {
                        temp.Add(new Ingredient(i));

                    }
                    return temp;
                }

                return null;   
            }
        }

        public Boolean HasSubstitutions
        {
            get { return Substitutions.Count > 0; }
        }
        public void Adjust(Double val)
        {
            Quantity *= val;
            if(Substitutions != null)
            {
                foreach (Ingredient i in Substitutions)
                {
                    i.Adjust(val);
                }
            } 
        }
        public String Content
        {
            get { return Convert.ToString(Quantity) + " " + Item; }
        }

    }
}
