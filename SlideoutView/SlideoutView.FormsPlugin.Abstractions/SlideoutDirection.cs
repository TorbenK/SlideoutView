using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlideoutView.FormsPlugin.Abstractions
{
    /// <summary>
    /// Direction where the view will slide out
    /// </summary>
    public enum SlideoutDirection
    {
        /// <summary>
        /// Slide out from the left
        /// </summary>
        Left,
        /// <summary>
        /// Slide out from the top
        /// </summary>
        Top,
        /// <summary>
        /// Slide out from the right
        /// </summary>
        Right,
        /// <summary>
        /// Slide out from the bottom
        /// </summary>
        Bottom
    }
}
