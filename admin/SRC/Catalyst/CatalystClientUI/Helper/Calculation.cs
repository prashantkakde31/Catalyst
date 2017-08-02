using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GNHClientUI.Helper
{
    public class Calculation
    {
        float Weight;// Weight value in kg or lb (pound)
float @param;// Height Height value in meter, centimeter or inch
String[] WeightUnit=new String[] {"Kg","lb"} ;
String[] HeightUnit=new String[] {"cm","inch","m"};
String[] Equation=new String[] {"General","Harris-Benedict"};
  public Calculation()
	{}
   //     # 'Calculate Basal Metabolic Rate (BMR)
//# 'General Calculation:  BMR = your body weight in lbs x 10 kcal/lb
//# 'The Harris-Benedict Equation: 
//#   Males:  66 + (13.7 x W) + (5 x H) - (6.8 x A)                 
//# Females:  655 + (9.6 x W) + (1.7 x H) - (4.7 x A) 
//# Where W = actual weight in kg, H = height in cm, # A = age in years 

//# @example
//# # Ex.  60 kg man with 132 lbs.
//# Compute_BMR(Weight=60,BMREquation='General')
//# Compute_BMR(Weight=60,Height=1.65,Age=25,Gender='female',WeightUnit='Kg', HeightUnit='m',AgeUnit='year',BMREquation='Harris-Benedict')

public void Compute_BMR(float Weight=68,float Height=1.65,int Age=25,String[] Gender="female",String[] WeightUnit="Kg",String[] HeightUnit="m",String[] AgeUnit="year",String[] BMREquation="HarrisBenedict") {
  
 
  BMR = switch{}
      EXPR=BMREquation,
              General= BMR_General_Eq(Weight,WeightUnit),
              HarrisBenedict = BMR_HarrisBenedict(Weight,Height=1.65,Age=25,Gender="female",WeightUnit="Kg", HeightUnit="m",AgeUnit="year"));
}


//# 'Calculate Basal Metabolic Rate (BMR) based on general equation
//# 'General Calculation:  BMR = your body weight in lbs x 10 kcal/lb
//# @param Weight Weight value
//# @param WeightUnit {'Kg','lb'} 
//# @example
//# Ex.  60 kg man with 132 lbs.
//# BMR = 132 x 10 = 1320
//# BMR <- BMR_General(60,'Kg') 


public Double BMR_General(float Weight,String WeightUnit="Kg"){
  
    //#General Calculation:  BMR = your body weight in lbs x 10 kcal/lb
    Weight = WeightTolb(Weight,WeightUnit); // WeightTolb Function
    
    Double BMR =Weight * 10 ;//# Kcal 
    
    return(BMR);
  }
  

//# 'The Harris-Benedict Equation for Basal Metabolic Rate (BMR): 
//# Women: BMR = 655 + ( 9.6 x weight in kilos ) + ( 1.8 x height in cm ) - ( 4.7 x age in years )
//#   Men: BMR = 66 + ( 13.7 x weight in kilos ) + ( 5 x height in cm ) - ( 6.8 x age in years )
//#
//# @param 
//# @param Weight Weight value in kg or lb
//# @param Height Height value in cm, inch or m
//# @param Age    Age in years
//# @param Gender {'male','female'}
//# @param WeightUnit {'Kg','lb'} 
//# @param HeightUnit {'cm','inch','m'}
//# @param AgeUnit 'year'
//#
//# Source: http://www.bmi-calculator.net/bmr-calculator/harris-benedict-equation/
  public double BMR_HarrisBenedict(float Weight,float Height,int Age,String Gender="female",String WeightUnit="Kg", String HeightUnit="m",String AgeUnit="year")
  {
  double BMR=0.00;
  double Weight1=WeightToKg(Weight,WeightUnit);// WeightToKG function
   
   double Height1=HeightTocm(Height,HeightUnit);//HeightToCM function
      
   
    if(Gender.ToLower()=="male" || Gender.ToLower()=="men"){
   
      BMR = 66 + ( 13.7 * Weight1 /*in kilos */) + ( 5 * Height1/* in cm*/ ) - ( 6.8 * Age/* in years*/ ) ;//in Kcal
      
      //BMR = 66 + ( 13.7 * Weight) + ( 5 * Height) - ( 6.8 * Age );// # Kcal 
      
    }else if(Gender.ToLower()=="female" || Gender.ToLower()=="women"){
   
      //#Women: BMR = 655 + ( 9.6 x weight in kilos ) + ( 1.8 x height in cm ) - ( 4.7 x age in years ) in  Kcal 
      
      BMR = 655 + ( 9.6 * Weight1) + ( 1.8 * Height1) - ( 4.7 *Age);// # Kcal 
      
    }
   
    return(BMR);
}
  

//# Calorie needed per day based on BMR and life style
//# To determine your total daily calorie needs, multiply your BMR by the appropriate activity factor, as follows:
//# If you are sedentary (little or no exercise) : Calorie-Calculation = BMR x 1.2
//# If you are lightly active (light exercise/sports 1-3 days/week) : Calorie-Calculation = BMR x 1.375
//# If you are moderatetely active (moderate exercise/sports 3-5 days/week) : Calorie-Calculation = BMR x 1.55
//# If you are very active (hard exercise/sports 6-7 days a week) : Calorie-Calculation = BMR x 1.725
//# If you are extra active (very hard exercise/sports & physical job or 2x training) : Calorie-Calculation = BMR x 1.9
//#@param BMR Basal Metabolic Rate 
String[] Lifestyle=new String[] {"sendentary","lightactive","moderatelyactive","veryactive","extraactive"};
 public double CalorieNeed_FromBMR(double BMR,String[] LifeStyle){
  
  
    CalorieNeeded = switch(LifeStyle,
                            sedentary=BMR*1.2,
                            lightlyactive=BMR*1.375,
                            moderatelyactive=BMR*1.55,
                            veryactive=BMR*1.725,
                            extraactive=BMR*1.9)
    
    return(CalorieNeeded);
  
    
    }

//#'Compute Body Mass Index (BMI)
//#'BMI= Weight/(Height*Height), Weight is in Kg and Height is in meter
 public double GetBMI(float Weight,float Height,String WeightUnit,String HeightUnit){
  
  Weight = WeightToKg(Weight,WeightUnit);
  
  Height = HeightTom(Height,HeightUnit);
  
  double BMI= Weight/(Height*Height);
  
  return(BMI);
  
}


//#' Get body fat percentage from weight, height and other measurements
//#' Source:http://www.bmi-calculator.net/body-fat-calculator/body-fat-formula.php
public double GetBodyFatPercentage(String Gender,float Weight,float Height,float Wrist,float Waist,float Hip,float ForeArm,String WeightUnit="kg",String LengthUnit="cm")
{ 
    double BodyFatPercentage=0;
  //#Convert weight to pounds
  Weight = WeightTolb(Weight,WeightUnit);
  
  //#Convert length measurements to inches
  Height = HeightToInch(Height,LengthUnit);
  
  Wrist = HeightToInch(Wrist,LengthUnit);
  
  Waist = HeightToInch(Waist,LengthUnit);
  
    Hip = HeightToInch(Hip,LengthUnit);
  
  ForeArm= HeightToInch(ForeArm,LengthUnit);
  
 //#Body Fat Formula For Women
  if (Gender.ToLower()=="female")
  {
    //# Factor 1=	(Total body weight x 0.732) + 8.987
    Factor1 = Weight *0.732 + 8.987;
    
    //# Factor 2=	Wrist measurement (at fullest point) / 3.140
     Factor2 =	Wrist/ 3.140;
    
   // # Factor 3=	Waist measurement (at naval) x 0.157
     
     Factor3 = Waist * 0.157;
   // # Factor 4=	Hip measurement (at fullest point) x 0.249
     Factor4 =	Hip* 0.249;
     
    //# Factor 5=	Forearm measurement (at fullest point) x 0.434
     Factor5= ForeArm * 0.434;
    
    // # Lean Body Mass =	Factor 1 + Factor 2 - Factor 3 - Factor 4 + Factor 5
     
     LeanBodyMass =	(Factor1 + Factor2 - Factor3 - Factor4 + Factor5);
    
    // # Body Fat Weight=	Total bodyweight - Lean Body Mass
      BodyFatWeight	= (Weight-LeanBodyMass);
      
    // # Body Fat Percentage =	(Body Fat Weight x 100) / total bodyweight
      BodyFatPercentage =	(BodyFatWeight * 100) / Weight;
  }

  //#Body Fat Formula For men
  if (Gender.ToLower()=="male")
  {
    
     // #Factor 1	=(Total body weight x 1.082) + 94.42
      Factor1 = Weight *1.082 + 94.42;

     // # Factor2 =	Waist measurement x 4.15
      Factor2 =	Waist* 4.15;
      
      //#Lean Body Mass	= Factor1 - Factor2
      LeanBodyMass	= Factor1 - Factor2;

      //# Body Fat Weight=	Total bodyweight - Lean Body Mass
      BodyFatWeight	= (Weight-LeanBodyMass);
      
      //# Body Fat Percentage =	(Body Fat Weight x 100) / total bodyweight
      BodyFatPercentage <-	(BodyFatWeight * 100) / Weight;
  }
  
  return(BodyFatPercentage);
}

//#'Convert weight to kg
//#Convert weight in pounds to kg if required
//#Note: We make use of NIST package for converstion of units
public float WeightToKg(float Weight,String WeightUnit){
  
  if( WeightUnit.ToLower()=="kg"){
  
    Weight = Weight;// #Keep weight in kg  
  
  }else if(WeightUnit.ToLower()=="lb"){
  
    Weight = NISTpoundAvoirdupoisTOkg(Weight);// #Convert weight in kg to pound
  
  }
}

//#'Convert weight in kg to pound 
//#'Note: We make use of NIST package for converstion of units
public float WeightTolb(float Weight,String WeightUnit){
  
  if(WeightUnit.ToLower()=="kg") {
    Weight = NISTkgTOpoundAvoirdupois(Weight);// #Convert weight in kg to pound
    
  }else if (WeightUnit.ToLower() == "lb") {
    Weight = Weight;// #Keep weight in kg
    
  }

}

//#'Convert height to centimeter

public double HeightTocm(float Height,String HeightUnit)
{
  
  if (HeightUnit.ToLower()=="cm"){
  
  Height =  Height;// # unchanged
  
  }else if(HeightUnit.ToLower()=="inch"){
  
    Height = NISTinchTOcm(Height);// #convert inch to cm
  
  }else if(HeightUnit.ToLower()=="m"){
  
    Height = Height*100 ;//# 1 meter = 100 centimeter
  
 }
}


//#'Convert height to meter

public float HeightTom(float Height,String HeightUnit)
{
  
  if (HeightUnit.ToLower()=="cm"){
    
    Height =  Height/100;// # 1 meter = 100 centimeter
    
  }else if((HeightUnit)=="inch"){
    
    Height = NISTinchTOcm(Height)/100 ;//#convert inch to cm and cm to meter
    
  }else if(HeightUnit.ToLower()=="m"){
    
    Height = Height;// # Unchanged
    
  }
}


//#'Convert height to inch
public float HeightToInch(float Height,String HeightUnit){
  
  if (HeightUnit.ToLower()=="cm"){
    
    Height =  NISTcmTOinch(Height);//#convert cm to inch to cm 
    
  }else if(HeightUnit.ToLower()=="inch"){

      Height = Height;//# Unchanged
    
  }else if(HeightUnit.ToLower()=="m"){
    
    Height <- NISTcmTOinch(Height*100) ;//# 1m = 100cm
    
  }
}

	}}
