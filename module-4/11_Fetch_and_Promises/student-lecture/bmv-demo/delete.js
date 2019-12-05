const idToRemove = getSelectedId();
if (!idToRemove) window.location = '/';

getRegistration(idToRemove).then(populateElementsFromObject);

document.getElementById('deleteButton').addEventListener('click', () => {
    deleteRegistration(idToRemove)
        .catch((err) => {
            document.getElementById('errorMessage').innerText = err.message;
        });
});

