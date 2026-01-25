import { BrowserRouter, Route, Routes } from "react-router-dom";
import PlayersListPage from "./pages/PlayersListPage";
import EditPlayerPage from "./pages/EditPlayerPage";
import AddPlayerPage from "./pages/AddPlayerPage";
import PlayersDetailPage from "./pages/PlayersDetailPage";
function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<PlayersListPage />} />
        <Route path="/player/:id" element={<PlayersDetailPage />} />
        <Route path="/player/add" element={<AddPlayerPage />} />
        <Route path="/player/edit/:id" element={<EditPlayerPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
