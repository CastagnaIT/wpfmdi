using System.Windows.Controls;
using WPF.MDI;

namespace Example.Controls
{
    /// <summary>
    /// Interaction logic for ExampleControl.xaml
    /// </summary>
    public partial class ExampleControl : UserControl
    {
        MdiChild MdiChild_Parent = null;
        private int ActivatedCounter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleControl"/> class.
        /// </summary>
        public ExampleControl()
        {
            InitializeComponent();

            Width = double.NaN;
            Height = double.NaN;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //This is a simple example to manage the events of the parent MdiChild directly within the UserControl

            //Get the parent MdiChild
            MdiChild_Parent = Helper.FindParent<MdiChild>(this);


            //Set the event handlers
            if (MdiChild_Parent != null)
            {
                MdiChild_Parent.Activated += MdiChild_Parent_Activated;
            }
        }

        private void MdiChild_Parent_Activated(object sender, System.Windows.RoutedEventArgs e)
        {
            ActivatedCounter += 1;
            LB_ActivatedCounter.Content = "Activated event counter: " + ActivatedCounter + " times";
        }
    }
}
