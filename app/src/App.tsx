import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { IVisaResponse } from './interfaces/IVisaResponse';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "./components/ui/select";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "./components/ui/card";
import { Globe, PlaneTakeoff, PlaneLanding, MapPin, Users, Globe2, Compass, AlertCircle, Info, Clock, ChevronDown, ChevronUp, Car, Mail, Calendar } from 'lucide-react';

const API_BASE_URL = 'https://localhost:7109';

function App() {
  const [countryNames, setCountryNames] = useState<string[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [selectedOriginCountry, setSelectedOriginCountry] = useState<string>("");
  const [selectedDestinationCountry, setSelectedDestinationCountry] = useState<string>("");
  const [visaInfo, setVisaInfo] = useState<IVisaResponse | null>(null);
  const [detailsLoading, setDetailsLoading] = useState(false);
  const [isTimezonesExpanded, setIsTimezonesExpanded] = useState(false);

  useEffect(() => {
    const fetchCountryNames = async () => {
      try {
        setLoading(true);
        const response = await axios.get(`${API_BASE_URL}/Passport`);
        const data: string[] = response.data.originCountries;
        const sortedData = [...data].sort((a, b) => a.localeCompare(b));
        setCountryNames(sortedData);
        setLoading(false);
      } catch (err) {
        console.error('Error fetching country names:', err);
        setError('Failed to load countries. Please make sure the back-end is running.');
        setLoading(false);
      }
    };

    fetchCountryNames();
  }, []);

  useEffect(() => {
    const fetchVisaDetails = async () => {
      if (selectedOriginCountry && selectedDestinationCountry) {
        setDetailsLoading(true);
        try {
          const response = await axios.get(`${API_BASE_URL}/VisaRequirements`, {
            params: {
              originCountry: selectedOriginCountry,
              destCountry: selectedDestinationCountry
            }
          });
          setVisaInfo(response.data);
        } catch (err) {
          console.error('Error fetching visa details:', err);
          setError('Failed to retrieve visa requirements.');
        } finally {
          setDetailsLoading(false);
        }
      }
    };

    fetchVisaDetails();
  }, [selectedOriginCountry, selectedDestinationCountry]);

  const handleOriginChange = (value: string) => {
    setSelectedOriginCountry(value);
    setSelectedDestinationCountry("");
    setVisaInfo(null);
    setIsTimezonesExpanded(false);
  };

  const handleDestinationChange = (value: string) => {
    setSelectedDestinationCountry(value);
    setIsTimezonesExpanded(false);
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
        {/* Error State */}
        {error && (
          <div className="bg-destructive/10 border border-destructive/20 text-destructive px-4 py-3 rounded-xl flex items-center gap-3 animate-in fade-in zoom-in-95">
            <AlertCircle className="h-5 w-5" />
            <p className="font-medium">{error}</p>
          </div>
        )}

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
                      {countryNames.map((name, index) => (
                        <SelectItem key={`${name}-${index}`} value={name}>
                          {name}
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
                      {countryNames.map((name, index) => (
                        <SelectItem key={`dest-${name}-${index}`} value={name}>
                          {name}
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
        {detailsLoading ? (
          <div className="flex justify-center py-12">
            <div className="w-8 h-8 border-4 border-secondary border-t-transparent rounded-full animate-spin"></div>
          </div>
        ) : visaInfo && (
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6 animate-in fade-in zoom-in-95 duration-500">
            {/* Visa Requirement Card */}
            <Card className="col-span-1 md:col-span-2 lg:col-span-3 border-none shadow-lg bg-white overflow-hidden">
              <div className="bg-primary/5 p-6 border-b border-primary/10 flex items-center justify-between">
                <div className="flex items-center gap-4">
                  <div className="bg-primary/10 p-3 rounded-xl">
                    <Info className="h-6 w-6 text-primary" />
                  </div>
                  <div>
                    <h3 className="text-sm font-bold text-primary uppercase tracking-wider">Visa Requirement</h3>
                    <p className="text-2xl font-extrabold text-slate-900">{visaInfo.visa.description}</p>
                  </div>
                </div>
                {visaInfo.visa.numberOfDays && (
                  <div className="flex flex-col items-end">
                    <span className="text-xs font-bold text-slate-500 uppercase">Duration</span>
                    <div className="flex items-center gap-2 text-primary font-bold">
                      <Clock className="h-4 w-4" />
                      <span>{visaInfo.visa.numberOfDays} days</span>
                    </div>
                  </div>
                )}
              </div>
            </Card>

            {/* Country Info Card */}
            <Card className="col-span-1 md:col-span-2 lg:col-span-3 border-none shadow-lg bg-white">
              <CardHeader className="flex flex-row items-center justify-between pb-2">
                <div className="flex items-center gap-4">
                  <img
                    src={visaInfo.country.flags.svg}
                    alt={`${visaInfo.country.name} flag`}
                    className="w-20 h-auto rounded shadow-sm border border-slate-100"
                  />
                  <div>
                    <CardTitle className="text-3xl font-bold text-slate-900">{visaInfo.country.name}</CardTitle>
                    <CardDescription className="text-lg font-medium text-slate-500">
                      {visaInfo.country.region} - {visaInfo.country.subregion}
                    </CardDescription>
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
                      <p className="font-semibold text-slate-900">{visaInfo.country.capitals?.[0] || 'N/A'}</p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <Users className="h-5 w-5 text-primary mt-1" />
                    <div>
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Population</p>
                      <p className="font-semibold text-slate-900">{visaInfo.country.population?.toLocaleString() || '0'}</p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <Globe2 className="h-5 w-5 text-primary mt-1" />
                    <div>
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Area</p>
                      <p className="font-semibold text-slate-900">{visaInfo.country.area?.toLocaleString() || '0'} km²</p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <Compass className="h-5 w-5 text-primary mt-1" />
                    <div className="flex-1 min-w-0">
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Timezone</p>
                      <div className="mt-1">
                        {visaInfo.country.timezones && visaInfo.country.timezones.length > 0 ? (
                          <div className="flex flex-col gap-1">
                            <p className="font-semibold text-slate-900 truncate">
                              {visaInfo.country.timezones[0]}
                            </p>
                            {visaInfo.country.timezones.length > 1 && (
                              <button
                                onClick={() => setIsTimezonesExpanded(!isTimezonesExpanded)}
                                className="text-xs font-bold text-primary hover:text-primary/80 flex items-center gap-1 transition-colors mt-1"
                              >
                                {isTimezonesExpanded ? (
                                  <>Show less <ChevronUp className="h-3 w-3" /></>
                                ) : (
                                  <>+{visaInfo.country.timezones.length - 1} more timezones <ChevronDown className="h-3 w-3" /></>
                                )}
                              </button>
                            )}
                            {isTimezonesExpanded && (
                              <div className="flex flex-col gap-1 mt-1 animate-in slide-in-from-top-1 duration-200">
                                {visaInfo.country.timezones.slice(1).map((tz, idx) => (
                                  <p key={idx} className="font-medium text-sm text-slate-600 border-l-2 border-primary/20 pl-2">
                                    {tz}
                                  </p>
                                ))}
                              </div>
                            )}
                          </div>
                        ) : (
                          <p className="font-semibold text-slate-900">N/A</p>
                        )}
                      </div>
                    </div>
                  </div>
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <Car className="h-5 w-5 text-primary mt-1" />
                    <div>
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Driving Side</p>
                      <p className="font-semibold text-slate-900 capitalize">{visaInfo.country.carSide || 'N/A'}</p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <Mail className="h-5 w-5 text-primary mt-1" />
                    <div>
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Postal Format</p>
                      <p className="font-semibold text-slate-900">{visaInfo.country.postalCodeFormat || 'N/A'}</p>
                    </div>
                  </div>
                  <div className="flex items-start gap-3 p-4 rounded-xl bg-slate-50">
                    <Calendar className="h-5 w-5 text-primary mt-1" />
                    <div>
                      <p className="text-xs font-bold text-slate-500 uppercase tracking-wider">Start of Week</p>
                      <p className="font-semibold text-slate-900 capitalize">{visaInfo.country.startOfWeek || 'N/A'}</p>
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

