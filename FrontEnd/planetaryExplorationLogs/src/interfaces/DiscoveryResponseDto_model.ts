import { DiscoveryDropDownDto } from './DiscoveryDropDownDto_model';
import { DiscoveryFormDto } from './DiscoveryFormDto_model';

export interface DiscoveryResponse {
  data:
    | DiscoveryDropDownDto
    | DiscoveryFormDto
    | DiscoveryFormDto[]
    | DiscoveryDropDownDto[];
  message: string;
}
