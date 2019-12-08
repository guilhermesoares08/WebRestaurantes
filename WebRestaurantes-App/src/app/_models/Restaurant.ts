import { Image } from './Image';

export interface Restaurant {
  id: number;
  description: string;
  email: string;
  ownerId: number;
  createDate: Date;
  updateDate: Date;
  vendorId: string;
  environmentId: string;
  images: Image[];
}
