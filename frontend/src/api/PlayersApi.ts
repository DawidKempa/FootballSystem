import api from "./api.ts";
import type { Player, CreatePlayerDto, UpdatePlayerDto } from "../types";

export const fetchPlayers = async () => {
  const response = await api.get("/player");
  return response.data;
};

export const fetchPlayerById = async (id: number) => {
  const response = await api.get(`/player/${id}`);
  return response.data;
};

export const createPlayer = async (player: CreatePlayerDto) => {
  const response = await api.post("/player", player);
  return response.data;
};

export const updatePlayer = async (id: number, player: UpdatePlayerDto) => {
  const response = await api.put(`/player/${id}`, player);
  return response.data;
};

export const deletePlayer = async (id: number) => {
  await api.delete(`/player/${id}`);
};
