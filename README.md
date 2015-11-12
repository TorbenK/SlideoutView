# SlideoutView
Control to slide out all types of content


![](http://i.imgur.com/0hhkSeS.gif)![](http://i.imgur.com/gv6lCsE.gif)

![](http://i.imgur.com/jYt16no.gif)![](http://i.imgur.com/lpVJpMV.gif)!



# Usage

#### I recommend to check the Sample project in the Test Folder

No nuget package available yet. Will do it if there is enough interest.

#### Add XML namespace:
```XAML
xmlns:slider="clr-namespace:SlideoutView.FormsPlugin.Abstractions;assembly=SlideoutView.FormsPlugin.Abstractions"
```

#### Create SliderControl
```XAML
<slider:SlideoutControl>
      <slider:SlideoutControl.Content>
          <Label Text="I am slideable" />
      </slider:SlideoutControl.Content>
</slider:SlideoutControl>
```

### Available properties

```C#
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
```
# License

```
The MIT License (MIT)

Copyright (c) [year] [fullname]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
