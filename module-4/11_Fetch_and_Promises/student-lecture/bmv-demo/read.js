const idToView = getSelectedId();
if (!idToView) window.location = '/';

getRegistration(idToView).then(populateElementsFromObject);