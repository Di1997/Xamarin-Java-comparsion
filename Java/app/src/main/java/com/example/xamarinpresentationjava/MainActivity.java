package com.example.xamarinpresentationjava;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.BaseAdapter;
import android.widget.ListView;

import java.util.HashSet;

public class MainActivity extends AppCompatActivity {
    ListView contactView;
    ContactList contactList = new ContactList();
    HashSet<Integer> editedValues = new HashSet<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        contactView = findViewById(R.id.button_list);
        contactView.setAdapter(new ContactsAdapter(this, contactList, editedValues));
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if(data == null || requestCode != 3 || resultCode != RESULT_OK) return;

        String firstName = data.getStringExtra("FirstName");
        String lastName = data.getStringExtra("LastName");
        int idx = data.getIntExtra("Idx", -1);

        if(firstName.equals("") || lastName.equals("") || idx == -1) return;

        ContactInfo contact = contactList.getRecords()[idx];
        contact.firstName = firstName;
        contact.lastName = lastName;

        editedValues.add(idx);

        BaseAdapter adapter = (BaseAdapter) contactView.getAdapter();
        adapter.notifyDataSetChanged();
    }
}