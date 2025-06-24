import { Component, inject, OnInit } from '@angular/core';
import { ContactsDto } from '../Models/contacts.dto';
import { ContactsService } from '../services/contacts-service.service';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { BackButtonComponent } from "../back-button/back-button.component";

@Component({
  selector: 'app-show-contacts',
  imports: [CommonModule, RouterLink],
  standalone: true,
  templateUrl: './show-contacts.component.html',
  styleUrl: './show-contacts.component.scss'
})
export class ShowContactsComponent implements OnInit {
  public contacts: ContactsDto[] = [];

  private _contactsService = inject(ContactsService);


  ngOnInit(): void {
   this.loadContacts();
  }

  loadContacts(): void {
    this._contactsService.getContacts().subscribe({
      next: (data) => {
        this.contacts = data;
      },
      error: (err) => {
        console.error('Error loading contacts:', err);
      }
    });
  }
}
