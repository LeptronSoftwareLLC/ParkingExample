Setting up the the Database

1. Create a blank database. Run the following commands on that database.


CREATE LOGIN ParkingUser WITH PASSWORD = '<CHANGE ME>';
create user ParkingUser for login ParkingUser
GRANT EXECUTE ON SCHEMA :: dbo TO ParkingUser;  

Note: the user name AND password can be anything you want, just make sure they match the connection string in the Rest API.

2. Run ParkingScript.sql on the database

Setting up the Rest API


1. Change the ParkingConnection connection string in appsettings.Development.json to the User Name and password you created while setting up the database.
2. Make sure you are launching the project with with "IIS" NOT "IIS Express". This setting can be found in project->MyParkingAPI properties -> Debug.
The Android emulator needs to be able to resolve 10.0.2.2 to localhost. IIS Express does not easily allow for that.


Setting up the mobile application

1. In the ParkingServiceAPI, set the _url to the URL used by Rest API project in project->MyParkingAPI properties -> Debug -> App URL. 
2. The app was only tested using the Android emulator. No changes were made to the iOS project that Prism generates so it should run. You could create a publically available API using pagekite or similiar, change the URL in the ParkingServiceAPI and it should work.

Additional items
The counts in the drop down are not refreshed when a user adds  or removes a car. The drop down is doing too much. I would just make the drop down only have LocationID and Description and then have the status message updated with a call to a RestAPI that gives only the data for a location. So the Drop Down and GetAll in the RestAPI are trying to do too much and need to be broken down into smaller pieces.





