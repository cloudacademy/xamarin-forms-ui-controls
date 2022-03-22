using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xaml_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgeView : ContentView
    {
        private int age = 21;
        private DateTime dob;

        public AgeView()
        {
            InitializeComponent();
            AgeSlider.Value = age;
        }

        private int AgeFromDOB(DateTime _dob)
        {
            dob = _dob;
            return DateTime.Now.Year - dob.Year;
        }

        private DateTime DOBFromAge(int _age)
        {
            age = _age;
            return DateTime.Now.AddYears(age * -1);
        }
        private void DOB_Picker_DateSelected(object sender, DateChangedEventArgs e)
        {
            age = AgeFromDOB(e.NewDate);
            AgeSlider.Value = age;
        }

        private void AgeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            DOB_Picker.Date = DOBFromAge(Convert.ToInt32(e.NewValue));
            Agelabel.Text = $"Age: {age}";
        }
    }
}