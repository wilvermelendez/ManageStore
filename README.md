Manage Store Web API challenge
==================
This challenge is designed to put your skills to the test by designing and building a good REST API to manage a small snacks store using .net Core.

## Requirements ##


### General requirements ###
* The API should allow
   * Adding/Removing products and set their stock quantity.
   * Modify the price of the products
   * Save a log of the price updates for a product.
   * Buy a product
   * Buying a product should reduce its stock.
   * Keep a log of all the purchases (who bought it, how many, when).
   * Liking a product
   * Obtain a list of all the available products.
   * The list should be sortable by name (default), and by popularity (likes).
   * The list should have pagination functionality.
   * Search through the products by name.
### Security requirements ###
* Add login functionality so: 
   * Only admins can Add/remove products.
   * Only admins can modify price of the products.
   * Only logged in users can buy a product.
   * Any logged in users could *like* a product.
   * Everyone (logged in or not logged in) can get a list of all the products.
   * Everyone (logged in or not logged in) can use the search feature.
### Extra credit ###
* Build a small front-end application that:
   * Connects to the API to show a list of the products
   * The app should allow searching products by name

==================
## Tools and Packages ##

