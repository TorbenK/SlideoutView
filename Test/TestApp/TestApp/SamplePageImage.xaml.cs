using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlideoutView.FormsPlugin.Abstractions;

using Xamarin.Forms;

namespace TestApp
{
    public partial class SamplePageImage : ContentPage
    {
        public SamplePageImage()
        {
            InitializeComponent();
            
            this.BindingContext = new SamplePageViewModel();
        }
    }
}
