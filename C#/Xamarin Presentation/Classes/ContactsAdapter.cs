using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Xamarin_Presentation.Classes
{
    public class ContactsAdapter : BaseAdapter<ContactInfo>, IListAdapter
    {
        private readonly ContactList _list;
        private readonly Context _context;
        private readonly HashSet<int> _editedValues;

        public ContactsAdapter(Context context, ContactList list, HashSet<int> editedValues)
        {
            this._context = context;
            this._list = list;
            this._editedValues = editedValues;
        }

        public override int Count => _list.Records.Length;

        public override ContactInfo this[int position] => _list.Records[position];

        public override long GetItemId(int position)
        {
            return 0;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                LayoutInflater inflater = (LayoutInflater)_context.GetSystemService(Context.LayoutInflaterService);
                view = inflater.Inflate(Resource.Layout.button_layout, null);
            }

            Button callbtn = (Button)view.FindViewById(Resource.Id.btn);
            ContactInfo contactInfo = _list.Records[position];
            callbtn.Text = $"{contactInfo.firstName} {contactInfo.lastName}";
            if (_editedValues.Contains(position))
            {
                callbtn.Background.SetTint(Color.ParseColor("#4DD5DA"));
            }

            callbtn.SetOnClickListener(v => {
                Intent i = new Intent(_context, typeof(EditActivity));
                i.PutExtra("Idx", position);
                i.PutExtra("FirstName", contactInfo.firstName);
                i.PutExtra("LastName", contactInfo.lastName);
                ((Activity)_context).StartActivityForResult(i, 3, null);
            });

            return view;
        }
    }
}