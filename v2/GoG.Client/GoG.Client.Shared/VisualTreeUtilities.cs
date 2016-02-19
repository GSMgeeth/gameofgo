﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace GoG.Client
{
    public static class VisualTreeUtilities
    {
        public static T GetVisualChild<T>(this DependencyObject parent) where T : DependencyObject
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                DependencyObject v = VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                    child = GetVisualChild<T>(v);
                if (child != null)
                    break;
            }
            return child;
        }

    }
}