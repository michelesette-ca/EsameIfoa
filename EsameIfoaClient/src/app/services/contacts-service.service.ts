import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ContactsDto } from '../Models/contacts.dto';

@Injectable({
  providedIn: 'root'
})
export class ContactsService {

  private _http = inject(HttpClient);
  private _url='https://localhost:44319/api/Contact';

  getContacts(): Observable<ContactsDto[]> {
    return this._http.get<ContactsDto[]>(this._url);
  }

  addContact(contact: ContactsDto): Observable<ContactsDto> {
    return this._http.post<ContactsDto>(this._url, contact);
  }

}
