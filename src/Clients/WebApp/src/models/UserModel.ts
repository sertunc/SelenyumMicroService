export class UserModel {
  userName: string = "";
  token: string = "";

  constructor(userName: string, token: string) {
    this.userName = userName;
    this.token = token;
  }
}
