
const countriesUri = "/Countries/";

const countries = [{ id: 1, name: 'Brazil' }];
const originCountriesSelect = document.getElementById('originCountriesSelect');
const destinationCountriesSelect = document.getElementById('destinationCountriesSelect');

function getCountries() {
    fetch(countriesUri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get items', error));
}

function _displayItems(data) {
    // Default origin option
    var defaultOriginOption = document.createElement('option');
    defaultOriginOption.value = '';
    defaultOriginOption.text = 'Choose your country of origin';
    originCountriesSelect.add(defaultOriginOption);

    // Default destination option
    var defaultDestinationOption = document.createElement('option');
    defaultDestinationOption.value = '';
    defaultDestinationOption.text = 'Select your destination country';
    destinationCountriesSelect.add(defaultDestinationOption);

    data.forEach(item => {
        let option = document.createElement('option');
        option.value = item.id;
        option.text = `${item.name.common} - ${item.flag}`;
        originCountriesSelect.add(option);
    });

    countries.forEach(item => {
        let option = document.createElement('option');
        option.value = item.id;
        option.text = `${item.name}`;
        destinationCountriesSelect.add(option);
    });
}