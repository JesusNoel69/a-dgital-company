export class UserSummaryDto {
  constructor(id: string, fullName: string, email: string) {
    this.id = id;
    this.fullName = fullName;
    this.email = email;
  }
  id!: string;
  fullName!: string;
  email!: string;
}
