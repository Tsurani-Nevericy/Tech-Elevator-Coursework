const idToModify = getSelectedId();
if (!idToModify) window.location = '/';

let originalReg;
getRegistration(idToModify).then(reg => {
    originalReg = reg;
    populateElementsFromObject(reg);
});


document.querySelector('form').addEventListener('submit', (e) => {
    e.preventDefault();

    let errorMessage = document.getElementById('errorMessage');
    errorMessage.innerText = '';

    const formData = new FormData(e.target);
    const updatedReg = makeRegFromForm(formData);

    //Fills in missing values and adds id.
    for (key of Object.keys(originalReg)) {
        if (!updatedReg[key]) {
            updatedReg[key] = originalReg[key];
        }
    }

    if (updatedReg.complete()) {
        putRegistration(updatedReg)
            .catch(err => {
                errorMessage.innerText = err.message;
            })
    }
    else {
        errorMessage.innerText = 'All fields are required.';
    }

});