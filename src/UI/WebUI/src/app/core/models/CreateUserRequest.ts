export class CreateUserRequest {
  email: string = '';
  userName: string = '';
  password: string = '';
  firstName: string = '';
  lastName: string = '';
  clockNumber: string = '';
  rfc: string = '';
  socialNumber: string = '';
  hireDate!: Date;
  departmentId: number = 0;
  jobPosition: number = 0;
  salary: number = 0;
  constructor(
    email: string,
    userName: string,
    password: string,
    firstName: string,
    lastName: string,
    clockNumber: string,
    rfc: string,
    socialNumber: string,
    hireDate: Date,
    departmentId: number,
    jobPosition: number,
    salary: number,
  ) {
    this.email = email;
    this.userName = userName;
    this.password = password;
    this.firstName = firstName;
    this.lastName = lastName;
    this.clockNumber = clockNumber;
    this.rfc = rfc;
    this.socialNumber = socialNumber;
    this.hireDate = hireDate;
    this.departmentId = departmentId;
    this.jobPosition = jobPosition;
    this.salary = salary;
  }
}
