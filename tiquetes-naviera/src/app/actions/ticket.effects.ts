import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, map, mergeMap } from 'rxjs/operators';
import { TicketService } from '../services/ticket.service';
import * as TicketActions from './ticket.actions';

@Injectable()
export class TicketEffects {

    loadTickets$ = createEffect(() => this.actions$.pipe(
        ofType(TicketActions.loadTickets),
        mergeMap(() => this.ticketService.getTickets()
            .pipe(
                map(tickets => TicketActions.loadTicketsSuccess({ tickets })),
                catchError(error => of(TicketActions.loadTicketsFailure({ error })))
            )
        )
    ));

    loadTicket$ = createEffect(() => this.actions$.pipe(
        ofType(TicketActions.loadTicket),
        mergeMap((action) => this.ticketService.getTicketById(action.id)
            .pipe(
                map(ticket => TicketActions.loadTicketSuccess({ ticket })),
                catchError(error => of(TicketActions.loadTicketFailure({ error })))
            )
        )
    ));

    updateTicket$ = createEffect(() => this.actions$.pipe(
        ofType(TicketActions.updateTicket),
        mergeMap((action) => this.ticketService.updateTicket(action.ticket)
            .pipe(
                map(ticket => TicketActions.updateTicketSuccess({ ticket })),
                catchError(error => of(TicketActions.updateTicketFailure({ error })))
            )
        )
    ));

    deleteTicket$ = createEffect(() => this.actions$.pipe(
        ofType(TicketActions.deleteTicket),
        mergeMap((action) => this.ticketService.deleteTicket(action.id)
            .pipe(
                map(() => TicketActions.deleteTicketSuccess({ id: action.id })),
                catchError(error => of(TicketActions.deleteTicketFailure({ error })))
            )
        )
    ));


    constructor(
        private actions$: Actions,
        private ticketService: TicketService
    ) { }
}
