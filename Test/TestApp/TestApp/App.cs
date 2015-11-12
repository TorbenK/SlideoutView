using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TestApp
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new SamplePage();
            //MainPage = new SamplePageTableView();
            //MainPage = new SamplePageImage();
            //MainPage = new SamplePageListView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
