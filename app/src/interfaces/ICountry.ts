import { EVisa } from "../Enum/VisaEnum"
export interface ICountry {
    ID: string; // Guid in backend
    name: { common: string, official?: string };
    capital?: string[];
    region?: string;
    flag?: string;
    languages?: { [key: string]: string };
    area: number;
    population: number;
    timezones: string[];
    currencies: { [key: string]: ICurrency };
}

export interface ILanguage {
    langKey: EVisa;
    langName: string;
}

export interface ICurrency {
    name: string;
    symbol: string
}