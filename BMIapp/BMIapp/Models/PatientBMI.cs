using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BMIapp.Models
{
    public class PatientBMI
    {

        public int Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public double Height { get; set; }

        public double BMI
        {
            get { return CalculateBMI(this); }
            set { }
        }

        public string Category {
            get { return CalculateBMIcategory(this.BMI);  }
            set { }
        }


        public PatientBMI (double weight, double height)
        {
            Weight = weight;
            Height = height;
        }






        private double CalculateBMI(PatientBMI patient)
        {
            double bmi = patient.Weight / Math.Pow(patient.Height, 2);
            double roundedBmi = Math.Round(bmi, 1);

            return roundedBmi;
        }

        private string CalculateBMIcategory (double bmi)
        {
            string category;

            if (bmi < 18.5)
            {
                return BMICategory.Underweight.ToString();
            }
            if (bmi >= 18.5 && bmi <= 24.9)
            {
                return BMICategory.Normal_Weight.ToString();
            }
            if (bmi >= 25 && bmi <= 29.9)
            {
                return BMICategory.Pre_obesity.ToString();
            }
            if (bmi >= 30 && bmi <= 34.9)
            {
                return BMICategory.Obesity_class_I.ToString();
            }
            else
            {
                return "not categorized";
            }

        }


    }
   
}