import { Location } from '@angular/common';
import { Component, inject } from '@angular/core';


@Component({
  selector: 'app-back-button',
  imports: [],
  standalone: true,
  templateUrl: './back-button.component.html',
  styleUrl: './back-button.component.scss'
})
export class BackButtonComponent {

  private _location = inject(Location);

  public goBack(): void {
    this._location.back();
  }

}
