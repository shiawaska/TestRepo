import { MissionDropDownDto } from './MissionDropDownDto_model';
import { MissionFormDto } from './MissionFormDto_model';

export interface MissionResponseDto {
  data:
    | MissionDropDownDto
    | MissionFormDto
    | MissionFormDto[]
    | MissionDropDownDto[];
  message: string;
}
