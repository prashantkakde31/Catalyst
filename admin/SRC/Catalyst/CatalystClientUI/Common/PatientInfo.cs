namespace Diet.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class PatientInfo
    {
        public static int PatientID;
    }
    public class FoodData
    {
        public string[] foodNames;
        public string[] foodUnits;
    }

    public class FoodMajorNutrients
    {
        public string foodID;
        public string foodName;
        public string energy;
        public string protein;
        public string fat;
        public string fibre;
        public string carbs;
    }

    public class MealFoodDetails
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Qty { get; set; }
        public string Unit { get; set; }
        public string Remark { get; set; }
        public double Energy { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Fibre { get; set; }
        public double Carbs { get; set; }
    }

    public class MealDetails
    {
        public string MealName { get; set; }
        public DateTime Time { get; set; }
        public string Days { get; set; }
        public List<MealFoodDetails> MealFoodDetails { get; set; }
    }

    public class RecallDietDetails
    {
        public int CustomerID { get; set; }
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; }
        public List<MealDetails> MealDetails { get; set; }
    }

    public class RecommendedDietDetails
    {
        public int CustomerID { get; set; }
        public DateTime VisitDate { get; set; }
        public string Notes { get; set; }
        public List<MealDetails> MealDetails { get; set; }
    }

}
