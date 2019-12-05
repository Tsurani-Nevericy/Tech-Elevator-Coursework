const name = 'Cigar Parties for Dummies';
let description = 'Host and plan the perfect cigar party for all of your squirrelly friends.';
let reviews = [
  {
    reviewer: 'Malcolm Gladwell',
    title: 'What a book!',
    review:
      "It certainly is a book. I mean, I can see that. Pages kept together with glue (I hope that's glue) and there's writing on it, in some language.",
    rating: 3
  }
];

/**
 * Add our product name to the page title
 * Get our page page title by the id and the query the .name selector
 * once you have the element you can add the product name to the span.
 */
function setPageTitle() {
  const pageTitle = document.getElementById('page-title');
  pageTitle.querySelector('.name').innerHTML = name;
}

/**
 * Add our product description to the page.
 */
function setPageDescription() {
  document.querySelector('.description').innerHTML = description;
}

/**
 * I will display all of the reviews in the reviews array
 */
function displayReviews() {
  if ('content' in document.createElement('template')) {
    reviews.forEach((review) => {
      displayReview(review);
    });
  } else {
    console.error('Your browser does not support templates');
  }
}

/**
 *
 * @param {Object} review The review to display
 */
function displayReview(review) {
  const main = document.getElementById('main');
  const tmpl = document.getElementById('review-template').content.cloneNode(true);
  tmpl.querySelector('h4').innerHTML = review.reviewer;
  tmpl.querySelector('h3').innerHTML = review.title;
  tmpl.querySelector('p').innerHTML = review.review;
  // there will always be 1 star because it is a part of the template
  for (let i = 1; i < review.rating; ++i) {
    const img = tmpl.querySelector('img').cloneNode();
    tmpl.querySelector('.rating').appendChild(img);
  }
  main.appendChild(tmpl);
}

// LECTURE STARTS HERE ---------------------------------------------------------------
document.addEventListener('DOMContentLoaded', (event) => {

  // set the product reviews page title
  setPageTitle();
  // set the product reviews page description
  setPageDescription();
  // display all of the product reviews on our page
  displayReviews();

  //#main > p.description
  const description = document.getElementById('main').querySelector('p.description');
  description.addEventListener('click', (event) => {
    toggleDescriptionEdit(event.target);
  });

  const descInput = document.getElementById('inputDesc');
  descInput.addEventListener('keydown', (event) => {
    if(event.key === "Enter") {
      exitDescriptionEdit(event.target, true);
    }
    else if(event.key === "Esc" || event.key === "Escape") { 
      exitDescriptionEdit(event.target, false);
    }
  });

  const toggleForm = document.getElementById('btnToggleForm');
  toggleForm.addEventListener('click', showHideForm);

  const saveReviewBtn = document.getElementById('btnSaveReview');
  saveReviewBtn.addEventListener('click', saveReview);
});

/**
 * Take an event on the description and swap out the description for a text box.
 *
 * @param {EventTarget} desc the event object target
 */
function toggleDescriptionEdit(desc) {
  const textBox = desc.nextElementSibling;
  textBox.value = description;
  textBox.classList.remove('d-none');
  desc.classList.add('d-none');
  textBox.focus();
}

/**
 * Take an event on the text box and set the description to the contents
 * of the text box and then hide the text box and show the description.
 *
 * @param {Event} event the event object
 * @param {Boolean} save should we save the description text
 */
function exitDescriptionEdit(textBox, save) {
  let desc = textBox.previousElementSibling;
  if (save) {
    desc.innerText = textBox.value;
    description = desc.innerText;
  }
  textBox.classList.add('d-none');
  desc.classList.remove('d-none');
}

/**
 * I will show / hide the add review form
 */
function showHideForm() {
  const form = document.querySelector('form');
  const btn = document.getElementById('btnToggleForm');

  if (form.classList.contains('d-none')) {
    form.classList.remove('d-none');
    btn.innerText = 'Hide Form';
    document.getElementById('name').focus();
  } else {
    resetFormValues();
    form.classList.add('d-none');
    btn.innerText = 'Add Review';
  }
}

/**
 * I will reset all of the values in the form.
 */
function resetFormValues() {
  const form = document.querySelector('form');
  const inputs = form.querySelectorAll('input');
  inputs.forEach((input) => {
    input.value = '';
  });
  document.getElementById('rating').value = 1;
  document.getElementById('review').value = '';
}

/**
 * I will save the review that was added using the add review from
 */
function saveReview(event) {
  event.preventDefault();

  const review = {};
  review.reviewer = document.getElementById('name').value;
  review.title = document.getElementById('title').value;
  review.review = document.getElementById('review').value;
  review.rating = document.getElementById('rating').value;

  showHideForm();
  displayReview(review);

  // const toggleForm = document.getElementById('btnToggleForm');
  // toggleForm.removeEventListener('click', showHideForm);
}


// Just goofing off down here
// window.addEventListener('DOMContentLoaded', (event) => {
//   const body = document.querySelector('body');
//   body.addEventListener('contextmenu', saveReview);

//   const button = document.getElementById('btnToggleForm');
//   button.addEventListener('contextmenu', (event) => {
//     event.stopPropagation();
//     event.preventDefault();
//     alert("my button event")
//   });
// });