import { fetchPlayers, createPlayer, fetchPlayerById } from "../api/PlayersApi";
import { useEffect, useState } from "react";
import type { Player } from "../types";

export default function PlayersList() {
  const [players, setPlayers] = useState<Player[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    async function LoadPlayers() {
      const data = await fetchPlayers();
      console.log(players);
      setPlayers(data);
      setLoading(false);
    }
    LoadPlayers();
  }, []);

  return (
    <div>
      <h1>Lista piłkarzy</h1>
      <ul>
        {players.map((player) => (
          <li className="flex gap-2" key={player.id}>
            <span>{player.name}</span>
            <span>{player.lastName}</span>
          </li>
        ))}
      </ul>
    </div>
  );
}
