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

  const handleSelectOriginCountryChange = (event: any) => {
    if (event !== null) {
      setSelectedOriginCountry(event.target.value);
      setDestinationCountryDisabledSelect(false);
    }
  }

  const handleSelectDestinationCountryChange = (event: any) => {
    setSelectedDestinationCountry(event.target.value);
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
                      {country.name?.common} - {country.flag}
                    </option>
                  ))}
                </select>
                <p>To</p>
                <select value={selectedDestinationCountry} onChange={handleSelectDestinationCountryChange}
                  disabled={destinationCountryDisabledSelect}>
                  <option value="">Select your destination country</option>
                  {countries.map((country, index) => (
                    <option key={index} value={country.name.common}>
                      {country.name?.common} - {country.flag}
                    </option>
                  ))}
                </select>
              </div>

              <div className="visa-details">
                <div className="divider">
                  <div className="line"></div>
                </div>

                <label>Country: </label>
                <label>Capital: </label>
                <label>Region: </label>
                <label>Flag: </label>
                <label>Language(s): </label>
                <label>Area: </label>
                <label>Population: </label>
                <label>Timezone(s): </label>
                <label>Currencies: </label>
              </div>
            </pre>
          )

        )


      }

    </div>
  );
}

export default App;
