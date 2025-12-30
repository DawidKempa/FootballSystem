import api from "./api.ts";
import type { Player } from "../types";

export const fetchPlayers = async () => {
  const response = await api.get("/player");
  return response.data;
};

export const fetchPlayerById = async (Id: number) => {
  const response = await api.get(`/player/${Id}`);
  return response.data;
};

export const createPlayer = async (player: Player) => {
  const response = await api.post("/player", player);
  return response.data;
};
