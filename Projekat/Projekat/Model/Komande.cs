using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekat.Model
{
    public class Komande
    {
        public static readonly RoutedUICommand ExitDemo = new RoutedUICommand(
            "Exit demo", "ExitDemo",
            typeof(Komande),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Escape),
              
                
            }
            );
    }
}
