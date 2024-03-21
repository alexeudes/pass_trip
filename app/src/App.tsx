import React, { useState, useEffect } from 'react';
import './App.css';
import { ICountry } from './interfaces/ICountry'
import { IPassport } from './interfaces/IPassport';

function App() {
  const [countries, setCountries] = useState<ICountry[]>([]);
  //const [passport, setPassport]: IPassport = useState({});
  const [loading, setLoading] = useState(true);
  const [selectedOriginCountry, setSelectedOriginCountry] = useState('');
  const [selectedDestinationCountry, setSelectedDestinationCountry] = useState('');
  const [destinationCountryDisabledSelect, setDestinationCountryDisabledSelect] = useState(true);
  const [countrySelected, setCountrySelected] = useState<ICountry>(
    {ID: 0,
    name: { common: "" },
    capital: [],
    region: "",
    flag: "",
    languages: [],
    area: 0,
    population: 0,
    timezones: [],
    currencies: { curr: { name: "", symbol: "" }}
  } as ICountry);

  const handleSelectOriginCountryChange = (event: any) => {
    if (event !== null) {
      setSelectedOriginCountry(event.target.value);
      setDestinationCountryDisabledSelect(false);
    }
  }

  const handleSelectDestinationCountryChange = (event: any) => {
    if (event !== null && event !== "") {
      setSelectedDestinationCountry(event.target.value);
      const countrySelectedIndex: number = countries.findIndex(c => c.name.common === event.target.value);
      setCountrySelected(countries[countrySelectedIndex]);
    }
  }

  useEffect(() => {
    const fetchCountries = () => {
      try {
        fetch('https://localhost:7109/countries/')
          .then(response => response.json())
          .then(data => {
            setLoading(false);
            setCountries(data);
          });
      } catch (error) {
        console.error('Error fetching data:', error);
        setLoading(false);
      }
    };

    fetchCountries();
  }, []);

  return (
    <div className="container">
      <h1>Passport Trip</h1>
      <h4>Choose your passport and determine the type of VISA you'll need for your destination</h4>

      {
        loading ? (
          <p>Loading...</p>
        ) : (countries.sort((a, b) =>
          a.name.common.localeCompare(b.name.common)) && (
            <pre>
              <div className="countries-select">
                <select value={selectedOriginCountry} onChange={handleSelectOriginCountryChange}>
                  <option value="">Select your country of origin</option>
                  {countries.map((country, index) => (
                    <option key={index} value={country.name.common}>
                      {country.name.common} - {country.flag}
                    </option>
                  ))}
                </select>
                <p>To</p>
                <select value={selectedDestinationCountry} onChange={handleSelectDestinationCountryChange}
                  disabled={destinationCountryDisabledSelect}>
                  <option value="">Select your destination country</option>
                  {countries.map((country, index) => (
                    <option key={index} value={country.name.common}>
                      {country.name.common} - {country.flag}
                    </option>
                  ))}
                </select>
              </div>

              <div className="visa-details">
                <div className="divider">
                  <div className="line"></div>
                </div>

                <label>Country: {countrySelected.name && countrySelected.name.common}</label>
                <label>Capital: {countrySelected.capital}</label>
                <label>Region: {countrySelected.region}</label>
                <label>Flag: {countrySelected.flag}</label>
                <label>Language(s): {countrySelected.languages}</label>
                <label>Area: {countrySelected.area}</label>
                <label>Population: {countrySelected.population}</label>
                <label>Timezone(s): {countrySelected.timezones}</label>
                <label>Currencies: {countrySelected.currencies.curr && countrySelected.currencies.curr.name} - {countrySelected.currencies.curr && countrySelected.currencies.curr.symbol}</label>
              </div>
            </pre>
          )
        )
      }

    </div>
  );
}

export default App;
