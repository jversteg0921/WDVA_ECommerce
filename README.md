# WDVA_ECommerce
Simple ecommerce site for hiring process at WDVA

Prerequisites
Install .NET 6: Make sure you have .NET 6 SDK installed on your machine. You can download it from the official .NET website: https://dotnet.microsoft.com/download/dotnet/6.0

Git: You should have Git installed on your system to clone the GitHub repository. You can download it from https://git-scm.com/downloads.

Clone the Repository
Open your terminal or command prompt.

Navigate to the directory where you want to clone the project.

Run the following command to clone the GitHub repository:

    git clone https://github.com/username/project-name.git](https://github.com/jversteg0921/WDVA_ECommerce.git

#------------------------------------------------------------#
This project uses a Code-First Approach

You will need to apply migrations to create the database and seed initial data. You can do this using the Entity Framework Core CLI.

Open a new terminal window.

Navigate to the project's server directory.

    cd WDVA_ECommerce/Server
    
Run the following command to apply migrations and create the database:

    dotnet ef database update
This command will apply any pending migrations and create the database based on your code-first model.

#------------------------------------------------------------#
Build and Run the Blazor WebAssembly Project
Navigate to the project directory:

    cd WDVA_ECommerce

Build the project using the .NET CLI:

    dotnet build


Restore NuGet packages:

    dotnet restore

    
Run the Blazor WebAssembly project:

    dotnet run
    
This will start a local development server, and you'll see output similar to the following:

info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:{portnumber}
      
Open your web browser and navigate to https://localhost:{portnumber} to access the application.



That's it! You should now have the project up and running. You can start exploring and using the application.

The application is a simple ECommerce demo site. You are able to view the featured products on the home page, explore additional products by category and add products to your cart. To view the cart you must register and login with the site.

Registration information can be entered manually or using the "Create User from RandomUser" button, which populates all the needed data through the 3rd party api at https://randomuser.me/

Once a user is logged in, they can view their profile, where they can edit personal data, change their password or delete their account. They can also view their cart and "submit an order". They can also view all their previous orders.
