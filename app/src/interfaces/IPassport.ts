import { EVisa } from "../Enum/VisaEnum";

export interface IPassport {
    ID: number;
    origin?: string;
    destination?: string;
    requirement: EVisa;
}