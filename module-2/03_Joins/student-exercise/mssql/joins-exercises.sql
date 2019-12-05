-- The following queries utilize the "dvdstore" database.

-- 1. All of the films that Nick Stallone has appeared in
-- (30 rows)
select f.film_id, f.title
from film as f
join film_actor as fa on f.film_id = fa.film_id
join actor as actor on fa.actor_id = actor.actor_id
where actor.first_name + ' ' + actor.last_name = 'Nick Stallone';

-- 2. All of the films that Rita Reynolds has appeared in
-- (20 rows)
select f.film_id, f.title
from film as f
join film_actor as fa on f.film_id = fa.film_id
join actor as actor on fa.actor_id = actor.actor_id
where actor.first_name + ' ' + actor.last_name = 'Rita Reynolds';

-- 3. All of the films that Judy Dean or River Dean have appeared in
-- (46 rows)
select f.film_id, f.title
from film as f
join film_actor as fa on f.film_id = fa.film_id
join actor as actor on fa.actor_id = actor.actor_id
where actor.first_name + ' ' + actor.last_name = 'Judy Dean' or
actor.first_name + ' ' + actor.last_name = 'River Dean';

-- 4. All of the the ‘Documentary’ films
-- (68 rows)
select f.film_id, f.title, cat.name
from film as f
join film_category as fc on f.film_id = fc.film_id
join category as cat on fc.category_id = cat.category_id
where cat.name = 'Documentary';

-- 5. All of the ‘Comedy’ films
-- (58 rows)
select f.film_id, f.title, cat.name
from film as f
join film_category as fc on f.film_id = fc.film_id
join category as cat on fc.category_id = cat.category_id
where cat.name = 'Comedy';

-- 6. All of the ‘Children’ films that are rated ‘G’
-- (10 rows)
select f.film_id, f.title, cat.name, f.rating
from film as f
join film_category as fc on f.film_id = fc.film_id
join category as cat on fc.category_id = cat.category_id
where cat.name = 'Children' and f.rating = 'G';

-- 7. All of the ‘Family’ films that are rated ‘G’ and are less than 2 hours in length
-- (3 rows)
select f.film_id, f.title, cat.name, f.rating, f.length
from film as f
join film_category as fc on f.film_id = fc.film_id
join category as cat on fc.category_id = cat.category_id
where cat.name = 'Family' and f.rating = 'G' and f.length < 120;


-- 8. All of the films featuring actor Matthew Leigh that are rated ‘G’
-- (9 rows)
select f.film_id, f.title, f.rating
from film as f
join film_actor as fa on f.film_id = fa.film_id
join actor as actor on fa.actor_id = actor.actor_id
where actor.first_name + ' ' + actor.last_name = 'Matthew Leigh' and f.rating = 'G';

-- 9. All of the ‘Sci-Fi’ films released in 2006
-- (61 rows)
select f.film_id, f.title, f.release_year
from film as f
join film_category as fc on f.film_id = fc.film_id
join category as cat on fc.category_id = cat.category_id
where cat.name = 'Sci-Fi' and f.release_year = 2006;

-- 10. All of the ‘Action’ films starring Nick Stallone
-- (2 rows)
select f.film_id, f.title, cat.name
from film as f
join film_actor as fa on f.film_id = fa.film_id
join actor as actor on fa.actor_id = actor.actor_id
join film_category as fc on f.film_id = fc.film_id
join category as cat on fc.category_id = cat.category_id
where actor.first_name + ' ' + actor.last_name = 'Nick Stallone' and cat.name = 'Action';

-- 11. The address of all stores, including street address, city, district, and country
-- (2 rows)
select ad.address, cit.city, ad.district, c.country
from address as ad
join city as cit on ad.city_id = cit.city_id
join country as c on cit.country_id = c.country_id
join store as s on ad.address_id = s.address_id;

-- 12. A list of all stores by ID, the store’s street address, and the name of the store’s manager
-- (2 rows)
select s.store_id, ad.address, st.first_name+' '+st.last_name as manager_name
from store as s
join address as ad on ad.address_id = s.address_id
join staff as st on s.manager_staff_id = st.staff_id;


-- 13. The first and last name of the top ten customers ranked by number of rentals 
-- (#1 should be “ELEANOR HUNT” with 46 rentals, #10 should have 39 rentals)
select top 10 c.first_name + ' ' + c.last_name as customer_name, COUNT(*) as rental_count
from customer as c
join rental as r on c.customer_id = r.customer_id
group by c.customer_id, c.first_name, c.last_name
order by rental_count desc;

-- 14. The first and last name of the top ten customers ranked by dollars spent 
-- (#1 should be “KARL SEAL” with 221.55 spent, #10 should be “ANA BRADLEY” with 174.66 spent)
select top 10 SUM(p.amount) as total_spent, cust.first_name+' '+cust.last_name as customer_name
from customer as cust
join payment as p on cust.customer_id = p.customer_id
group by cust.customer_id, cust.first_name, cust.last_name
order by total_spent desc;

-- 15. The store ID, street address, total number of rentals, total amount of sales (i.e. payments), and average sale of each store 
-- (Store 1 has 7928 total rentals and Store 2 has 8121 total rentals)
select st.store_id, ad.address, count(r.rental_id) as rentals, sum(p.amount) as total_sales, avg(p.amount) as avg_cost
from store as st
join address as ad on st.address_id = ad.address_id
join inventory as i on st.store_id = i.store_id
join rental as r on i.inventory_id = r.inventory_id
join payment as p on r.rental_id = p.rental_id
group by i.store_id, ad.address, st.store_id
order by i.store_id;

-- 16. The top ten film titles by number of rentals
-- (#1 should be “BUCKET BROTHERHOOD” with 34 rentals and #10 should have 31 rentals)
select top 10 f.title, count(r.rental_id) as rentals
from film as f
join inventory as i on f.film_id = i.film_id
join rental as r on i.inventory_id = r.inventory_id
group by f.title
order by rentals desc;

-- 17. The top five film categories by number of rentals 
-- (#1 should be “Sports” with 1179 rentals and #5 should be “Family” with 1096 rentals)
select top 5 cat.name, count(r.rental_id) as rentals
from film as f
join film_category as fc on f.film_id = fc.film_id
join category as cat on fc.category_id = cat.category_id
join inventory as i on f.film_id = i.film_id
join rental as r on i.inventory_id = r.inventory_id
group by cat.name
order by rentals desc;

-- 18. The top five Action film titles by number of rentals 
-- (#1 should have 30 rentals and #5 should have 28 rentals)
select top 5 f.title, count(r.rental_id) as rentals
from film as f
join film_category as fc on f.film_id = fc.film_id
join category as cat on fc.category_id = cat.category_id
join inventory as i on f.film_id = i.film_id
join rental as r on i.inventory_id = r.inventory_id
where cat.name = 'Action'
group by f.title
order by rentals desc;

-- 19. The top 10 actors ranked by number of rentals of films starring that actor 
-- (#1 should be “GINA DEGENERES” with 753 rentals and #10 should be “SEAN GUINESS” with 599 rentals)
select top 10 actor.first_name+' '+actor.last_name as actor_name, count(r.rental_id) as rentals
from film as f
join film_actor as fa on f.film_id = fa.film_id
join actor as actor on fa.actor_id = actor.actor_id
join inventory as i on f.film_id = i.film_id
join rental as r on i.inventory_id = r.inventory_id
group by actor.actor_id, actor.first_name, actor.last_name
order by rentals desc;

-- 20. The top 5 “Comedy” actors ranked by number of rentals of films in the “Comedy” category starring that actor 
-- (#1 should have 87 rentals and #5 should have 72 rentals)
select top 5 actor.first_name+' '+actor.last_name as actor_name, count(r.rental_id) as rentals
from film as f
join film_actor as fa on f.film_id = fa.film_id
join film_category as fc on f.film_id = fc.film_id
join category as cat on fc.category_id = cat.category_id
join actor as actor on fa.actor_id = actor.actor_id
join inventory as i on f.film_id = i.film_id
join rental as r on i.inventory_id = r.inventory_id
where cat.name = 'Comedy'
group by actor.actor_id, actor.first_name, actor.last_name
order by rentals desc;
