import { Routes } from '@angular/router';

export const routes: Routes = [
    {path: '', redirectTo: 'show-contacts', pathMatch: 'full'},
    {path: 'show-contacts', loadComponent: () => import('./show-contacts/show-contacts.component').then(m => m.ShowContactsComponent) },
    {path: 'form-contact', loadComponent: () => import('./form-contact/form-contact.component').then(m => m.FormContactComponent) }
];
