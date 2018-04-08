using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace BMIapp.Models
{
    public enum BMICategory
    {
        [Description("Underweight")]
        Underweight,

        [Description("Normal Weight")]
        Normal_Weight,

        [Description("Pre-Obesity")]
        Pre_obesity,

        [Description("Obesity class I")]
        Obesity_class_I
    }
}