import { createFeatureSelector, createSelector } from '@ngrx/store';
import { TicketState } from './ticket.reducer';

// Selector del feature. Asume que 'tickets' es la clave bajo la cual se registró el reducer en el StoreModule
export const selectTicketFeature = createFeatureSelector<TicketState>('tickets');

// Selector para obtener todos los tiquetes
export const selectAllTickets = createSelector(
    selectTicketFeature,
    (state: TicketState) => state.tickets
);

// Selector para el estado de carga
export const selectTicketsLoading = createSelector(
    selectTicketFeature,
    (state: TicketState) => state.loading
);

// Selector para errores
export const selectTicketsError = createSelector(
    selectTicketFeature,
    (state: TicketState) => state.error
);
