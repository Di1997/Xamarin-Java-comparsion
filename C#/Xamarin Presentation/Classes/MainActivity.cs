using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.Annotations;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Java.Lang;
using Xamarin_Presentation.Classes;
using String = Java.Lang.String;

namespace Xamarin_Presentation
{
    [Activity(MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView contactView;
        ContactList contactList = new ContactList();
        HashSet<int> editedValues = new HashSet<int>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            contactView = FindViewById(Resource.Id.button_list) as ListView;
            contactView.Adapter = new ContactsAdapter(this, contactList, editedValues);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (data == null || requestCode != 3 || resultCode != Result.Ok) return;

            string firstName = data.GetStringExtra("FirstName");
            string lastName = data.GetStringExtra("LastName");
            int idx = data.GetIntExtra("Idx", -1);

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || idx == -1) return;

            ContactInfo contact = contactList.Records[idx];
            contact.firstName = firstName;
            contact.lastName = lastName;

            editedValues.Add(idx);

            BaseAdapter adapter = (BaseAdapter)contactView.Adapter;
            adapter.NotifyDataSetChanged();
        }
    }
}
