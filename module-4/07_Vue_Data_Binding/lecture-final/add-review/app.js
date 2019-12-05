// v1 showing the results when the save button is clicked

// document.addEventListener('DOMContentLoaded',() => {
//     const button = document.getElementById('btnSave');
//     button.addEventListener('click', addReview);
// });

// function addReview(event) {
//     event.preventDefault();

//     const title = document.getElementById('title');
//     const reviewer = document.getElementById('reviewer');
//     const rating = document.getElementById('rating');
//     const review = document.getElementById('review');

//     // submission results
//     const titleResult = document.querySelector('.titleResult');
//     const reviewerResult = document.querySelector('.reviewerResult');
//     const ratingResult = document.querySelector('.ratingResult');
//     const reviewResult = document.querySelector('.reviewResult');
    
//     titleResult.innerText = title.value;
//     reviewerResult.innerText = reviewer.value;
//     ratingResult.innerText = rating.value;
//     reviewResult.innerText = review.value;
// }

document.addEventListener('DOMContentLoaded',() => {
    const button = document.getElementById('btnSave');

    const title = document.getElementById('title');
    const reviewer = document.getElementById('reviewer');
    const rating = document.getElementById('rating');
    const review = document.getElementById('review');

    // submission results
    const titleResult = document.querySelector('.titleResult');
    const reviewerResult = document.querySelector('.reviewerResult');
    const ratingResult = document.querySelector('.ratingResult');
    const reviewResult = document.querySelector('.reviewResult');

    title.addEventListener('keydown', function(event) {
        titleResult.innerHTML = event.target.value;
    });
    reviewer.addEventListener('keydown', function(event) {
        reviewerResult.innerHTML = event.target.value;
    });
    rating.addEventListener('change', function(event) {
        ratingResult.innerHTML = event.target.value;
    });
    review.addEventListener('keydown', function(event) {
        reviewResult.innerHTML = event.target.value;
    });

});

