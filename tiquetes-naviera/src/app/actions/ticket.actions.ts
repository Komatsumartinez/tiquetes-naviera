import { createAction, props } from '@ngrx/store';
import { Ticket } from '../models/ticket.model';


export const addTicket = createAction(
  '[Ticket] Add Ticket',
  props<{ ticket: Ticket }>()
);

export const loadTickets = createAction('[Ticket] Load Tickets');

export const loadTicketsSuccess = createAction(
  '[Ticket] Load Tickets Success',
  props<{ tickets: Ticket[] }>()
);

export const loadTicketsFailure = createAction(
  '[Ticket] Load Tickets Failure',
  props<{ error: any }>()
);

export const loadTicket = createAction(
  '[Ticket] Load Ticket',
  props<{ id: string }>()
);

export const loadTicketSuccess = createAction(
  '[Ticket] Load Ticket Success',
  props<{ ticket: Ticket }>()
);

export const loadTicketFailure = createAction(
  '[Ticket] Load Ticket Failure',
  props<{ error: any }>()
);


export const updateTicket = createAction(
  '[Ticket] Update Ticket',
  props<{ ticket: Ticket }>()
);

export const updateTicketSuccess = createAction(
  '[Ticket] Update Ticket Success',
  props<{ ticket: Ticket }>()
);

export const updateTicketFailure = createAction(
  '[Ticket] Update Ticket Failure',
  props<{ error: any }>()
);


export const deleteTicket = createAction(
  '[Ticket] Delete Ticket',
  props<{ id: string }>()
);

export const deleteTicketSuccess = createAction(
  '[Ticket] Delete Ticket Success',
  props<{ id: string }>()
);

export const deleteTicketFailure = createAction(
  '[Ticket] Delete Ticket Failure',
  props<{ error: any }>()
);
