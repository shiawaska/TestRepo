import { PlanetDropDownDto } from './PlanetDropDownDto_model';
import { PlanetFormDto } from './PlanetFormDto_model';

export interface PlanetResponseDto {
  data:
    | PlanetDropDownDto
    | PlanetFormDto
    | PlanetFormDto[]
    | PlanetDropDownDto[];
  message: string;
}
