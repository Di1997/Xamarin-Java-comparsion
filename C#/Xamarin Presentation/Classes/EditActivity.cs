using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace Xamarin_Presentation.Classes
{
    [Activity]
    public class EditActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_edit);
            Button submitButton = FindViewById(Resource.Id.submitButton) as Button;

            Intent intent = this.Intent;
            string firstName = intent.GetStringExtra("FirstName");
            string lastName = intent.GetStringExtra("LastName");

            EditText firstNameEdit = FindViewById(Resource.Id.firstName) as EditText;
            EditText lastNameEdit = FindViewById(Resource.Id.lastName) as EditText;

            firstNameEdit.Text = firstName;
            lastNameEdit.Text = lastName;

            submitButton.SetOnClickListener(b => {
                string newFirstName = firstNameEdit.Text;
                string newLastName = lastNameEdit.Text;
                Intent result = new Intent();
                result.PutExtra("Idx", intent.GetIntExtra("Idx", -1));

                if (newFirstName != firstName || newLastName != lastName)
                {
                    result.PutExtra("FirstName", newFirstName);
                    result.PutExtra("LastName", newLastName);
                }
                else
                {
                    result.PutExtra("FirstName", "");
                    result.PutExtra("LastName", "");
                }

                SetResult(Result.Ok, result);
                Finish();
            });
        }
    }
}