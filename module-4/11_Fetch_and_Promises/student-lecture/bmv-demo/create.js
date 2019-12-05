document.querySelector('form').addEventListener('submit', (e) => {
    e.preventDefault();

    let errorMessage = document.getElementById('errorMessage');
    errorMessage.innerText = '';

    const formData = new FormData(e.target);
    const newReg = makeRegFromForm(formData);
    if (newReg.complete()) {
        postRegistration(newReg)
            .catch(err => {
                errorMessage.innerText = err.message;
            })
    }
    else {
        errorMessage.innerText = 'All fields are required.';
    }

});