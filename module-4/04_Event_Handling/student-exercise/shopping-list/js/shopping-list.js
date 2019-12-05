let allItemsIncomplete = true;
const pageTitle = 'My Shopping List';
const markAllComplete = 'Mark All Incomplete';
const markAllIncomplete = 'Mark All Complete';
const groceries = [
  { id: 1, name: 'Oatmeal', completed: false },
  { id: 2, name: 'Milk', completed: false },
  { id: 3, name: 'Banana', completed: false },
  { id: 4, name: 'Strawberries', completed: false },
  { id: 5, name: 'Lunch Meat', completed: false },
  { id: 6, name: 'Bread', completed: false },
  { id: 7, name: 'Grapes', completed: false },
  { id: 8, name: 'Steak', completed: false },
  { id: 9, name: 'Salad', completed: false },
  { id: 10, name: 'Tea', completed: false }
];

/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  const title = document.getElementById('title');
  title.innerText = pageTitle;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
  const ul = document.querySelector('ul');
  groceries.forEach((item) => {
    const li = document.createElement('li');
    li.innerText = item.name;
    const checkCircle = document.createElement('i');
    checkCircle.setAttribute('class', 'far fa-check-circle');
    li.appendChild(checkCircle);
    li.addEventListener('click', markComplete);
    li.addEventListener('dblclick', markIncomplete);
    ul.appendChild(li);
  });
}

function markComplete(){
  let myElement = event.currentTarget;
  if (!myElement.classList.contains('completed')){
    myElement.classList.add('completed');
  }
}

function markIncomplete(){
  let myElement = event.currentTarget;
  if (myElement.classList.contains('completed')){
  myElement.classList.remove('completed');
  }
}
function toggleList (){
  
  let groceryElement = document.getElementsByTagName('ul');
  let markAllButton = document.getElementById('toggleAll');
  groceryElement = groceryElement[0];
  let myGroceries = groceryElement.children;
  if (allItemsIncomplete) {
    for (let i = 0; i < myGroceries.length; i++){
      let grocery = myGroceries[i];
      if (!grocery.classList.contains('completed')){
        grocery.classList.add('completed');
      }
      markAllButton.innerText=markAllComplete;
    }
  }
  else {
    for (let i = 0; i < myGroceries.length; i++){
      let grocery = myGroceries[i];
      if (grocery.classList.contains('completed')){
        grocery.classList.remove('completed');
      }
      markAllButton.innerText=markAllIncomplete;
    }
  }  
  allItemsIncomplete = !allItemsIncomplete;
}

document.addEventListener('DOMContentLoaded', () => {

  let markAllButton = document.getElementById('toggleAll');
  markAllButton.addEventListener('click', toggleList);
});

setPageTitle();
displayGroceries();