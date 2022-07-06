package com.example.xamarinpresentationjava;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Parcelable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.ListAdapter;
import android.widget.TextView;

import java.util.HashSet;

public class ContactsAdapter extends BaseAdapter implements ListAdapter {
    private ContactList list = new ContactList();
    private Context context;
    private HashSet<Integer> editedValues;

    public ContactsAdapter(Context context, ContactList list, HashSet<Integer> editedValues) {
        this.context = context;
        this.list = list;
        this.editedValues = editedValues;
    }

    @Override
    public int getCount() {
        return list.getRecords().length;
    }

    @Override
    public Object getItem(int i) {
        return list.getRecords()[i];
    }

    @Override
    public long getItemId(int i) {
        return 0;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        View view = convertView;
        if (view == null) {
            LayoutInflater inflater = (LayoutInflater) context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            view = inflater.inflate(R.layout.button_layout, null);
        }

        Button callbtn = (Button)view.findViewById(R.id.btn);
        ContactInfo contactInfo = list.getRecords()[position];
        callbtn.setText(String.format("%s %s", contactInfo.firstName, contactInfo.lastName));
        if(editedValues.contains(position)) {
            callbtn.getBackground().setTint(Color.parseColor("#4DD5DA"));
        }

        callbtn.setOnClickListener(v -> {
            Intent i = new Intent(context, EditActivity.class);
            i.putExtra("Idx", position);
            i.putExtra("FirstName", contactInfo.firstName);
            i.putExtra("LastName", contactInfo.lastName);
            ((Activity)context).startActivityForResult(i, 3);
        });

        return view;
    }
}
