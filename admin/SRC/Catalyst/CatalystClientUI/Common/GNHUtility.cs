using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalystClientUI.Common
{
    public class GNHUtility
    {
        /// <summary>
        /// Used to Get Body frame based on gender, height and wristsize
        /// Ref - https://www.nlm.nih.gov/medlineplus/ency/imagepages/17182.htm
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="heightInCms"></param>
        /// <param name="wristSizeInCms"></param>
        /// <returns></returns>
        public string GetBodyFrame(string gender, double heightInCms, double wristSizeInCms)
        {
            string bodyFrame = "unavailable";

            if (gender.Equals("female"))
            {
                // Height under 5'2"
                if (heightInCms < 155.00 && heightInCms > 0.00)
                {
                    // Small = wrist size less than 5.5"
                    if (wristSizeInCms < 13.75 && wristSizeInCms > 0.00)
                    {
                        bodyFrame = "small";
                    }
                    // Medium = wrist size 5.5" to 5.75"
                    else if (wristSizeInCms >= 13.75 && wristSizeInCms <= 14.375)
                    {
                        bodyFrame = "medium";
                    }
                    // Large = wrist size over 5.75"
                    else if (wristSizeInCms > 14.375)
                    {
                        bodyFrame = "large";
                    }
                }
                // Height 5'2" to 5' 5"
                else if (heightInCms >= 155.00 && heightInCms <= 165.00)
                {
                    // Small = wrist size less than 6"
                    if (wristSizeInCms < 15.00 && wristSizeInCms > 0.00)
                    {
                        bodyFrame = "small";
                    }
                    // Medium = wrist size 6" to 6.25"
                    else if (wristSizeInCms >= 15.00 && wristSizeInCms <= 15.625)
                    {
                        bodyFrame = "medium";
                    }
                    // Large = wrist size over 6.25"
                    else if (wristSizeInCms > 15.625)
                    {
                        bodyFrame = "large";
                    }

                }
                // Height over 5' 5"
                else if (heightInCms > 165.00)
                {
                    // Small = wrist size less than 6.25"
                    if (wristSizeInCms < 15.00 && wristSizeInCms > 0.00)
                    {
                        bodyFrame = "small";
                    }
                    // Medium = wrist size 6.25" to 6.5"
                    else if (wristSizeInCms >= 15.00 && wristSizeInCms <= 16.25)
                    {
                        bodyFrame = "medium";
                    }
                    // Large = wrist size over 6.5"
                    else if (wristSizeInCms > 16.25)
                    {
                        bodyFrame = "large";
                    }
                }

            }

            if (gender.Equals("male"))
            {
                // Height over 5' 5"
                if (heightInCms > 165.00)
                {
                    // Small = wrist size 5.5" to 6.5"
                    if (wristSizeInCms >= 13.75 && wristSizeInCms <= 16.25)
                    {
                        bodyFrame = "small";
                    }
                    // Medium = wrist size 6.5" to 7.5"
                    else if (wristSizeInCms >= 16.25 && wristSizeInCms <= 18.75)
                    {
                        bodyFrame = "medium";
                    }
                    // Large = wrist size over 7.5"
                    else if (wristSizeInCms > 18.75)
                    {
                        bodyFrame = "large";
                    }

                }
            }

            return bodyFrame;
        }

        //IDEAL BODY WEIGHT
        public double fnIdealBodyWt(double height, string units, string gender,string bodyFrame)
        {

            double fbase, wtIncrease, percentage = 10, thresoldHeight = 60;
            if (gender.ToLower() == "male")
            {
                fbase = 106;
                wtIncrease = 6;
            }
            else
            {
                fbase = 100;
                wtIncrease = 5;
            }


            //String sframe = ("large").ToLower();//return form frame function
            String sframe = bodyFrame;//return form frame function
            double fheight;

            //male
            if (gender.ToLower() == "male")
            {
                if (units != "INCH")
                {
                    height = GetHeightInINCH(height, units);//height function;
                    
                    if (sframe == "large")
                    {
                        double a = fbase + (wtIncrease * (height - thresoldHeight));
                        double b = a * (percentage / 100);
                        fheight = a + b;
                    }
                    else if (sframe == "small")
                    {
                        double a = fbase + (wtIncrease * (height - thresoldHeight));
                        double b = a * (percentage / 100);
                        fheight = a - b;
                    }
                    else
                    {
                        fheight = fbase + (wtIncrease * (height - thresoldHeight));
                    }
                }
                else
                {
                    if (sframe == "large")
                    {
                        double a = fbase + (wtIncrease * (height - thresoldHeight));
                        double b = a * (percentage / 100);
                        fheight = a + b;
                    }
                    else if (sframe == "small")
                    {
                        double a = fbase + (wtIncrease * (height - thresoldHeight));
                        double b = a * (percentage / 100);
                        fheight = a - b;
                    }
                    else
                    {
                        fheight = 106 + (6 * (height - 60));
                    }
                }
            }//male end
            //female
            else
            {
                if (units != "INCH")
                {
                    height = GetHeightInINCH(height, units);//height function;
                    if (sframe == "large")
                    {
                        double a = fbase + (wtIncrease * (height - thresoldHeight));
                        double b = a * (percentage / 100);
                        fheight = a + b;
                    }
                    else if (sframe == "small")
                    {
                        double a = fbase + (wtIncrease * (height - thresoldHeight));
                        double b = a * (percentage / 100);
                        fheight = a - b;
                    }
                    else
                    {
                        fheight = fbase + (wtIncrease * (height - thresoldHeight));
                    }
                }
                else
                {
                    if (sframe == "large")
                    {
                        double a = fbase + (wtIncrease * (height - thresoldHeight));
                        double b = a * (percentage / 100);
                        fheight = a + b;
                    }
                    else if (sframe == "small")
                    {
                        double a = fbase + (wtIncrease * (height - thresoldHeight));
                        double b = a * (percentage / 100);
                        fheight = a - b;
                    }
                    else
                    {
                        fheight = fbase + (wtIncrease * (height - thresoldHeight));
                    }
                }

            }//female end
            return Math.Round(fheight * 0.453592,2);
        }//function end

        // Calculate BMI
        public double BMI_General(double Weight, double Height)
        {

            return Math.Round((Weight / (Height * Height)), 2);
        }

        public double GetWeight(double val, string unit)
        {
            double Conversionfactor=0;

            if (unit.ToUpper().Equals("LBS"))
            {
                Conversionfactor = 0.453592;
            }
            else if (unit.ToUpper().Equals("GRAM"))
            {
                Conversionfactor = 0.001;
            }
            else if (unit.ToUpper().Equals("KG"))
            {
                Conversionfactor = 1;
            }
            return Math.Round(val * Conversionfactor,2);
        }

        /// <summary>
        ///  Methode Returen vale in Metter Only
        /// </summary>
        /// <param name="val"></param>
        /// <param name="unit"></param>
        /// <returns></returns>
        public double GetHeight(double val, string unit)
        {
            double Conversionfactor=0;

            if (unit.ToUpper().Equals("INCH"))
            {
                Conversionfactor= 0.0254;
            }
            else if (unit.ToUpper().Equals("FOOT"))
            {
                Conversionfactor = 0.3048;
            }
            else if (unit.ToUpper().Equals("CM"))
            {
                Conversionfactor = 0.01 ;
            }
            else if (unit.ToUpper().Equals("MTR"))
            {
                Conversionfactor = 1;
            }
                
            return Math.Round(val * Conversionfactor,2) ;
        }


        public double GetHeightInCM(double val, string unit)
        {
            double Conversionfactor = 0;

            if (unit.ToUpper().Equals("INCH"))
            {
                Conversionfactor = 2.54;
            }
            else if (unit.ToUpper().Equals("FOOT"))
            {
                Conversionfactor = 30.48;
            }
            else if (unit.ToUpper().Equals("CM"))
            {
                Conversionfactor = 1;
            }
            else if (unit.ToUpper().Equals("MTR"))
            {
                Conversionfactor = 100;
            }

            return Math.Round(val * Conversionfactor, 2);
        }


        public double GetHeightInINCH(double val, string unit)
        {
            double Conversionfactor = 0;

            if (unit.ToUpper().Equals("INCH"))
            {
                Conversionfactor = 1;
            }
            else if (unit.ToUpper().Equals("FOOT"))
            {
                Conversionfactor = 12;
            }
            else if (unit.ToUpper().Equals("CM"))
            {
                Conversionfactor = 0.393701;
            }
            else if (unit.ToUpper().Equals("MTR"))
            {
                Conversionfactor = 39.3701;
            }

            return Math.Round(val * Conversionfactor, 2);
        }
    }
}