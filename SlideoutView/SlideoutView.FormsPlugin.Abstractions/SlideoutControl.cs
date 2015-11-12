using System;
using Xamarin.Forms;

namespace SlideoutView.FormsPlugin.Abstractions
{
    /// <summary>
    /// A view which can slideout to any direction
    /// </summary>
    public class SlideoutControl : RelativeLayout
    {
        /// <summary>
        /// Default animation length
        /// </summary>
        private const uint DefaultAnimationLength = 250;

        /// <summary>
        /// Bindable property for the <c>SlideOutDirection</c>
        /// </summary>
        public static readonly BindableProperty SlideOutDirectionProperty =
            BindableProperty.Create<SlideoutControl, SlideoutDirection>(
                p => p.SlideOutDirection,
                SlideoutDirection.Left,
                BindingMode.TwoWay,
                null,
                SlideOutDirectionChanged);
        /// <summary>
        /// Bindable property for the <c>WidthScale</c>
        /// </summary>
        public static readonly BindableProperty SizeScaleProperty =
            BindableProperty.Create<SlideoutControl, float>(
                p => p.SizeScale,
                0.5f,
                BindingMode.TwoWay,
                null,
                SizeScaleChanged);
        /// <summary>
        /// Bindable property for the <c>FixedWidth</c>
        /// </summary>
        public static readonly BindableProperty FixedSizeProperty =
            BindableProperty.Create<SlideoutControl, double>(
                p => p.FixedSize,
                -1,
                BindingMode.TwoWay,
                null,
                FixedSizeChanged);
        /// <summary>
        /// Bindable property for the <c>Content</c>
        /// </summary>
        public static readonly BindableProperty ContentProperty =
            BindableProperty.Create<SlideoutControl, View>(
                p => p.Content,
                default(View),
                BindingMode.TwoWay,
                null,
                ContentChanged);
        /// <summary>
        /// Bindable property for <c>IsPresented</c>
        /// </summary>
        public static readonly BindableProperty IsPresentedProperty =
            BindableProperty.Create<SlideoutControl, bool>(
                p => p.IsPresented,
                default(bool),
                BindingMode.TwoWay,
                null,
                IsPresentedChanged);

        /// <summary>
        /// The sliding direction of the <c>SlideoutView</c> 
        /// </summary>
        public SlideoutDirection SlideOutDirection
        {
            get { return (SlideoutDirection)this.GetValue(SlideOutDirectionProperty); }
            set { this.SetValue(SlideOutDirectionProperty, value); }
        }
        /// <summary>
        /// Gets/Sets the width of the <c>SlideoutView</c> in relation to the parent width.
        /// Default value is <c>0.5</c>
        /// </summary>
        public float SizeScale
        {
            get { return (float)this.GetValue(SizeScaleProperty); }
            set { this.SetValue(SizeScaleProperty, value); }
        }
        /// <summary>
        /// Gets/Sets a fixed width of the <c>Slideoutview</c>. If this is set, it will override the <c>WidthScale</c>. 
        /// Default value is <value>-1</value>
        /// </summary>
        public double FixedSize
        {
            get { return (double)this.GetValue(FixedSizeProperty); }
            set { this.SetValue(FixedSizeProperty, value); }
        }
        /// <summary>
        /// Gets/Sets the content which is displayed inside the <c>Slideoutview</c>
        /// </summary>
        public View Content
        {
            get { return (View)this.GetValue(ContentProperty); }
            set { this.SetValue(ContentProperty, value); }
        }
        /// <summary>
        /// Gets/Sets if the <c>SlideoutView</c> is currently presented.
        /// If this changes, it will toggle the animation
        /// </summary>
        public bool IsPresented
        {
            get { return (bool)this.GetValue(IsPresentedProperty); }
            set { this.SetValue(IsPresentedProperty, value); }
        }
        /// <summary>
        /// Gets the current size of the <c>SlideoutView</c>
        /// </summary>
        public double Size
        {
            get
            {
                if (this.ParentView == null) return 0;

                if (!this.IsPresented) return 0;
                if (this.FixedSize > 0) return this.FixedSize;

                if (this.SlideOutDirection == SlideoutDirection.Left ||
                    this.SlideOutDirection == SlideoutDirection.Right)
                    return this.ParentView.Width * this.SizeScale;
                else
                    return this.ParentView.Height * this.SizeScale;
            }
        }
        /// <summary>
        /// The width used to layout the <c>SlideoutView</c> 
        /// </summary>
        private double LayoutToWidth
        {
            get
            {
                if (this.ParentView == null) return 0;

                return
                    (this.SlideOutDirection == SlideoutDirection.Left ||
                    this.SlideOutDirection == SlideoutDirection.Right) ?
                        this.Size :
                        this.ParentView.Width;
            }
        }
        /// <summary>
        /// The height used to layout the <c>SlideoutView</c> 
        /// </summary>
        private double LayoutToHeight
        {
            get
            {
                if (this.ParentView == null) return 0;

                return
                    (this.SlideOutDirection == SlideoutDirection.Top ||
                    this.SlideOutDirection == SlideoutDirection.Bottom) ?
                        this.Size :
                        this.ParentView.Height;
            }
        }
        /// <summary>
        /// Handle property changed of <c>SlideOutDirection</c>
        /// </summary>
        /// <param name="obj">The <c>SlideoutView</c></param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        private static void SlideOutDirectionChanged(BindableObject obj, SlideoutDirection oldValue, SlideoutDirection newValue)
        {
            var view = obj as SlideoutControl;
            if (view == null) return;

            if (view.IsPresented)
                throw new InvalidOperationException("Can't change SlideOutDirection when SlideoutView is currently presented");

            view.ForceLayout();
        }
        /// <summary>
        /// Handle property changed of <c>SizeScale</c>
        /// </summary>
        /// <param name="obj">The <c>SlideoutView</c></param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        private static void SizeScaleChanged(BindableObject obj, float oldValue, float newValue)
        {
            var view = obj as SlideoutControl;
            if (view == null) return;

            if (newValue < 0.1f || newValue > 1)
                throw new ArgumentException("SizeScale must be between 0 and 1");

            view.ForceLayout();
        }
        /// <summary>
        /// Handle property changed of <c>FixedSize</c>
        /// </summary>
        /// <param name="obj">The <c>SlideoutView</c></param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        private static void FixedSizeChanged(BindableObject obj, double oldValue, double newValue)
        {
            var view = obj as SlideoutControl;
            if (view == null) return;

            view.ForceLayout();
        }
        /// <summary>
        /// Handle property changed of <c>Content</c>
        /// </summary>
        /// <param name="obj">The <c>SlideoutView</c></param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        private static void ContentChanged(BindableObject obj, View oldValue, View newValue)
        {
            var view = obj as SlideoutControl;
            if (view == null) return;
            
            if (oldValue != null)
                view.Children.Remove(oldValue);

            if (newValue != null)
            {
                view.Children.Add(
                    newValue,
                    Constraint.RelativeToParent(
                        view.GetX),
                    Constraint.RelativeToParent(
                        view.GetY),
                    Constraint.RelativeToParent((p) => view.LayoutToWidth),
                    Constraint.RelativeToParent((p) => view.LayoutToHeight));
            }
        }
        /// <summary>
        /// Handle property changed of <c>IsPresented</c>
        /// </summary>
        /// <param name="obj">The <c>SlideoutView</c></param>
        /// <param name="oldValue">Old value</param>
        /// <param name="newValue">New value</param>
        private static void IsPresentedChanged(BindableObject obj, bool oldValue, bool newValue)
        {
            var view = obj as SlideoutControl;
            if (view == null) return;

            if (newValue)
                view.Expand();
            else
                view.Hide();
        }
        /// <summary>
        /// Returns the horizontal position based on the parent
        /// </summary>
        /// <param name="layout">The parent</param>
        /// <returns>The horizontal position</returns>
        private double GetX(RelativeLayout layout)
        {
            double x = 0;
            if (this.SlideOutDirection == SlideoutDirection.Right)
                x = layout.Width;
            return x;
        }
        /// <summary>
        /// Returns the vertical position based on the parent
        /// </summary>
        /// <param name="layout">The parent</param>
        /// <returns>The vertical position</returns>
        private double GetY(RelativeLayout layout)
        {
            double y = 0;
            if (this.SlideOutDirection == SlideoutDirection.Bottom)
                y = layout.Height;
            return y;
        }
        /// <summary>
        /// Expand the <c>SlideoutView</c>
        /// </summary>
        private void Expand()
        {
            double x = this.Content.X;
            double y = this.Content.Y;

            if(this.SlideOutDirection == SlideoutDirection.Right)
            {
                if(this.FixedSize > 0)
                    x = this.ParentView.Width - this.FixedSize;
                else
                    x = this.ParentView.Width - this.ParentView.Width * this.SizeScale;
            }
            if(this.SlideOutDirection == SlideoutDirection.Bottom)
            {
                if(this.FixedSize > 0)
                    y = this.ParentView.Height - this.FixedSize;
                else
                    y = this.ParentView.Height - this.ParentView.Height * this.SizeScale;
            }
            
            this.Content.LayoutTo(
                new Rectangle(
                    x, 
                    y, 
                    this.LayoutToWidth, 
                    this.LayoutToHeight),
                DefaultAnimationLength);
                    
        }
        /// <summary>
        /// Hides the <c>SlideOutView</c>
        /// </summary>
        private void Hide()
        {
            var x = this.GetX(this);
            var y = this.GetY(this);

            this.Content.LayoutTo(
                new Rectangle(
                    x,
                    y,
                    this.LayoutToWidth,
                    this.LayoutToHeight),
                DefaultAnimationLength);
        }
    }
}
