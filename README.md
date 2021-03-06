# WPF Multiple Document Interface (MDI)
I have resumed the old project started by 'xadet' in 2009, recommended as a possible solution by Microsoft partners, my goal is try to improve it in my free time.
So, what is the reason for the origin of this project?
Microsoft's new strategy has decided not to include MDI support to WPF, and the reason is easily understood. The tendency of the most modern programs is to implement customized forms of "MDI" (see Google Chrome, Excel or Visual Studio itself) that mainly use Paginations, Tabbed documents or dockable windows. So Microsoft has deduced that MDI is no longer the best user interface experience adopted by software and the intention not to use resources to propose a common solution that will probably never fit the intent of each software.

For those who want to reintroduce this old system, they have three solutions:
1. Using Windows Forms interorp
2. Use third party extensions
3. Create a customized implementation of child window manager (the goal of this project)
 

#### [ Original project migrated from [CodePlex](https://wpfmdi.codeplex.com) 24th November 2017 to GitHub [dutts](https://github.com/dutts/wpfmdi)]

## Project Description
A library to add the traditional Windows Forms Multiple Document Interface (MDI) features to WPF. The aim is to resemble the original as much as possible.

## Themes
WPF MDI includes three themes, Luna (XP), Aero (Vista & 7), Aero2 (Windows 10) as well as support for custom themes. Themes are used depending on the operating system, although a theme can be set at compile and/or run time also.

## Using the Control
The control supports both XAML and code use.

To use the control in XAML, add the dll as a reference in the project and add the following line to the top of your XAML file underneath the xmlns declarations

```xml
xmlns:mdi="clr-namespace:WPF.MDI;assembly=WPF.MDI"
```

To create a container add the following code, it works much like a grid or panel does

```xml
<mdi:MdiContainer></mdi:MdiContainer>
```

Optionally, you could specify a theme here too

```xml
<mdi:MdiContainer Theme="Aero"></mdi:MdiContainer>
```

To add a child to the container, add an MdiChild control inside the MdiContainer

```xml
<mdi:MdiContainer Theme="Aero">
    <mdi:MdiChild />
</mdi:MdiContainer>
```

Additional events can be used are
* Closing - It happens before the closed event
* Closed - When MdiChild has been closed
* Activated - When MdiChild is activated (it has the focus)
* Deactivated - When MdiChild is deactivated (it has lost the focus)


Properties here which can be used are
* Name - MANDATORY to set a name to the MdiChild, to allow the correct behavior of the focus between different MdiChild
* Title (e.g. Title="Window 1")
* Icon (e.g. Icon="MyIcon.png")
* ShowIcon - Sets whether the icon should be show (e.g. ShowIcon="false" to hide)
* MinimizeBox - Sets whether the minimize box should be enabled (e.g. MinimizeBox="false" to disable)
* MaximizeBox - Sets whether the maximize box should be enabled (e.g. MaximizeBox="false" to disable)
* Resizable - Sets whether the window is resizable (e.g. Resizable="false" to prevent the user from resizing the window)
* IsActive - Get the current Activated/Deactivated state of MdiChild
* Default FrameworkElement properties - Background, BorderBrush, Margin, Width, Height etc.

For example, the following will set the title of the window to Window 1, prevent the user from resizing the window, disable the minimize button and make the background of the window dark gray

```xml
<mdi:MdiContainer Theme="Aero">
    <mdi:MdiChild Title="Window 1" Resizable="False" MinimizeBox="False" Background="DarkGray" />
</mdi:MdiContainer>
```

Inside the MdiChild element you can specify content such as a custom made user control or create a grid and place all of your control inside the window

```xml
<mdi:MdiContainer Theme="Aero">
    <mdi:MdiChild Title="Window 1" Resizable="False" MinimizeBox="False" Background="DarkGray">
        <Grid>
            <ListBox Margin="12,36,12,12" Name="listBox1" />
            <Button Height="23" HorizontalAlignment="Right" Margin="0,7,12,0" Name="button1" VerticalAlignment="Top" Width="75">Button</Button>
            <TextBox Height="23" Margin="12,7,93,0" Name="textBox1" VerticalAlignment="Top" />
        </Grid>
    </mdi:MdiChild>
</mdi:MdiContainer>
```

To use code to create add windows, create your MdiContainer in the XAML as previously explained, name it something appropriate such as WindowContainer and use the Children list to add windows

```csharp
WindowContainer.Children.Add(new MdiChild()
{
    Title = "Window 1"
});
```
To add controls, use the Content property

```csharp
WindowContainer.Children.Add(new MdiChild()
{
    Title = "Window 1",
    Content = new ExampleControl()
});
```

For more examples, check out the Examples folder in the repo.