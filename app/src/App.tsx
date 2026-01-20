import React, { useState, useEffect } from 'react';
import { ICountry } from './interfaces/ICountry';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "./components/ui/select";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "./components/ui/card";
import { Globe, PlaneTakeoff, PlaneLanding, MapPin, Users, Globe2, Languages, Compass, Wallet } from 'lucide-react';

function App() {
  const [countries, setCountries] = useState<ICountry[]>([]);
  const [loading, setLoading] = useState(true);
  const [selectedOriginCountry, setSelectedOriginCountry] = useState<string>("");
  const [selectedDestinationCountry, setSelectedDestinationCountry] = useState<string>("");
  const [countrySelected, setCountrySelected] = useState<ICountry | null>(null);

  useEffect(() => {
    const fetchCountries = async () => {
      try {
        const response = await fetch('https://localhost:7109/countries/');
        const data = await response.json();
        // Sort countries alphabetically
        const sortedData = data.sort((a: ICountry, b: ICountry) =>
          a.name.common.localeCompare(b.name.common)
        );
        setCountries(sortedData);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching data:', error);
        setLoading(false);
      }
    };

    fetchCountries();
  }, []);

  const handleOriginChange = (value: string) => {
    setSelectedOriginCountry(value);
    // Clear and block destination
    setSelectedDestinationCountry("");
    setCountrySelected(null);
  };

  const handleDestinationChange = (value: string) => {
    setSelectedDestinationCountry(value);
    const country = countries.find(c => c.name.common === value);
    if (country) {
      setCountrySelected(country);
    }
  };

  return (
    <div className="min-h-screen bg-slate-50 flex flex-col items-center py-12 px-4 sm:px-6 lg:px-8">
      {/* Header Section */}
      <div className="text-center mb-12 animate-in fade-in slide-in-from-top-4 duration-700">
        <div className="flex justify-center mb-4">
          <div className="bg-primary p-3 rounded-2xl shadow-lg ring-4 ring-primary/10">
            <Globe className="h-10 w-10 text-white" />
          </div>
        </div>
        <h1 className="text-5xl font-extrabold text-slate-900 tracking-tight mb-3">
          Passtrip
        </h1>
        <p className="text-xl text-slate-600 max-w-2xl mx-auto font-medium">
          Be able to get information about your visa permissions
        </p>
      </div>

      <div className="w-full max-w-4xl space-y-8">
        {/* Selectors Card */}
        <Card className="border-none shadow-xl bg-white/80 backdrop-blur-md overflow-hidden">
          <div className="h-2 bg-gradient-to-r from-primary to-secondary" />
          <CardContent className="p-8">
            {loading ? (
              <div className="flex flex-col items-center justify-center py-12 space-y-4">
                <div className="w-12 h-12 border-4 border-primary border-t-transparent rounded-full animate-spin"></div>
                <p className="text-slate-500 font-medium italic">Discovering countries...</p>
              </div>
            ) : (
              <div className="grid grid-cols-1 md:grid-cols-[1fr,auto,1fr] gap-6 items-center">
                {/* Origin Select */}
                <div className="space-y-2">
                  <label className="text-sm font-semibold text-slate-700 flex items-center gap-2">
                    <PlaneTakeoff className="h-4 w-4 text-primary" />
                    Origin Country
                  </label>
                  <Select onValueChange={handleOriginChange} value={selectedOriginCountry}>
                    <SelectTrigger className="h-14 text-lg border-2 hover:border-primary/50 transition-all bg-white">
                      <SelectValue placeholder="Where are you from?" />
                    </SelectTrigger>
                    <SelectContent>
                      {countries.map((country) => (
                        <SelectItem key={country.ID} value={country.name.common}>
                          <span className="flex items-center gap-2">
                            <span className="text-xl">{country.flag}</span> {country.name.common}
                          </span>
                        </SelectItem>
                      ))}
                    </SelectContent>
                  </Select>
                </div>

                <div className="flex justify-center">
                  <div className="h-1 w-8 bg-slate-200 rounded-full md:h-8 md:w-1" />
                </div>

                {/* Destination Select */}
                <div className="space-y-2">
                  <label className="text-sm font-semibold text-slate-700 flex items-center gap-2">
                    <PlaneLanding className="h-4 w-4 text-secondary" />
                    Destination Country
                  </label>
                  <Select
                    onValueChange={handleDestinationChange}
                    value={selectedDestinationCountry}
                    disabled={!selectedOriginCountry}
                  >
                    <SelectTrigger className="h-14 text-lg border-2 hover:border-secondary/50 transition-all bg-white disabled:bg-slate-50">
                      <SelectValue placeholder={selectedOriginCountry ? "Where are you going?" : "Select origin first"} />
                    </SelectTrigger>
                    <SelectContent>
                      {countries.map((country) => (
                        <SelectItem key={country.ID} value={country.name.common}>
                          <span className="flex items-center gap-2">
                            <span className="text-xl">{country.flag}</span> {country.name.common}
                          </span>
                        </SelectItem>
                      ))}
                    </SelectContent>
                  </Select>
                </div>
              </div>
            )}
          </CardContent>
        </Card>

        {/* Details Section */}
        {countrySelected && (
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6 animate-in fade-in zoom-in-95 duration-500">
            {/* Country Info Card */}
            <Card className="col-span-1 md:col-span-2 lg:col-span-3 border-none shadow-lg bg-white">
              <CardHeader className="flex flex-row items-center justify-between pb-2">
                <div className="flex items-center gap-4">
                  <span className="text-6xl">{countrySelected.flag}</span>
                  <div>
                    <CardTitle className="text-3xl font-bold text-slate-900">{countrySelected.name.common}</CardTitle>
                    <CardDescription className="text-lg font-medium text-slate-500">{countrySelected.region}</CardDescription>
                  </div>
                </div>
                <div className="px-4 py-2 bg-secondary/10 text-secondary rounded-full font-bold text-sm">
                  DESTINATION
                </div>
              </CardHeader>
              <CardContent>
                <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6 mt-6">
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <MapPin className="h-5 w-5 text-primary mt-1" />
                    <div>
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Capital</p>
                      <p className="font-semibold text-slate-900">{countrySelected.capital?.[0] || 'N/A'}</p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <Users className="h-5 w-5 text-primary mt-1" />
                    <div>
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Population</p>
                      <p className="font-semibold text-slate-900">{countrySelected.population.toLocaleString()}</p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <Globe2 className="h-5 w-5 text-primary mt-1" />
                    <div>
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Area</p>
                      <p className="font-semibold text-slate-900">{countrySelected.area.toLocaleString()} km²</p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <Compass className="h-5 w-5 text-primary mt-1" />
                    <div>
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Timezone</p>
                      <p className="font-semibold text-slate-900">{countrySelected.timezones[0]}</p>
                    </div>
                  </div>
                </div>

                <div className="grid grid-cols-1 sm:grid-cols-2 gap-6 mt-6">
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <Languages className="h-5 w-5 text-primary mt-1" />
                    <div>
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Languages</p>
                      <p className="font-semibold text-slate-900">
                        {Array.isArray(countrySelected.languages) ? countrySelected.languages.join(', ') : 'N/A'}
                      </p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <Wallet className="h-5 w-5 text-primary mt-1" />
                    <div>
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Currency</p>
                      <p className="font-semibold text-slate-900">
                        {countrySelected.currencies.curr?.name} ({countrySelected.currencies.curr?.symbol})
                      </p>
                    </div>
                  </div>
                </div>
              </CardContent>
            </Card>
          </div>
        )}
      </div>

      {/* Footer info */}
      <div className="mt-auto pt-12 text-slate-400 text-sm font-medium">
        © 2026 Passtrip • Your Travel Companion
      </div>
    </div>
  );
}

export default App;
