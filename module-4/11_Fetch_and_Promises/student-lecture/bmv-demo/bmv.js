const API_URL = 'https://5dd0398ed5f1a500149a84b0.mockapi.io/registration/';

function getSelectedId() {
    return new URLSearchParams(window.location.search).get('id');
}

function makeRegFromForm(formData) {
    return {
        plate: formData.get('plate'),
        owner: formData.get('owner'),
        make: formData.get('make'),
        model: formData.get('model'),
        year: Number(formData.get('year')),
        complete() {
            return this.plate && this.owner && this.make && this.model && this.year;
        }
    };
}

function populateElementsFromObject(obj) {
    for (key of Object.keys(obj)) {
        const element = document.getElementById(key);
        if (element != null) element.innerText = obj[key];
    }
}

function getRegistration(selectedId) {
    return fetch(API_URL + selectedId)
        .then((response) => {
            if (response.ok) {
                return response.json();
            }
            else {
                throw new Error('Error communicating with server.');
            }
        })
        .catch((err) => {
            window.location = '/';
        });
}

function postRegistration(reg) {
    return fetch(API_URL, {
        method: 'POST',
        body: JSON.stringify(reg),
        headers: { 'Content-Type': 'application/json' }
    })
        .then((response) => {
            if (response.ok) {
                return response.json();
            }
            else {
                throw new Error('Error communicating with server.');
            }
        }).then((data) => {
            window.location = '/read.html?id=' + data.id;
        });
}

function deleteRegistration(selectedId) {
    return fetch(API_URL + selectedId, {
        method: 'DELETE'
    })
        .then((response) => {
            if (response.ok) {
                window.location = '/';
            }
            else {
                throw new Error('Error communicating with server.')
            }
        });
}

function putRegistration(reg) {
    return fetch(API_URL + reg.id, {
        method: 'PUT',
        body: JSON.stringify(reg),
        headers: { 'Content-Type': 'application/json' }
    })
        .then((response) => {
            if (response.ok) {
                return response.json();
            }
            else {
                throw new Error('Error communicating with server.');
            }
        })
        .then((data) => {
            window.location = '/read.html?id=' + data.id;
        });
}