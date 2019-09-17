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


## Design patters ##
 - Repository pattern
 - Unit of work
 - Dependency injection
## Framework, Packages and Tools   ##
 - Net core 2.2
 - Jquery for UI
 - Automapper
 - Swashbuckle for Open Api documentation
 - NUnit
 - Moq
 - Postman 
 
## How to setup and execute   ##
 1. Clone the [repository](https://github.com/wilvermelendez/ManageStore.git)
 2. Open ManageStore solution
 3. Set your **database connection string** in **appsettings.json in ManageStore project** by default it is Using ***(localdb)\\mssqllocaldb***     
> Server=(localdb)\\mssqllocaldb;Database=ManageStore
 4. The go to the **Package Manager Console** in visual studio
 5. Select  Default project ManageStore.ApplicationDbContext [screenshot](https://photos.app.goo.gl/HCJ68AULUVzp3eaX8)
 6. Run `update-database` on **Package Manager Console**
 7. Then you can run the app, it will show you 2 tab in the browser, one for the Web Api and the other for the Web UI see [screenshot](https://photos.app.goo.gl/HCJ68AULUVzp3eaX8)
 8. Download test for postman from [postman link](https://www.getpostman.com/collections/8aef90be8d6fa48e402d) or [github link](https://github.com/wilvermelendez/ManageStore/tree/master/ManageStore/ManageStoreTest/ManageStore.postman_collection.json)  
 
## Users   ##
**Admin**

    User name: wimelendez
    Password: @dmin

**Regular user**

    User name: User
    Password: Tester@01

