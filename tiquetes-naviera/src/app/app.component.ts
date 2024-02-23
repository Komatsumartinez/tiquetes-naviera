import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TicketFormComponent } from './tickets/ticket-form/ticket-form.component';
import { TicketListComponent } from './tickets/ticket-list/ticket-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TicketFormComponent, TicketListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'tiquetes-naviera';
}
