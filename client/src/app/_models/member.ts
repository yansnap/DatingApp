import { Photo } from "./photo";

export interface member {
        id: number;
        username: string;
        photoUrl: string;
        age: number;
        knowsAs?: any;
        created: Date;
        lastActive: Date;
        gender: string;
        introduction: string;
        lookingFor: string;
        interests: string;
        city: string;
        country: string;
        photos: Photo[];
}


