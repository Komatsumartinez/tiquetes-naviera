import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Ticket } from '../../models/ticket.model';
import { Store } from '@ngrx/store';
import { loadTickets } from '../../actions/ticket.actions';
import { selectAllTickets } from '../../actions/ticket.selector';
import { CommonModule } from '@angular/common'; // Importa CommonModule

@Component({
  selector: 'app-ticket-list',
  templateUrl: './ticket-list.component.html',
  styleUrls: ['./ticket-list.component.scss'],
  imports: [CommonModule], // Asegúrate de incluir CommonModule aquí
  standalone: true
})
export class TicketListComponent implements OnInit {
  tickets$: Observable<Ticket[]>;

  constructor(private store: Store) {
    this.tickets$ = this.store.select(selectAllTickets);
  }

  ngOnInit(): void {
    this.store.dispatch(loadTickets());
  }
}
