using SlideoutView.FormsPlugin.Abstractions;
using System;
using Xamarin.Forms;
using SlideoutView.FormsPlugin.WindowsPhone;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(SlideoutView.FormsPlugin.Abstractions.SlideoutViewControl), typeof(SlideoutViewRenderer))]
namespace SlideoutView.FormsPlugin.WindowsPhone
{
    /// <summary>
    /// SlideoutView Renderer
    /// </summary>
    public class SlideoutViewRenderer //: TRender (replace with renderer type
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }
    }
}
