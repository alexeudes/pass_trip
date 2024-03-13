import React from 'react';
import './App.css';

function App() {
  return (
    <div className="container">
      <h1>Passport Trip</h1>
        <h4>Choose your passport and determine the type of VISA you'll need for your destination</h4>

        <div className="countries-select">
            <select id="originCountriesSelect"></select>
            <p>To</p>
            <select id="destinationCountriesSelect"></select>
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
    </div>
  );
}

export default App;
