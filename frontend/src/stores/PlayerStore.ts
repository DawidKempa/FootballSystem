import { makeAutoObservable, runInAction } from "mobx";

import {
  fetchPlayers,
  fetchPlayerById,
  createPlayer,
  updatePlayer,
  deletePlayer,
} from "../api/PlayersApi";
import type { Player, CreatePlayerDto, UpdatePlayerDto } from "../types";

class PLayerStore {
  players: Player[] = [];
  selectedPlayer: Player | null = null;
  loading = false;
  error: string | null = null;

  constructor() {
    makeAutoObservable(this); //śledzimy wszystkie pola i metody i automastycznie odśmieżamy komponenty po zmianach
  }

  async loadPlayers() {
    this.loading = true;
    this.error = null;

    try {
      const data = await fetchPlayers();
      runInAction(() => {
        this.players = data;
        this.loading = false;
      });
    } catch (err) {
      runInAction(() => {
        this.error =
          err instanceof Error
            ? err.message
            : "Nie udało się pobrać zawodników";
        this.loading = false;
      });
    }
  }

  async loadPlayerById(id: number) {
    this.loading = true;
    this.error = null;

    try {
      const data = await fetchPlayerById(id);
      runInAction(() => {
        this.selectedPlayer = data;
        this.loading = false;
      });
    } catch (err) {
      runInAction(() => {
        this.error =
          err instanceof Error ? err.message : "Nie udało się pobrać zawodnika";
        this.loading = false;
      });
    }
  }

  async createPlayer(dto: CreatePlayerDto) {
    this.loading = true;
    this.error = null;

    try {
      const newPlayer = await createPlayer(dto);
      runInAction(() => {
        this.players.push(newPlayer);
        this.loading = false;
      });
    } catch (err) {
      runInAction(() => {
        this.error =
          err instanceof Error
            ? err.message
            : "nie udało się stworzyć zawodnika";
        this.loading = false;
      });
      throw err;
    }
  }

  async updatePlayer(id: number, dto: UpdatePlayerDto) {
    this.loading = true;
    this.error = null;
    try {
      const updatedPlayer = await updatePlayer(id, dto);
      runInAction(() => {
        const index = this.players.findIndex((p) => p.id === id);
        if (index !== -1) {
          this.players[index] = updatedPlayer;
        }
        if (this.selectedPlayer?.id === id) {
          this.selectedPlayer = updatedPlayer;
        }
        this.loading = false;
      });
    } catch (err) {
      runInAction(() => {
        this.error =
          err instanceof Error
            ? err.message
            : "nie udał osię zaktaulizować zawodnika";
      });
      throw err;
    }
  }

  async deletePlayer(id: number) {
    this.loading = true;
    this.error = null;
    try {
      await deletePlayer(id);
      runInAction(() => {
        this.players = this.players.filter((p) => p.id !== id);
        if (this.selectedPlayer?.id === id) {
          this.selectedPlayer = null;
        }
        this.loading = false;
      });
    } catch (err) {
      runInAction(() => {
        this.error =
          err instanceof Error ? err.message : "nie udało się usunąć zawodnika";
        this.loading = false;
      });
      throw err;
    }
  }

  clearError() {
    this.error = null;
  }
}

export const playerStore = new PLayerStore();
export default playerStore;
