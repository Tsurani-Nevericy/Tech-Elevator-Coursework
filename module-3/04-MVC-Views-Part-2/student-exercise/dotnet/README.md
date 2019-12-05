# MVC Views - Part 2

The purpose of this exercise is to provide you the opportunity to practice using complex data that is provided from a "controller" in your views. Additionally, you will gain a better understanding of how data can be passed through query string parameters by creating links.

## Learning Objectives

After completing this exercise, students will understand:

- How to effectively present complex model data on a view.
- How to use Razor conditional statements (if/else) to show/hide HTML and CSS classes on views.
- How to use Razor loops to generate HTML dynamically.
- How to create routes that will dynamically update views.

## Evaluation Criteria & Functional Requirements

- The project must not have any build errors.
- Code is presented in a clean, organized format.
- The code meets the specifications defined below.

Often when working on a software development team, you will be given a slice of the work to complete. For instance, there are times when you will be tasked with creating code for the views, while another developer is tasked with working on controllers or DAOs.

In this exercise you've been given 3 views that work with a `Product` model. These views have the following responsibilities:

- Products/Index.cshtml

  - This view displays a list of products.
  - `http://localhost:xxxxx/products/`
  - `http://localhost:xxxxx/products/index`

- Products/Tile.cshtml

  - This view displays a grid view of products.
  - `http://localhost:xxxxx/products/tile`

- Products/Detail.cshtml

  - This view displays the details for a specific product.
  - `http://localhost:xxxxx/products/detail/SKU-1234`
  - `http://localhost:xxxxx/products/detail?id=SKU-1234`

Each of these views already contains template HTML, as well as comments in the code to direct you through the work that needs to be completed. Your job will be to replace the HTML with Razor code to dynamically build the view with the data provided.

Additionally, you will need to create dynamic URLs in the views. For instance, when you click on a product image, you will go to the details page specific to that product.

The controllers, DAO, database, CSS, and routes have already been created for you. Your work will be isolated to implementing Razor syntax in the views.

### Example Layouts

#### List View

![List View](examples/product-list.png)

#### Tile View

![Table View](examples/product-tile.png)

#### Detail View

![Detail View](examples/product-detail.png)

Your work will be evaluated on the following:

- The data from the database being displayed appropriately on the page.
- Monetary data is being displayed in a currency format.
- The average rating for a product displays the appropriate number of filled in stars.
- All five stars are displayed for each rating.
- Top seller banners are displayed appropriately for top selling products.
- Sold out banners are displayed appropriately for products that are sold out.
- When there are 5 or less products left in the inventory, a message is displayed indicating how many items are left.
- On the product details page, if a product is not sold out, a button is displayed to add the item to the cart.
- On the product details page, if a product is sold out, the add to cart button is disabled.
- The views are updated appropriately when filters are selected.
- Products are sorted appropriately when a sort order is applied.
- When filtering, the view that was being displayed is updated. For instance, when I apply filters on the list view, the product list page is updated accordingly. Similarly, when I apply filters on the tile view, the product tile page is updated accordingly.
- Links to the product details page work on the list/tile views. In other words, when I click on a link, I am taken to the corresponding details page for that product.
- Product images are displayed appropriately.
- The controller, CSS, and DAOs have NOT been modified.
- There are no inline styles being used in the view.
- The view is rendered using server side code (ie, no JavaScript has been added).

**Important** How to generate URLs to filter and sort the data will be addressed on Day 2 in class. Your exercise on Day 1 should focus on implementing the list and tile views.

## Getting Started

- Open SQL Server Management Studio (SSMS), and create a database named Products.
- In SSMS, open the products.sql file, and run it in the Products database.
- Open the MVCModels.sln project in Visual Studio.
- Click the "run" button to start the web server. (You can also achieve this by pressing F5, or Ctrl+F5).
- If the database has been created correctly, you should be able to navigate to one of the URLs specified above without any errors occurring.
- Begin replacing the HTML with Razor code as outlined in each of the views. Repeat until all views are implemented completely.
