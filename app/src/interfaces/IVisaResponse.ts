export interface IVisaResponse {
    origin: string;
    destination: string;
    visa: IVisaDto;
    country: ICountryDto;
}

export interface IVisaDto {
    code: number;
    description: string;
    numberOfDays?: string;
}

export interface ICountryDto {
    name: string;
    region: string;
    flag: string;
    capitals: string[];
    population: number;
    area: number;
    timezones: string[];
}
