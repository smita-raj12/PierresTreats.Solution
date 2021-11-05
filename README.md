# Pierre's Sweet and Savory Treats

Pierre wants to create a new application to market his sweet and savory treats. 
So this web application is use to built with user authentication and a many-to-many relationship. Here are the some features of the application:

* The application should have user authentication. A user should be able to log in and log out. Only logged in users should have create, update and delete functionality. All users should be able to have read functionality.

* There should be a many-to-many relationship between Treats and Flavors. A treat can have many flavors (such as sweet, savory, spicy, or creamy) and a flavor can have many treats. For instance, the "sweet" flavor could include chocolate croissants, cheesecake, and so on.

* A user should be able to navigate to a splash page that lists all treats and flavors. Users should be able to click on an individual treat or flavor to see all the treats/flavors that belong to it.

* This application has separate roles for admins and logged-in users. Only admins should be able to add, update and delete. There is an order form that only logged-in users can access. A logged-in user should be able to create, read, update and delete their own order.

## Name of Author:

   _Smita_

## Technologies used:

* C#

* MySQL

* MySQL Workbench

* .NET 5 SDK

* Git BASH

* ASP .NET CORE MVC

* My SQL Designer



## Setup/Installation Requirements

1. Download or clone the [https://github.com/smita-raj12/PierresTreats.Solution](https://github.com/smita-raj12/PierresTreats.Solution) to your local machine.

2. Download any Code Editor for your choice. (Here I used VSCode).

3. Open git BASH terminal and navigate to the PierresTreats folder, within the directory
Run `dotnet restore` in the git BASH terminal to install dependencies. 

4. Create appsettings.json file in the PierresTreats directory of PierresTreats.Solution (run the command touch appsettings.json) and add the following code to the file: appsettings.json

      
        {                                                    
         "ConnectionStrings":{                                                          
            "DefaultConnection": "Server=localhost;Port=3306;database=pierres_treats;uid={YOUR-USER-NAME};pwd= {YOUR-PASSWORD};"                                        
          }                                                                                
        }                                                                               

5. Remove the {YOUR_USERNAME_NAME} and {YOUR_PASSWORD} and fill in the the code snippet with your username for MySQL, and MySQL password Do not include the curly brackets in your code snippet of appsettings.json

6. Run "dotnet build" in the git BASH terminal to build, and run the project in the terminal. $ dotnet watch run

7. View the website by visiting localhost:5000/ in a new web browser( such as google chrome) tab!


## Known bugs

None 

## License information with a copyright and date:

 [MIT](https://opensource.org/licenses/MIT)

## Contact information:
   
* EmailId: smita.raj12@gmail.com

