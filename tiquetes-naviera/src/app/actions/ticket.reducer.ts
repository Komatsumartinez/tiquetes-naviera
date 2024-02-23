import { createReducer, on } from '@ngrx/store';
import { Ticket } from '../models/ticket.model';
import * as TicketActions from '../actions/ticket.actions';

export interface TicketState {
  tickets: Ticket[];
  error: string | null;
  loading: boolean;
}

export const initialState: TicketState = {
  tickets: [],
  error: null,
  loading: false,
};

export const ticketReducer = createReducer(
  initialState,
  on(TicketActions.loadTickets, state => ({ ...state, loading: true })),
  on(TicketActions.loadTicketsSuccess, (state, { tickets }) => ({
    ...state,
    loading: false,
    tickets
  })),
  on(TicketActions.loadTicketsFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
  })),
  on(TicketActions.addTicket, state => ({ ...state, loading: true })),
  on(TicketActions.updateTicket, state => ({ ...state, loading: true })),
  on(TicketActions.updateTicketSuccess, (state, { ticket }) => ({
    ...state,
    loading: false,
    tickets: state.tickets.map(t => t.id === ticket.id ? ticket : t)
  })),
  on(TicketActions.updateTicketFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
  })),
  on(TicketActions.deleteTicket, state => ({ ...state, loading: true })),
  on(TicketActions.deleteTicketSuccess, (state, { id }) => ({
    ...state,
    loading: false,
    tickets: state.tickets.filter(t => t.id !== id)
  })),
  on(TicketActions.deleteTicketFailure, (state, { error }) => ({
    ...state,
    loading: false,
    error
  }))
);
