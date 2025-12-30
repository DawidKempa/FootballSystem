import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";

import PlayersList from "./components/PlayersList.tsx";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <PlayersList />
  </StrictMode>
);
