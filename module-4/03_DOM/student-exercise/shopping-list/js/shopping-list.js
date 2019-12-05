const PageTitle = "My Shopping List";

const groceries = ["can", "i", "Gejt", "pizza", "wings", "orieos", "pizza", "breadsti", "ks", "plsz"];

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  let docTitle = document.getElementById('title');
  docTitle.innerText = PageTitle;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
  groceries.forEach(element => {
    let newListItem = document.createElement('li');
    newListItem.innerText = element;
    document.getElementById('groceries').appendChild(newListItem);
  });
}

/**
 * This function will be called when the button is clicked. You will need to get a reference
 * to every list item and add the class completed to each one
 */
function markCompleted() {
  let GroceryElement = document.getElementById('groceries');
  let myGroceries = GroceryElement.children;
  for (let i = 0; i < myGroceries.length; i++) {
    let grocery = myGroceries[i];
    grocery.classList.add('completed');
  }
}

setPageTitle();

displayGroceries();

// Don't worry too much about what is going on here, we will cover this when we discuss events.
document.addEventListener('DOMContentLoaded', () => {
  // When the DOM Content has loaded attach a click listener to the button
  const button = document.querySelector('.btn');
  button.addEventListener('click', markCompleted);
});
