package com.example.xamarinpresentationjava;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;

import androidx.appcompat.app.AppCompatActivity;

import java.util.Objects;

public class EditActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edit);
        Button submitButton = findViewById(R.id.submitButton);

        Intent intent = this.getIntent();
        String firstName = intent.getStringExtra("FirstName");
        String lastName = intent.getStringExtra("LastName");

        EditText firstNameEdit = findViewById(R.id.firstName);
        EditText lastNameEdit = findViewById(R.id.lastName);

        firstNameEdit.setText(firstName);
        lastNameEdit.setText(lastName);

        submitButton.setOnClickListener(b -> {
            String newFirstName = firstNameEdit.getText().toString();
            String newLastName = lastNameEdit.getText().toString();
            Intent result = new Intent();
            result.putExtra("Idx", intent.getIntExtra("Idx", -1));

            if(!Objects.equals(newFirstName, firstName) || !Objects.equals(newLastName, lastName)) {
                result.putExtra("FirstName", newFirstName);
                result.putExtra("LastName", newLastName);
            } else {
                result.putExtra("FirstName", "");
                result.putExtra("LastName", "");
            }

            setResult(RESULT_OK, result);
            finish();
        });
    }
}
