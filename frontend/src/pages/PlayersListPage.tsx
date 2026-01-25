import { observer } from "mobx-react-lite";
import usePlayerStore from "../hooks/usePlayerStore";
import { useEffect } from "react";
import { Link } from "react-router-dom";

const PlayersListPage = observer(() => {
  const store = usePlayerStore();

  useEffect(() => {
    store.loadPlayers();
  }, []);

  if (store.loading) {
    return (
      <div>
        <h1>Ładowanie zawodników</h1>
      </div>
    );
  }

  if (store.error) {
    return (
      <div>
        <h1>Błąd</h1>
        <p>{store.error}</p>
        <button onClick={() => store.loadPlayers()}>Spróbuj ponownie</button>
      </div>
    );
  }

  return (
    <div>
      <div className="header">
        <h1>Lista zawodników</h1>
        <Link to="/player/add">
          <button>Dodaj zawodników</button>
        </Link>
      </div>
      <div>
        <p>
          Łącznie zawodników: <strong>{store.players.length}</strong>
        </p>
      </div>
      {store.players.length === 0 ? (
        <p>Brak zawodników. Dodaj pierwszego</p>
      ) : (
        <div className="grid grid-cols-3 gap-6 mx-30">
          {store.players.map((player) => (
            <div key={player.id}>
              <div className="w-full h-full rounded shadow-lg flex flex-col p-4">
                <div className="flex justify-between mb-2">
                  <div>
                    {player.name} {player.lastName}
                  </div>
                  <div>{player.number}</div>
                </div>
                <div className="">
                  <p>Pozycja: {player.position}</p>
                  <p>Wiek: {player.age}</p>
                  <p>Narodowość: {player.nationality}</p>
                </div>
                <div className="flex gap-2">
                  <span>{player.goals}</span>
                  <span>{player.assists}</span>
                  <span>{player.games}</span>
                </div>
                <Link to={`/player/${player.id}`}>
                  <button>Sprawdź szczegóły</button>
                </Link>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
});

export default PlayersListPage;
