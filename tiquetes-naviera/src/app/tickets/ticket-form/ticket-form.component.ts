import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { ReactiveFormsModule } from '@angular/forms';
import { addTicket, updateTicket } from '../../actions/ticket.actions';
import { Ticket } from '../../models/ticket.model';

@Component({
  selector: 'app-ticket-form',
  templateUrl: './ticket-form.component.html',
  styleUrls: ['./ticket-form.component.scss'],
  imports: [ReactiveFormsModule],
  standalone: true
})
export class TicketFormComponent implements OnInit {
  ticketForm: FormGroup;
  isEdit = false; // Determina si el formulario es para editar un tiquete existente
  currentTicket: Ticket | null = null; // Ticket actual en caso de edición

  constructor(private fb: FormBuilder, private store: Store) {
    this.ticketForm = this.fb.group({
      destino: ['', Validators.required],
      pasajeros: ['', Validators.required],
      fecha: ['', Validators.required],
      nombre: ['', Validators.required],
      apellidos: ['', Validators.required],
      documento: ['', Validators.required],
      sexo: ['', Validators.required],
      nacionalidad: ['', Validators.required],
      fechaNacimiento: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    // Si es un formulario de edición, puedes cargar los datos del tiquete aquí
    // Por ejemplo, usando algún servicio o NgRx store para obtener el tiquete por ID
    if (this.isEdit && this.currentTicket) {
      this.ticketForm.patchValue(this.currentTicket);
    }
  }

  onSubmit(): void {
    if (this.ticketForm.valid) {
      const ticketData: Ticket = {
        ...this.currentTicket, // Asegura que el id se mantenga en caso de una edición
        ...this.ticketForm.value
      };

      if (this.isEdit) {
        // Dispara la acción de actualizar tiquete
        this.store.dispatch(updateTicket({ ticket: ticketData }));
      } else {
        // Dispara la acción de agregar tiquete
        // Asume que el backend genera el ID para nuevos tiquetes, por lo que no se incluye aquí
        this.store.dispatch(addTicket({ ticket: ticketData }));
      }
    }
  }

  // Otras funciones del componente, como manejo de cambios, validaciones, etc.
}
