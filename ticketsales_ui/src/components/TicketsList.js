import React from "react";
import { useSelector, useDispatch } from "react-redux";
import { deleteTicket } from "../features/tickets/ticketSlice";
import { Link } from "react-router-dom";

export const TicketsList = () => {
  const tickets = useSelector((state) => state.tickets);
  const dispatch = useDispatch();
  const handleDelete = (id) => {
    dispatch(deleteTicket(id));
  };

  return (
    <div className="w-4/6">
      <header className="flex justify-between items-center py-4">
        <h1 className="text-5xl">Eventos disponibles {tickets.length}</h1>
        <Link to="/create-event" className="bg-indigo-600 px-2 py-1 rounded-sm text-sm">Crear Evento</Link>
      </header>
     <div className="grid grid-cols-3 gap-4">
     {tickets.map((ticket) => (
        <div key={ticket.id} className="bg-neutral-800 p-4 rounded-md">
          <header className="flex justify-between">
          <h4>{ticket.eventDate}</h4>
          <div className="flex">
          <Link to={`/edit-event/${ticket.id}`}  className="bg-indigo-800 px-2 py-1 text-xs rounded-md gap-x-2 self-center">Edit</Link>
          <button onClick={() => handleDelete(ticket.id)} className="bg-red-700 px-2 py-1 text-xs rounded-md self-center">Borrar</button>
          
          </div>
          </header>

          <h3>{ticket.eventDescription}</h3>
          <p>{ticket.eventLocation}</p>
          <span>{ticket.eventCost}</span>
          
        </div>
      ))}
     </div>
    </div>
  );
};
