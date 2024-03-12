import { configureStore } from "@reduxjs/toolkit";
import ticketsReducer from "../features/tickets/ticketSlice";

export const store = configureStore({
  reducer: {
    tickets: ticketsReducer,
  },
});
