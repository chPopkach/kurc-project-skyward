using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Skyward.Tools
{
    class AppHelper
    {
        public static IEnumerable<T?> GetWindowsAtType<T>() where T : Window
        {
            foreach (var unknownWindow in App.Current.Windows)
            {
                if (unknownWindow is T window)
                {
                    yield return window;
                }
            }
        }
        public static IEnumerable<Window?> GetAllWindows()
        {
            foreach (var unknownWindow in App.Current.Windows)
            {
                yield return unknownWindow as Window;
            }
        }
        public static T? GetWindowAtType<T>() where T : Window
        {
            return GetWindowsAtType<T>().FirstOrDefault();
        }
    }
}
