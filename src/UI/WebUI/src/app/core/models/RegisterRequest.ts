export class RegisterRequest {
  email: string = '';
  userName: string = '';
  firstName: string = '';
  lastName: string = '';
  password: string = '';

  constructor(
    email: string,
    userName: string,
    firstName: string,
    lastName: string,
    password: string,
  ) {
    this.email = email;
    this.firstName = firstName;
    this.lastName = lastName;
    this.password = password;
    this.userName = userName;
  }
}
