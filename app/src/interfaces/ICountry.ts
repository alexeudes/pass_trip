import { EVisa } from "../Enum/VisaEnum"

export interface ICountry {
    ID: string;
    name: { common: string, official?: string };
    capital?: string[];
    region?: string;
    subregion?: string;
    flags: IFlag;
    languages?: { [key: string]: string };
    area: number;
    population: number;
    timezones: string[];
    currencies: { [key: string]: ICurrency };
    carSide?: string;
    postalCodeFormat?: string;
    startOfWeek?: string;
}

export interface ILanguage {
    langKey: EVisa;
    langName: string;
}

export interface ICurrency {
    name: string;
    symbol: string
}

export interface IFlag {
    png: string;
    svg: string;
}