using Diet.Business.Core;
using Diet.Business.Model;
using Diet.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Linq;
using Diet.Business.Core.ModDietMaster;

namespace GNHClientUI.Helper
{
    public class ExportClass
    {
        public ExportClass()
        {

        }
        //public string ClientReport(DietMaster objDietMaster, Dictionary<string, bool> sections, string filenamewithpath)
        //{
        //    System.Text.StringBuilder strBody = new System.Text.StringBuilder("");
        //    strBody.Append("<html " + "xmlns:o=\'urn:schemas-microsoft-com:office:office\' " + "xmlns:w=\'urn:schemas-microsoft-com:office:word\'" + "xmlns=\'http://www.w3.org/TR/REC-html40\'>" + "<head><title>Time</title>");
        //    // The setting specifies document's view after it is downloaded as Print
        //    // instead of the default Web Layout
        //    strBody.Append("<!--[if gte mso 9]>" + "<xml>" + "<w:WordDocument>" + "<w:View>Print</w:View>" + "<w:Zoom>90</w:Zoom>" + "<w:DoNotOptimizeForBrowser/>" + "</w:WordDocument>" + "</xml>" + "<![endif]-->");
        //    strBody.Append("<style>" + "<!-- /* Style Definitions */" + "@page Section1" + "   {size:8.5in 11.0in; " + "   margin:1.0in 1.25in 1.0in 1.25in ; " + "   mso-header-margin:.5in; " + "   mso-footer-margin:.5in; mso-paper-source:0;}" + " div.Section1" + "   {page:Section1;}" + "-->" + "</style></head>");
        //    strBody.Append("<body lang=EN-US style=\'tab-interval:.5in\';font:Verdana, Arial, sans-serif;>" + "<h1 align='center' color='black'>Geeta Nutri Heal</h1><hr size='2' width=80%><div class=Section1 style='border: 1px solid grey;'>" + " <h3 align='center' color='black'>Sample Report</h3>");
        //    //Client Info
        //    strBody.Append(" <table align='center' width='100%'><tr><td align='left'>Geeta Nutri Heal Center</td><td></td><td colspan=2 align='right'>Date - " + DateTime.Now.ToShortDateString() + "</td>");
        //    strBody.Append("<tr><td align='left'>Geeta Nutri Heal Center Address Line</td><td></td><td colspan=2 align='right'>Time - " + DateTime.Now.ToShortTimeString() + "</td></tr>");
        //    strBody.Append("<tr><td colspan='4' align='center'>" + objDietMaster.CustomerName + " " + objDietMaster.LastName + "</td></tr>");
        //    strBody.Append("<tr><td align='left'>Patient ID :" + objDietMaster.CustomerID + "</td><td colspan='2'>DOB:" + Convert.ToDateTime(objDietMaster.DOB).ToShortDateString() + "</td><td align='right'>" + objDietMaster.CustomerAge + "Y/" + (objDietMaster.Gender == 0 ? "M" : "F") + "</td></tr></table>");
        //    strBody.Append("<hr size='1' width='100%'>");
        //    //Anthropometics
        //    if (sections.ContainsKey("ANTHROPOMETRICS"))
        //    {
        //        strBody.Append(" <table  align='center' width='100%'><tr><td colspan='4' align='center'><b>Anthropometics</b></td></tr><tr><td align='left'>Measured Wt. " + objDietMaster.MeasuredWeight + " kg</td><td>BMI " + objDietMaster.CalculatedBMI + "</td><td colspan=2 align='right'>BMI Category " + objDietMaster.BMICategory + "</td>");
        //        strBody.Append("<tr><td align='left'>Measured Ht." + objDietMaster.MeasuredHeight + " m</td><td>MUAC " + objDietMaster.MUAC + "cm</td><td colspan=2 align='right'>Measured Waist " + objDietMaster.MeasuredWaist + "cm</td></tr>");
        //        strBody.Append("<tr><td align='left'>Ideal Body Wt. " + objDietMaster.IdealBodyWeight + " kg</td><td colspan='3' align='right'>Blood Pressure " + objDietMaster.BloodPressure + " mmHg</td></tr>");
        //        strBody.Append("<tr><td align='left' colspan='4'>Neck Circumference " + objDietMaster.NeckCircumference + "</td></tr></table>");
        //    }
        //    //Bio Chemical Labs
        //    if (sections.ContainsKey("BIOCHEMICALLABS"))
        //    {
        //        strBody.Append("<hr size='1' width='100%'>");
        //        strBody.Append("<table align='center' width='100%'><tr><td colspan='4' align='center'><b>Bio Chemical Labs</b></td></tr><tr><td align='left'>Test Name</td><td align='center'>Patient's Results</td><td align='center'>Ref. Range</td><td align='center'>Units</td></tr>");
        //        strBody.Append("<tr><td align='left'>Fasting Glucose</td><td align='center'>" + objDietMaster.FastingGlucose + "</td><td align='center'></td><td align='center'>mg/dL</td></tr>");
        //        strBody.Append("<tr><td align='left'>Creatinine</td><td align='center'>" + objDietMaster.Creatinine + "</td><td align='center'>0.8-1.3</td><td align='center'>g/dL</td></tr>");
        //        strBody.Append("<tr><td align='left'>Albumin</td><td align='center'>" + objDietMaster.Albumin + "</td><td align='center'></td><td align='center'>g/dL</td></tr>");
        //        strBody.Append("<tr><td align='left'>HbA1C</td><td align='center'>" + objDietMaster.HbA1C + "</td><td align='center'></td><td align='center'>%</td></tr>");
        //        strBody.Append("<tr><td align='left'>ALT (SGPT)</td><td align='center'>" + objDietMaster.AltSGPT + "</td><td align='center'></td><td align='center'>IU/L</td></tr>");
        //        strBody.Append("<tr><td align='left'>ALT (SGOT)</td><td align='center'>" + objDietMaster.AltSGOT + "</td><td align='center'></td><td align='center'>IU/L</td></tr>");
        //        strBody.Append("<tr><td align='left'>Hematocrit</td><td align='center'>" + objDietMaster.Hematocrit + "</td><td align='center'></td><td align='center'>(%)</td></tr>");
        //        strBody.Append("<tr><td align='left'>Triglycerides</td><td align='center'>" + objDietMaster.Triglycerides + "</td><td align='center'></td><td align='center'>mg/dL</td></tr>");
        //        strBody.Append("<tr><td align='left'>HDL</td><td align='center'>" + objDietMaster.HDL + "</td><td align='center'></td><td align='center'>mg/dL</td></tr>");
        //        strBody.Append("<tr><td align='left'>Total Cholesterol</td><td align='center'>" + objDietMaster.TotalCholesterol + "</td><td align='center'></td><td align='center'>mg/dL</td></tr>");
        //        strBody.Append("<tr><td align='left'>Alkaline Phosphatase</td><td align='center'>" + objDietMaster.AlkalinePhosphatase + "</td><td align='center'></td><td align='center'>IU/L</td></tr>");
        //        strBody.Append("<tr><td align='left'>Vitamin D3</td><td align='center'>" + objDietMaster.VitaminD3 + "</td><td align='center'></td><td align='center'></td></tr>");
        //        strBody.Append("<tr><td align='left'>Vitamin B12</td><td align='center'>" + objDietMaster.VitaminB12 + "</td><td align='center'></td><td align='center'></td></tr>");
        //        strBody.Append("<tr><td align='left'>Others</td><td align='center'>" + objDietMaster.OthersBioChemicalLabs + "</td><td align='center'></td><td align='center'></td></tr></table>");
        //    }
        //    //Bio Chemical Labs
        //    if (sections.ContainsKey("COMORBIDITY"))
        //    {
        //        strBody.Append("<hr size='1' width='100%'>");
        //        strBody.Append("<table align='center' width='100%'><tr><td colspan='6' align='center'><b>Comorbidity</b></td></tr>");
        //        strBody.Append("<tr><td align='right'>CHF</td><td align='left'>" + objDietMaster.CHF + "</td><td align='right'>Hypertension</td><td align='left'>" + objDietMaster.Hypertension + "</td><td align='right'>Asthma</td><td align='left'>" + objDietMaster.Asthma + "</td></tr>");
        //        strBody.Append("<tr><td align='right'>Sleep Apnea</td><td align='left'>" + objDietMaster.SleepApnea + "</td><td align='right'>Thyroid</td><td align='left'>" + objDietMaster.Thyroid + "</td><td align='right'>Diabetes</td><td align='left'>" + objDietMaster.Diabetes + "</td></tr>");
        //        strBody.Append("<tr><td align='right'>IHD</td><td align='left'>" + objDietMaster.IHD + "</td><td align='right'>Functional Status</td><td align='left'>" + objDietMaster.FunctionalStatus + "</td><td></td><td></td></tr></table>");
        //    }
        //    if (sections.ContainsKey("DIETANDLIFESTYLE"))
        //    {
        //        strBody.Append("<hr size='1' width='100%'>");
        //        strBody.Append("<table  align='center' width='100%'><tr><td colspan='4' align='center'><b>Diet And Lifestyle</b></td></tr>");
        //        strBody.Append("<tr><td align='left'>Regular Execise</td><td align='left'>" + objDietMaster.RegularExcercise + "</td><td align='right'>Alcohol</td><td align='right'>" + objDietMaster.Alcohol + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Smoking</td><td align='left'>" + objDietMaster.Smoking + "</td><td align='right'>Sleep Hours Per Day</td><td align='right'>" + objDietMaster.SleepHoursPerDay + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Exercise Detail</td><td align='left'>" + objDietMaster.ExcersizeDetail + "</td><td></td><td></td></tr>");
        //        strBody.Append("<tr><td colspan='4' align='left'><b>Diet History</b></td></tr>");
        //        strBody.Append("<tr><td align='left'>Diet Type</td><td align='left'>" + objDietMaster.DietType + "</td><td align='right'>Eat When Stress</td><td align='right'>" + objDietMaster.EatWhenStressed + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Frequency Of Outside Eat</td><td align='left'>" + objDietMaster.FreqOutFoodEat + "</td><td align='right'>Eat When Bored</td><td align='right'>" + objDietMaster.EatWhenBored + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Typical Meal in Day</td><td align='left'>" + objDietMaster.NoOfTypicalMealsInDay + "</td><td align='right'>Do You Have Breakfast Everyday</td><td align='right'>" + objDietMaster.BreakfastEveryDay + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Typical Snax in Day</td><td align='left'>" + objDietMaster.NoOfTypicalSnaxsInDay + "</td><td align='right'>Eat when watching TV	</td><td align='right'>" + objDietMaster.EatWhenWatchTV + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Caloric Beverages</td><td align='left'>" + objDietMaster.Caloricbeverages + "</td><td align='right'>Tried Wt. Loss Diet Before</td><td align='right'>" + objDietMaster.TriedWeightLossDiet + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Wt. Loss/Gain in Sixth Month</td><td align='left'>" + objDietMaster.WtLossGainSixMon + "</td><td></td><td></td></tr>");
        //        strBody.Append("<tr><td colspan='4' align='left'><b>Fat and Oil</b></td></tr>");
        //        strBody.Append("<tr><td align='left'>Oil Detail</td><td align='left'>" + objDietMaster.OilUseDetail + "</td><td align='right'>Oil Quantity in Month</td><td align='right'>" + objDietMaster.OilQuantityForMonth + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>No of Family Members</td><td align='left'>" + objDietMaster.NoOfMembersInFamily + "</td><td></td><td></td></tr></table>");
        //    }
        //    if (sections.ContainsKey("CLINICALCOMPLAINTS"))
        //    {
        //        strBody.Append("<hr size='1' width='100%'>");
        //        strBody.Append("<table align='center' width='100%'><tr><td colspan='4' align='center'><b>Clinical Complaints</b></td></tr>");
        //        strBody.Append("<tr><td colspan='4' align='left'><b>Gastrointestinal Problems</b></td></tr>");
        //        strBody.Append("<tr><td align='left'>Heartburn </td><td align='left'>" + objDietMaster.Heartburn + "</td><td align='right'>Vomiting</td><td align='right'>" + objDietMaster.Vomiting + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Bloating</td><td align='left'>" + objDietMaster.Bloating + "</td><td align='right'>Use Any Luxative/Antacid</td><td align='right'>" + objDietMaster.LaxativeAntacide + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Gas</td><td align='left'>" + objDietMaster.Gas + "</td><td align='right'>Constipation</td><td align='right'>" + objDietMaster.Constipation + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Diarrhoea</td><td align='left'>" + objDietMaster.Diarrhoea + "</td><td align='right'>Follow Home Remedy</td><td align='right'>" + objDietMaster.HomeRemedy + "</td></tr>");
        //        strBody.Append("<tr><td colspan='4' align='left'><b>ChronicDiseases</b></td></tr>");
        //        strBody.Append("<tr><td align='left'>Diabetes</td><td align='left'>" + objDietMaster.Diabetes + "</td><td align='right'>Liver Disorders</td><td align='right'>" + objDietMaster.LeverDisorders + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Hypertension</td><td align='left'>" + objDietMaster.Hypertension + "</td><td align='right'></td></tr>");
        //        strBody.Append("<tr><td align='left'>Cardiac Disorders</td><td align='left'>" + objDietMaster.CardiacDisorders + "</td><td align='right'>Others</td><td align='right'>" + objDietMaster.OtherChronicDiseases + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Kidney Disorders</td><td align='left'>" + objDietMaster.KidneyDisorders + "</td><td align='right'>Followed Perticular Diet Details </td><td align='right'>" + objDietMaster.FollowedParticularDietForProb + "</td></tr>");
        //        strBody.Append("<tr><td colspan='4' align='left'><b>Medication</b></td></tr>");
        //        strBody.Append("<tr><td align='left'>Vitamin Suplement </td><td align='left'>" + objDietMaster.TakeVitaminSup + "</td><td align='right'>Vitamin Suplement Details </td><td align='right'>" + objDietMaster.VitaminSupDet + "</td></tr>");
        //        strBody.Append("<tr><td align='left'>Mineral Suplement </td><td align='left'>" + objDietMaster.TakeMineralSup + "</td><td align='right'>Mineral Suplement Details </td><td align='right'>" + objDietMaster.MineralSupDet + "</td></tr></table>");

        //    }
        //    if (sections.ContainsKey("DietRecall"))
        //    {
        //        strBody.Append("<hr size='1' width='100%'>");
        //        strBody.Append("<table align='center' width='100%'><tr><td colspan='4' align='center'><b>DietRecall</b></td></tr>");
        //        strBody.Append("<tr><td align='center'>Meal 1 </td><td align='center'>" + Convert.ToDateTime(objDietMaster.Meal1).ToShortTimeString() + "</td><td align='center'>Meal 2</td><td align='center'>" + Convert.ToDateTime(objDietMaster.Meal2).ToShortTimeString() + "</td></tr>");
        //        strBody.Append("<tr><td align='center'>Meal 3</td><td align='center'>" + Convert.ToDateTime(objDietMaster.Meal3).ToShortTimeString() + "</td><td align='center'>Meal 4</td><td align='center'>" + Convert.ToDateTime(objDietMaster.Meal4).ToShortTimeString() + "</td></tr>");
        //        strBody.Append("<tr><td align='center'>Meal 5</td><td align='center'>" + Convert.ToDateTime(objDietMaster.Meal5).ToShortTimeString() + "</td><td align='center'>Meal 6</td><td align='center'>" + Convert.ToDateTime(objDietMaster.Meal6).ToShortTimeString() + "</td></tr></table>");
        //    }
        //    //Footer
        //    strBody.Append("<hr size='1' width='100%'>");
        //    strBody.Append("<div align='center'>End Of Report</div>");
        //    strBody.Append("<table align='center' width='100%' cellpading='1px'><tr><td align='left'>" + objDietMaster.CustomerName + " " + objDietMaster.LastName + "</td><td align='center'>Patient ID :" + objDietMaster.CustomerID + "</td><td colspan='2' align='right'>" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "</td></tr>");
        //    strBody.Append("<tr><td colspan='4' align='center'>&copy;&nbsp; " + DateTime.Now.Year + " Geeta Neutri Heals</td></tr></table>");
        //    strBody.Append("</div></body></html>");
        //    return strBody.ToString();
        //}

        public string ClientReport(DietMaster objDietMaster, string PatientID)
        {
            double ProteinTotal = 0, CalorieTotal = 0;
            System.Text.StringBuilder strBody = new System.Text.StringBuilder("");
            strBody.Append("<html " + "xmlns:o=\'urn:schemas-microsoft-com:office:office\' " + "xmlns:w=\'urn:schemas-microsoft-com:office:word\'" + "xmlns=\'http://www.w3.org/TR/REC-html40\'>" + "<head><title>Time</title>");
            // The setting specifies document's view after it is downloaded as Print
            // instead of the default Web Layout
            strBody.Append("<!--[if gte mso 9]>" + "<xml>" + "<w:WordDocument>" + "<w:View>Print</w:View>" + "<w:Zoom>90</w:Zoom>" + "<w:DoNotOptimizeForBrowser/>" + "</w:WordDocument>" + "</xml>" + "<![endif]-->");
            strBody.Append("<style>" + "<!-- /* Style Definitions */" + "@page Section1" + "   {size:8.5in 11.0in; " + "   margin:1.0in 1.25in 1.0in 1.25in ; " + "   mso-header-margin:.5in; " + "   mso-footer-margin:.5in; mso-paper-source:0;}" + " div.Section1" + "   {page:Section1;}" + "-->" + "</style></head>");
            strBody.Append("<body lang=EN-US style=\'tab-interval:.5in\';font:Verdana, Arial, sans-serif;>" + "<h1 align='center' color='black'>Geeta Nutri Heal</h1><hr size='2' width=80%><div class=Section1 style='border: 1px solid grey;'>" + " <h3 align='center' color='black'><u>YOUR PERSONALIZED DIET PLAN</u></h3>");

            //Client Info
            strBody.Append("<table width=90%><tr><td colspan=2 align='left'> Name :" + objDietMaster.CustomerName + " " + objDietMaster.MiddleName + " " + objDietMaster.LastName + "</td><td colspan=2 align='right'>Date :" + DateTime.Now.ToString("dd-MMM-yyyy") + "</td></tr>");
            strBody.Append("<tr><td colspan=4 align='left'>Wt. :" + objDietMaster.MeasuredWeight + " kg</td></tr>");
            strBody.Append("<tr><td colspan=4 align='left'>Ideal Body Weight. :" + objDietMaster.IdealBodyWeight + " kg</td></tr></table><br/><br/>");
            strBody.Append("<table width=90%><tr><td>Medical complaints:</td></tr><tr><td><ol><li>BMI :" + objDietMaster.BMICategory + "</li>");
            string weighlossgain = objDietMaster.WeightGainLossMonth > 0 ? "Recent weight loss" : "Recent Weight gain";
            strBody.Append("<li>" + weighlossgain + "</li>");
            if (objDietMaster.Thyroid.ToString().ToUpper() == "YES")
                strBody.Append("<li>" + objDietMaster.ThyroidType.ToString() + "</li>");
            strBody.Append("</ol></td></tr></table>");
            strBody.Append("<table width=90%><tr><td>Diet Type:</td></tr><tr><td>" + objDietMaster.DietType + "</td></tr>");
            strBody.Append("<tr><td>Medical Nutrition Therapy:</td></tr><tr><td><ol><li>Calorie Management:&nbsp;CALORIE_TOTAL</li><li>Protein Management:&nbsp;PROTEIN_TOTAL</li><li>Prevent further weight loss and  control hyperthyroidism through Medical management and MNT</li></td></tr></table>");
            strBody.Append("<table width=90%><tr><td><b>Diet Recall </b></td></tr></table>");

            DataTable dtFoodListWithID = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT  FMnFoodID FoodID,FMsFoodname FoodName,(select FGsGroupName from FoodGroupMaster where FGnGroupId=FMsFoodType) 'FoodType' FROM FoodMaster", con);
                da.Fill(dtFoodListWithID);
            }

            DataTable FoodTypes = new DataTable();
            FoodTypes.Columns.AddRange(new DataColumn[3] { new DataColumn("FoodType", typeof(string)),
                            new DataColumn("FoodName", typeof(string)),
                            new DataColumn("Quantity",typeof(string)) });

            //Get Customer Recall Diet Details
            int custID = Convert.ToInt32(PatientID);

            int i = 0;


            DataTable dtRecallDietDetail = new DataTable();
            dtRecallDietDetail = new RecallDietManager().GetRecallDietDetails(custID);
            List<RecallDietDetails> lstRecallDietDetails = new List<RecallDietDetails>();
            foreach (DataRow drRecallDiet in dtRecallDietDetail.Rows)
            {
                RecallDietDetails objRecallDietDetails = new RecallDietDetails();
                objRecallDietDetails.CustomerID = custID;
                objRecallDietDetails.VisitDate = Convert.ToDateTime(drRecallDiet["VisitDate"]);
                objRecallDietDetails.Notes = Convert.ToString(drRecallDiet["Notes"]);
                List<MealDetails> lstMealDetails = new List<MealDetails>();

                for (int mealID = 1; mealID <= 12; mealID++)
                {
                    string mealName = "Meal" + mealID;
                    string[] mealDetailSeperatingChars = { "@@" };
                    char[] mealFoodItemSeperatingChars = { '~' };
                    char[] mealFoodItemDetailSeperatingChars = { '|' };

                    string[] strMealDetails = Convert.ToString(drRecallDiet[mealName]).Split(mealDetailSeperatingChars, StringSplitOptions.None);

                    MealDetails objMealDetails = new MealDetails();
                    objMealDetails.MealName = mealName;
                    objMealDetails.Time = Convert.ToDateTime(strMealDetails[0]);
                    objMealDetails.Days = Convert.ToString(strMealDetails[1]);

                    List<MealFoodDetails> lstMealFoodDetails = new List<MealFoodDetails>();
                    string[] strMealFoodDetails = Convert.ToString(strMealDetails[2]).Split(mealFoodItemSeperatingChars, StringSplitOptions.RemoveEmptyEntries);

                    if (strMealFoodDetails.Count() > 0)
                        strBody.Append("<table width=90%><tr><td><b>" + "Meal " + mealID + " - " + Convert.ToDateTime(objMealDetails.Time).ToShortTimeString() + "</b></td></tr>");
                    i = 0;
                    foreach (String strFoodItem in strMealFoodDetails)
                    {

                        MealFoodDetails objMealFoodDetails = new MealFoodDetails();
                        string[] strFoodItemDetail = strFoodItem.Split(mealFoodItemDetailSeperatingChars, StringSplitOptions.None);

                        var foodRows = dtFoodListWithID.Select("FoodID = " + Convert.ToInt16(strFoodItemDetail[0]));
                        string strFoodName = Convert.ToString(foodRows[0]["FoodName"]);
                        string foodtype = Convert.ToString(foodRows[0]["FoodType"]);

                        if (i == 0)
                            strBody.Append("<tr><td><ul><li>" + strFoodName + "(" + foodtype + ") " + strFoodItemDetail[1] + " " + strFoodItemDetail[2] + "</li>");
                        else
                            strBody.Append("<li>" + strFoodName + strFoodItemDetail[1] + " " + strFoodItemDetail[2] + "</li>");

                        FoodTypes.Rows.Add(foodtype, strFoodName, strFoodItemDetail[1] + " " + strFoodItemDetail[2]);
                        ++i;
                    }
                    strBody.Append("</td></tr></table>");

                }
            }
            strBody.Append("<table width=90%><tr><td><b>Dietary allowance recommended / day:</b></td></tr></table>");
            //strBody.Append("<table border=1 width=90%><tr><td align=center>Food Group</td><td align=center>Servings</td></tr>");
            //DataView view = new DataView(FoodTypes);
            //DataTable distinctValues = new DataTable();
            //distinctValues = view.ToTable(true, "FoodType");

            //for (int k = 0; k < distinctValues.Rows.Count; k++)
            //{
            //    strBody.Append("<tr><td align=center>" + FoodTypes.Rows[k]["FoodType"].ToString() + "</td><td><ul>");
            //    for (int j = 0; j < FoodTypes.Rows.Count; j++)
            //    {
            //        if (FoodTypes.Rows[j]["FoodType"].ToString().Equals(FoodTypes.Rows[k]["FoodType"].ToString()))
            //        {
            //            strBody.Append("<li>" + FoodTypes.Rows[j]["FoodName"].ToString() + " " + FoodTypes.Rows[j]["Quantity"].ToString() + " </li>");

            //        }
            //    }
            //    strBody.Append("</ul></td></tr>");
            //}
            //strBody.Append("</table>");            
            strBody.Append("<table border=1 width=90%><tr><td align=center><b>Food Group</b></td><td align=center><b>Servings</b></td></tr>");
            strBody.Append("<tr><td>Grains and Cereals</td><td>4 - 5 serving /day Chapathi  1 or phulka 1 and half or any other grain raw handfist  like Pasta or Rice or rawa or poha or Bread 2 slice ( domestic)</td></tr>");
            strBody.Append("<tr><td>Dals, Pulses and Legumes</td><td>2 servings/day Thick or sprouts or Soya etc</td></tr>");
            strBody.Append("<tr><td>Milk and Milk Products</td><td>300ml/day  can be curd - 2 bowls/day</td></tr>");
            strBody.Append("<tr><td>Egg and Non-veg</td><td>3 eggs / week Fish / Chicken twice  week ( 100gm each time)</td></tr>");
            strBody.Append("<tr><td>Vegetables</td><td>4 serving /day Any vegetable except potato  2 handful  is one serving</td></tr>");
            strBody.Append("<tr><td>Fruits</td><td>2 whole : any Fruit should be size of Tennis ball / size or whole</td></tr>");
            strBody.Append("<tr><td>Sugar</td><td>2 tsp /day. If sweet tooth , Then avoid visible sugar in beverages</td></tr>");
            strBody.Append("<tr><td>Fat</td><td>500ml/person/month Presently the type of oil which you are using is perfect.</td></tr>");
            strBody.Append("<tr><td>Water</td><td>3 liters/day</td></tr>");
            strBody.Append("</table><br/>");

            //Showing diet recommended for first visit only
            DataSet dtSearchMaster = new DataSet();
            dtSearchMaster = new DietMasterManager().GetDietMaster_History(Convert.ToInt32(custID));
            if (dtSearchMaster.Tables[0].Rows.Count == 0)
            {
                strBody.Append("<table width=90%><tr><td>You are recommended to follow a __________ Calorie diet plan to reach the desired weight.");
                strBody.Append("Here is sample menu options to help you understand your diet.</td></tr></table></br>");
                strBody.Append("<table border=1 width=90%><tr><td align=center><b>Meals/Snacks</b></td><td align=center><b>Diet Plan A</b></td></tr>");
                DataTable dtRecommendedDietDetail = new DataTable();
                dtRecommendedDietDetail = new RecommendedDietManager().GetRecommendedDietDetails(custID);
                List<RecommendedDietDetails> lstRecommendedDietDetails = new List<RecommendedDietDetails>();
                foreach (DataRow drRecommendedDiet in dtRecommendedDietDetail.Rows)
                {
                    RecommendedDietDetails objRecommendedDietDetails = new RecommendedDietDetails();
                    objRecommendedDietDetails.CustomerID = custID;
                    objRecommendedDietDetails.VisitDate = Convert.ToDateTime(drRecommendedDiet["VisitDate"]);
                    objRecommendedDietDetails.Notes = Convert.ToString(drRecommendedDiet["Notes"]);

                    List<MealDetails> lstMealDetails = new List<MealDetails>();
                    for (int mealID = 1; mealID <= 12; mealID++)
                    {
                        string mealName = "Meal" + mealID;
                        string[] mealDetailSeperatingChars = { "@@" };
                        char[] mealFoodItemSeperatingChars = { '~' };
                        char[] mealFoodItemDetailSeperatingChars = { '|' };

                        string[] strMealDetails = Convert.ToString(drRecommendedDiet[mealName]).Split(mealDetailSeperatingChars, StringSplitOptions.None);

                        MealDetails objMealDetails = new MealDetails();
                        objMealDetails.MealName = mealName;
                        objMealDetails.Time = Convert.ToDateTime(strMealDetails[0]);
                        objMealDetails.Days = Convert.ToString(strMealDetails[1]);

                        List<MealFoodDetails> lstMealFoodDetails = new List<MealFoodDetails>();
                        string[] strMealFoodDetails = Convert.ToString(strMealDetails[2]).Split(mealFoodItemSeperatingChars, StringSplitOptions.RemoveEmptyEntries);

                        if (strMealFoodDetails.Count() > 0)
                            strBody.Append("<tr><td align=center><b><h4>" + "Meal " + mealID + " - " + Convert.ToDateTime(objMealDetails.Time).ToShortTimeString() + "</h4></b></td>");

                        i = 0;
                        foreach (String strFoodItem in strMealFoodDetails)
                        {
                            MealFoodDetails objMealFoodDetails = new MealFoodDetails();
                            string[] strFoodItemDetail = strFoodItem.Split(mealFoodItemDetailSeperatingChars, StringSplitOptions.None);

                            var foodRows = dtFoodListWithID.Select("FoodID = " + Convert.ToInt16(strFoodItemDetail[0]));
                            string strFoodName = Convert.ToString(foodRows[0]["FoodName"]);


                            DataTable dtFoodNutrients = new DataTable();
                            dtFoodNutrients = new FoodMasterManager().GetFoodMajorNutrients(strFoodName, Convert.ToDouble(strFoodItemDetail[1]), Convert.ToString(strFoodItemDetail[2]));
                            CalorieTotal += Convert.ToDouble(dtFoodNutrients.Rows[0]["Energy"]);
                            ProteinTotal += Convert.ToDouble(dtFoodNutrients.Rows[0]["Protein"]);

                            if (i == 0)
                                strBody.Append("<td><ul><li>" + strFoodName + " " + strFoodItemDetail[1] + " " + strFoodItemDetail[2] + "</li>");
                            else
                                strBody.Append("<li>" + strFoodName + " " + strFoodItemDetail[1] + " " + strFoodItemDetail[2] + "</li>");
                            i++;
                        }
                        strBody.Append("</td></tr>");
                    }
                }
                strBody.Append("</table>");
            }
            strBody.Append("<table width=90%><tr><td>Things to Remember :</td></tr>");
            strBody.Append("<tr><td><ol><li>Suspected food allergens are dairy, soy, gluten . ( you need to be cautious with these foods.) eat small meals if it does'nt  bother you can increase the intake</li>");
            strBody.Append("<li>Take adequate rest</li><li>Drink water</li><li>If you feel muscle spasms  include calcium supplments/ and monitor vitamin D and B12</li><li>Reduce your exercise to normal walk/swim 45 minutes /daily</li></td></tr></table>");
            strBody.Append("<table width=90%><tr><td>Follow up date :</td></tr><tr><td>After 15 days with weight and improvement symptoms.</td></tr></table><br/><br/>");
            strBody.Append("<table width=90%><tr><td>PH_USER</td></tr><tr><td>Consultant Nutritionist & Registered Dietician</td></tr><tr><td>Geeta Nutri Heal</td></tr><tr><td>Mob No:</td></tr></table><br/><br/>");
            strBody.Append("</div></body></html>");
            //strBody.Replace("CALORIE_TOTAL", Convert.ToString(CalorieTotal) + " (g)");
            //strBody.Replace("PROTEIN_TOTAL", Convert.ToString(ProteinTotal) + " (kcal)");
            return strBody.ToString();
        }

    }
}