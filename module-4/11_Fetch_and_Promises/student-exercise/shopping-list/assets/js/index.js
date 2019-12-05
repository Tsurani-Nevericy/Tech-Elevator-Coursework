let shoppingList = [];
let ListLoaded = false;

function loadGroceries() {
  console.log("Load Reviews...");

  fetch('assets/data/shopping-list.json') 
    .then((response) => {
      return response.json();
    })
    .then((data) => {
        shoppingList = data;
        displayGroceries();
    })
    .catch((err) => console.error(err));
}

function markComplete(){
    let myElement = event.currentTarget;
    let myBox = myElement.querySelector('i');
    if (!myBox.classList.contains('completed')){
      myBox.classList.add('completed');
      //myElement.classList.add('completed');
    }
  }
  
  function markIncomplete(){
    let myElement = event.currentTarget;
    let myBox = myElement.querySelector('i');
    if (myBox.classList.contains('completed')){
      myBox.classList.remove('completed');
      //myElement.classList.remove('completed');
    }
  }

function displayGroceries() {
    if (ListLoaded == false){
        const ul = document.querySelector('ul');
        shoppingList.forEach((item) => {
          const li = document.createElement('li');
          li.innerText = item.name;
          const checkCircle = document.createElement('i');
          checkCircle.setAttribute('class', 'far fa-check-circle');
          li.addEventListener('click', markComplete);
          li.addEventListener('dblclick', markIncomplete);
          if (item.completed){
              checkCircle.classList.add('completed');
              //li.classList.add('completed');
          }
          li.appendChild(checkCircle);
          ul.appendChild(li);
        });
        ListLoaded=true;
    }
}

document.addEventListener('DOMContentLoaded', () => {
    let loadButton = document.getElementsByClassName('loadingButton');
    loadButton = loadButton[0];
    loadButton.addEventListener('click', loadGroceries);
});

//loadGroceries();