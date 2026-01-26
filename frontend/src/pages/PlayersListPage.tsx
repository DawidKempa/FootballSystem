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
    <div className="container mx-auto px-4 py-8">
      <div className="flex justify-between items-center mb-8">
        <h1 className="text-3xl font-bold text-gray-800">Lista zawodników</h1>
        <Link to={"/player/add"}>
          <button className="bg-blue-500 hover:bg-blue-700 rounded-lg text-white px-6 py-2">
            Dodaj zawodników
          </button>
        </Link>
      </div>

      <div className="bg-white rounded-lg shadow p-4 mb-6">
        <p>
          Łącznie zawodników: <strong>{store.players.length}</strong>
        </p>
      </div>
      {store.players.length === 0 ? (
        <p>Brak zawodników. Dodaj pierwszego</p>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {store.players.map((player) => (
            <div
              key={player.id}
              className="bg-white rounded-lg shadow-lg hover:shadow-2xl transition-shadow duration-400"
            >
              <div className="p-6">
                <div className="flex justify-between items-start mb-4">
                  <h3 className="text-xl font-bold text-gray-800">
                    {player.name} {player.lastName}
                  </h3>
                  <div className="bg-blue-500 text-white w-12 h-12 rounded-full flex items-center justify-center font-bold text-lg">
                    {player.number}
                  </div>
                </div>

                <div className="space-y-2 mb-4">
                  <p className="text-gray-600">
                    <span className="font-semibold">Pozycja:</span>{" "}
                    {player.position}
                  </p>
                  <p className="text-gray-600">
                    <span className="font-semibold">Wiek:</span> {player.age}
                    lat
                  </p>
                  <p className="text-gray-600">
                    <span className="font-semibold">Narodowość:</span>{" "}
                    {player.nationality}
                  </p>
                </div>

                <div className="flex justify-between bg-gray-100 rounded-lg p-3 mb-4">
                  <div className="text-center">
                    <p className="text-2xl font-bold text-blue-600">
                      {player.goals}
                    </p>
                    <p className="text-xs text-gray-500">Gole</p>
                  </div>
                  <div className="text-center">
                    <p className="text-2xl font-bold text-blue-600">
                      {player.assists}
                    </p>
                    <p className="text-xs text-gray-500">Asysty</p>
                  </div>
                  <div className="text-center">
                    <p className="text-2xl font-bold text-blue-600">
                      {player.games}
                    </p>
                    <p className="text-xs text-gray-500">Mecze</p>
                  </div>
                </div>
                <Link to={`/player/${player.id}`}>
                  <button className="w-full bg-gray-700 hover:bg-gray-800 text-white py-2 rounded-lg transition">
                    Sprawdź szczegóły
                  </button>
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
