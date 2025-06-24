import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ContactsService } from '../services/contacts-service.service';
import { BackButtonComponent } from '../back-button/back-button.component';
import { ContactsDto } from '../Models/contacts.dto';

@Component({
  selector: 'app-form-contact',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, BackButtonComponent],
  templateUrl: './form-contact.component.html',
  styleUrl: './form-contact.component.scss'
})
export class FormContactComponent implements OnInit {
  public formContact!: FormGroup;

  public contact!: ContactsDto;
  private _formBuilder = inject(FormBuilder);
  private _contactsService = inject(ContactsService);

  ngOnInit(): void {
    this.formContact = this._formBuilder.group({
      fullName: ['', Validators.required],
      email: ['', Validators.required],
      phone: ['', Validators.required],
      department: ['', Validators.required],
    });
  }

  public onSubmit(): void {
    if (this.formContact.valid) {
      this._contactsService.addContact(this.formContact.value).subscribe(data => {
        this.contact = data;
        this.formContact.reset();
        alert('Contact added successfully!');
      });
    }
  }

}
