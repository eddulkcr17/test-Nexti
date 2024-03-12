import { createSlice } from "@reduxjs/toolkit";

const initialState = [
  {
    id: "1",
    eventDate: "03/14/2024",
    eventDescription: "prueba de ticket 1",
    eventLocation: "ecu, quito , pichincha lira nan y amaru nan",
    eventCost: "5.00",
    eventStatus: "a",
    completed: false,
  },
  {
    id: "2",
    eventDate: "03/14/2024",
    eventDescription: "prueba de ticket 2",
    eventLocation: "ecu, quito , pichincha lira nan y amaru nan",
    eventCost: "5.00",
    eventStatus: "a",
    completed: false,
  },
];

export const ticketSlice = createSlice({
  name: "tickets",
  initialState,
  reducers: {
    addTicket: (state, action) => {
      state.push(action.payload);
    },
    editTicket:(state, action)=>{
const {id,eventDate,eventDescription,eventLocation,eventCost,eventStatus} = action.payload
const foundTicket = state.find(ticket=> ticket.id === id)
if(foundTicket){
  foundTicket.eventCost =eventCost
  foundTicket.eventDate = eventDate
  foundTicket.eventDescription = eventDescription
  foundTicket.eventLocation =eventLocation
  foundTicket.eventStatus=eventStatus
}
    },
    deleteTicket: (state, action) => {
       const ticketFound =  state.find(ticket=> ticket.id === action.payload)
        if (ticketFound) {
            
        }
      },
  },
});

export const {addTicket, deleteTicket,editTicket} = ticketSlice.actions
export default ticketSlice.reducer
