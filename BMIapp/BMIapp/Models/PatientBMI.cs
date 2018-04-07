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
        }

        public string Category {
            get { return CalculateBMIcategory(this.BMI); }
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
                return "Underweight";
            }
            if (bmi >= 18.5 && bmi <= 24.9)
            {
                return "Normal Weight";
            }
            if (bmi >= 25.5 && bmi <= 29.9)
            {
                return "Pre-obesity";
            }
            if (bmi >= 30 && bmi <= 34.9)
            {
                return "Obesity class I";
            }
            else
            {
                return "not categorized";
            }

        }


    }
   
}