COMPSCI 711 A1 - By David Wagstaff (dwag351)

There are 3 main components of this assignment, the server, cache and client program. I have broken these down
into their respective sections to give further detail on how they work. Right at the bottom of this file, there
are instructions on running all three programs in their entirety.

========== Requirements ==========

You need the following for this project to run:
	- Google Chrome
	- .NET 6.0 SDK
	- Windows 10/11

========== Server ==========

This program has no GUI elements, however, it can be interacted with by sending it web api calls. Using the exe
file in the Build - Server folder starts the server. I recommend starting it before any other program is started.
Inside the Build - Server folder, there is a folder called wwwroot, inside which is another folder called Images.
This is where all the image files are stored. Please add any test files in this directory. Something that should 
be noted is that this server cannot update its stored information on its own. This means that you must be running
the cache program to update the server, further instructions on how to do this will be listed below.

========== Cache ==========

This program does have GUI elements and is the main way of interacting with the cache and server. There are four
buttons at the top of the page:
	- Update Server/Cache: Use this button to update the server when its data (images) have been changed or if
			       the cache has been cleared. This also completely wipes the cache (not the log) so 
			       any data that has already been downloaded will be gone.
	- Refresh Cache View: This button only refreshes the webpages display of the Items on Server and Items on
			      Cache sections. When a new file is saved to the cache, you will want to use this to
			      update the display.
	- Clear Cache: This completely wipes the cache of all its data. (Doesn't effect the Cache Log)
	- Clear Cache Log: Completely wipes the cache log.

There are four main sections to this program's GUI:
	- Cache Log: This section displays a log of the user requests and responses from the cache.
	- Items on Server: This section displays all the items that are currently stored on the server. This needs
			   to be updated if the server has new files/data on it.
	- Items on Cache: This section displays all the items that have been downloaded and stored on the cache.
			  Refresh this section when a new item is downloaded.
	- Cache Data Inspection: This section displays the data of the file that has been selected from the cache.

In any browser, you can access the Cache Portal via https://localhost:5004

========== Client ==========

This program has a GUI element. There are two main sections to this program:
	- Items to Download: This section displays buttons with the names of the files that can be downloaded from
			     the server.
	- Downloaded Items: This section displays the images that have been downloaded, even if they are incomplete.
If the buttons don't represent the data in the server/cache, simply refresh the page and they should be updated.

In any browser, you can access the Client Portal via https://localhost:5006

========== How to Run ==========

There are four main files that need to be opened:
a.	The first file to open is the executable file “Server 6.0.exe” in the folder “Build - Server”.
b.	The second file to open is the executable file “Cache 6.0.exe” in the folder “Build - Cache”.
c.	The third file to open is the executable file “Client 6.0.exe” in the folder “Build - Client”.
d.	The final file is a batch file called “Start.batch” inside the main folder.
Once these files are opened you are ready to test. You can put your test images into a folder called “Images”. You 
can find this folder in the directory called “…/Build – Server/wwwroot/Images”. Once these files are in this folder, 
you can head over to the GUI for the cache and click the “Update Server/Cache” button. This will update the server 
and cache. You should be able to see the available files in the cache. To see the files in the client GUI, you will 
need to refresh the webpage. After following these steps, you should be able to download the images to the client GUI 
and inspect the downloaded data in the cache GUI.

========== When Testing ==========

If you wish to see the fragmentation at work, you can close the server application while downloading an image.
This will cause the cache to save all the fragments it has downloaded and send that information to the client.
I have found this to be the best way of testing the fragmentation, also, you only need to update the server/cache
if the files in the server change, not every time the server is opened.