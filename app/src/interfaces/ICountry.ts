export interface ICountry {
    ID: number;
    name: { common: string};
    capital?: string[];
    region?: string;
    flag?: string;
    languages?: { lang: ILanguage };
    area: number;
    population: number;
    timezones: string[];
    currencies: { id: string, curr: ICurrency };
}

export interface ILanguage {
    langKey: string;
    langName: string;
}

export interface ICurrency {
    currKey: string;
    currName: string
}