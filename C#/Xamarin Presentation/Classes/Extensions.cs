using System;
using Android.Views;

namespace Xamarin_Presentation.Classes
{
    public static class Extensions
    {
        public static void SetOnClickListener(this View v1, Action<View> v)
        {
            v1.SetOnClickListener(new OnClickListener(v));
        }

        private class OnClickListener : Java.Lang.Object, View.IOnClickListener
        {
            private readonly Action<View> _act;

            internal OnClickListener(Action<View> act)
            {
                _act = act;
            }

            public void OnClick(View v)
            {
                _act.Invoke(v);
            }
        }
    }
}