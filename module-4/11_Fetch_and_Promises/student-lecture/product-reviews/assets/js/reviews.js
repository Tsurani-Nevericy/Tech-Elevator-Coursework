// write code (loadReviews)
// select the object with the event (Load Reviews Button)
// link event with object using (AddEventListener)
document.querySelector('#container > header > button')
        .addEventListener('click', loadReviews);

function loadReviews() {
   fetch('data.json')
  .then((response)=>{
    if(response.ok) {
      return response.json();
    }
    else {
      console.log("Could not connect to server.")
    }
  })
  .then((data)=>{
    displayReviews(data);
  })
  .catch((err)=>{
    console.log(err);
  });
}

function catFacts() {
  
  const proxyUrl = 'https://cors-anywhere.herokuapp.com/';
  const targetUrl = 'https://cat-fact.herokuapp.com/facts';

  fetch(proxyUrl + targetUrl)
  .then((response)=>{
    if(response.ok) {
      return response.json();
    }
    else {
      console.log("Could not connect to server.")
    }
  })
  .then((data)=>{
    console.log(data);
    const reviews = createReviewsFromCatFacts(data.all);
    displayReviews(reviews);
  })
  .catch((err)=>{
    console.log(err);
  });
}

function createReviewsFromCatFacts(facts)
{
  const reviews = facts.map((fact)=>{
    let review = {};
    if(fact.user && fact.user.name) {
      review.username = `${fact.user.name.first} ${fact.user.name.last}`;
    }
    else {
      review.username = `unknown`;
    }
    review.review = `${fact.text}`;
    review.title = `${fact.type}`;
    review.publishedOn = Date.now;
    review.avatar = `assets/img/user-1.png`;
    return review;
  });
  
  return reviews;
}

/**
 * This function when invoked will look at an array of reviews
 * and add it to the page by cloning the #review-template
 */
function displayReviews(reviews) {
    console.log("Display Reviews...");
  
    // first check to make sure the browser supports content templates
    if('content' in document.createElement('template')) {
      // query the document for .reviews and assign it to a variable called container
      const container = document.querySelector(".reviews");
      // loop over the reviews array
      reviews.forEach((review) => {
        // get the template; find all the elements and add the data from our review to each element
        const tmpl = document.getElementById('review-template').content.cloneNode(true);
        tmpl.querySelector('img').setAttribute("src",review.avatar);
        tmpl.querySelector('.username').innerText = review.username;
        tmpl.querySelector('h2').innerText = review.title;
        tmpl.querySelector('.published-date').innerText = review.publishedOn;
        tmpl.querySelector('.user-review').innerText = review.review;
        container.appendChild(tmpl);
      });
    } else {
      console.error('Your browser does not support templates');
    }
}