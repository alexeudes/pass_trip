import { EVisa } from "../Enum/VisaEnum"
export interface ICountry {
    ID: number;
    name: { common: string};
    capital?: string[];
    region?: string;
    flag?: string;
    languages?: string[];
    area: number;
    population: number;
    timezones: string[];
    currencies: { curr: ICurrency };
}

export interface ILanguage {
    langKey: EVisa;
    langName: string;
}

export interface ICurrency {
    name: string;
    symbol: string
}