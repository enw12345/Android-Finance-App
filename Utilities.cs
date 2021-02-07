using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.InputMethodServices;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Views.InputMethods;

namespace Finance_App
{
    public static class Utilities
    {
        //public static void hideKeyboard(Activity activity)
        //{
        //    InputMethodManager imm = (InputMethodManager)activity.GetSystemServiceName(Activity.INPUT_METHOD_SERVICE);
        //    //Find the currently focused view, so we can grab the correct window token from it.
        //    View view = activity.getCurrentFocus();
        //    //If no view currently has focus, create a new one, just so we can grab a window token from it
        //    if (view == null)
        //    {
        //        view = new View(activity);
        //    }
        //    imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
        //}
    }
}