import { UserSummaryDto } from './UserSummaryDto';

export class DepartmentDto {
  id!: number;
  name!: string;
  code!: string;
  description?: string;
  location?: string;
  manager?: UserSummaryDto;
}
