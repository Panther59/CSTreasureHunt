import { User } from "./User";

export class AuthenticateResponse {
  user: User;
  token: string;
}
