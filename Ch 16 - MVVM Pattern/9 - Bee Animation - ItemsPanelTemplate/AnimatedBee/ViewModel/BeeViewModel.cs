using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimatedBee.View;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace AnimatedBee.ViewModel
{
    class BeeViewModel
    {
        // We're taking two steps to encapsulate the Sprites property:
        //  1. The backing field is marked readonly so it can't be overwritten later. (A readonly field can only be written to in its declaration or a constructor)
        //  2. We expose it as an INotifyCollectionChanged property so other classes can only observe it but not modify it

        // UIElement is declared without 'using' to limit the amount of code added to the model. 
        // This is the most abstract class that all sprites extend.
        // For some projects, a subclass like FrameworkElement may be more appropriate, because that's where many properties are defined,
        //      including Width, Height, Opacity, HorizontalAlignment, etc.
        // When AnimatedImage control is added to the _sprites ObservableCollection that's bound to the ItemControl's ItemSource property,
        //      the control is added to the item panel, which is created based on the ItemsPanelTemplate
        private readonly ObservableCollection<System.Windows.UIElement> _sprites = new ObservableCollection<System.Windows.UIElement>();
        public INotifyCollectionChanged Sprites { get { return _sprites; } }

        public BeeViewModel()
        {
            AnimatedImage firstBee = BeeHelper.BeeFactory(50, 50, TimeSpan.FromMilliseconds(50));
            _sprites.Add(firstBee);

            AnimatedImage secondBee = BeeHelper.BeeFactory(200, 200, TimeSpan.FromMilliseconds(10));
            _sprites.Add(secondBee);

            AnimatedImage thirdBee = BeeHelper.BeeFactory(300, 125, TimeSpan.FromMilliseconds(100));
            _sprites.Add(thirdBee);

            BeeHelper.MakeBeeMove(firstBee, 50, 450, 40);
            BeeHelper.SetBeeLocation(secondBee, 80, 260);
            BeeHelper.SetBeeLocation(thirdBee, 230, 100);
        }

    }
}
