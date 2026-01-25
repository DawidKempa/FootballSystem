export enum Position {
  Goalkeeper = "Goalkeeper",
  Defender = "Defender",
  Midfielder = "Midfielder",
  Forward = "Forward",
}

export interface Player {
  id: number;
  name: string;
  lastName: string;
  number: number;
  age: number;
  nationality: string;
  position: string;
  games: number;
  goals: number;
  assists: number;
}

export interface CreatePlayerDto {
  name: string;
  lastName: string;
  number: number;
  age: number;
  nationality: string;
  position: string;
  games: number;
  goals: number;
  assists: number;
}

export interface UpdatePlayerDto {
  id: number;
  name: string;
  lastName: string;
  number: number;
  age: number;
  nationality: string;
  position: string;
  games: number;
  goals: number;
  assists: number;
}
