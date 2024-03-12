import "./App.css";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import TicketForm from "./components/TicketForm";
import { TicketsList } from "./components/TicketsList";

function App() {
  return (
    <div className="bg-zinc-900 h-screen text-white">
      <div className="flex items-center justify-center h-full">
      <BrowserRouter>
        <Routes>
          <Route path="/" element={<TicketsList/>}/>
          <Route path="/create-event" element={<TicketForm/>}/>
          <Route path="/edit-event/:id" element={<TicketForm/>}/>
        </Routes>
      </BrowserRouter>
      </div>

    </div>
  );
}

export default App;
