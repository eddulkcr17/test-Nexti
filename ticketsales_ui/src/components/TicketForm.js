import { useState, useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { addTicket } from "../features/tickets/ticketSlice";
import {v4 as uuid} from 'uuid'
import { useNavigate, useParams } from "react-router-dom";
function TicketForm(){
    const[ticket, setTicket]= useState({
        EventCost: '',
        EventDescription:'',
        EventLocation:'',
        EventDate:'',
    })

    const dispatch= useDispatch()
    const navigate= useNavigate()
    const params = useParams()
    const tickets = useSelector(state=> state.ticket)

    const handleChange =e => {
       setTicket({
        ...ticket,
        [e.target.name]: e.target.value,
       });
    };

    const handleSubmit = (e)=>{
        e.preventDefault();
        if (params.id) {
            
        }else{
            dispatch(addTicket({
                ...ticket,
                id: uuid(),
            }))
        }
        
        navigate('/')
    }

    useEffect(()=> {
    if (params.id) {
        setTicket(tickets.find(ticket=> ticket.id === params.id))
    }
    },[])

    return(
        
        <form onSubmit={handleSubmit} className="bg-zinc-800 max-w-2xl p-4 ">
            <h1 className="justify-center mb-2">Nuevo evento</h1>
            <label htmlFor="EventDate" className="block text-xs font-bold mb-2"></label>
            <input className="w-full p-2 rounded-md bg-zinc-600 md-2" name='EventDate' type="date" placeholder="fecha de l evento" onChange={handleChange} value={ticket.EventDate}/>
            <label htmlFor="EventDescription" className="block text-xs font-bold mb-2"></label>
            <textarea className="w-full p-2 rounded-md bg-zinc-600 md-2" name="EventDescription" placeholder="description" onChange={handleChange} value={ticket.EventDescription}/>
            <label htmlFor="EventCost" className="block text-xs font-bold mb-2"></label>
            <input className="w-full p-2 rounded-md bg-zinc-600 md-2" name="EventCost" type="number" placeholder="costo evento" onChange={handleChange} value={ticket.EventCost}/>
            <label htmlFor="EventLocation" className="block text-xs font-bold mb-2"></label>
            <input className="w-full p-2 rounded-md bg-zinc-600 md-2" name="EventLocation" type="text" placeholder="lugar del evento" onChange={handleChange} value={ticket.EventLocation}/>
            <button className="bg-indigo-600 rounded-md mt-6 justify-end">Save</button>
        </form>
    )
}

export default TicketForm;