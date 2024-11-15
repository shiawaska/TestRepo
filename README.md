


### In the beginning,
	- read ReadMe provided.
	 - read familiarized myself with CQRS being used.
	 - read premade API endpoints.
	- Using Visual Studio i started building API endpoints for each controller in CQRS style.
	 - I first built out the MissionsController's Queries and commands
		 using swagger to verify their returns.
		once i had the returns i (thought) i expected
		 i moved on to making my serverside validation more robust by referencing 
		 the models and DTO's aswell as adding some DB verification.
	- then i did the same in the same order for the DiscoveryController.
		 all the while testing in swagger valid and invalid results.
	 

### Once I had the API functions crafted and tested within swagger,

	- I started an angular app.
	- Starting with the header, as I intened on using it as a simple navigation tool. I made each component (Homepage,Missions,Discoveries,Planets).
	- building routes and testing links. 
	- built interfaces for each controller (Mirroring c# DropDownDTO and FormDTO).
	- built services for each Component (mirroring C# controllers in the backend).

### After this backbone was done,

	- I started crafting each Task in each Component. This is where i hit some Errors connecting angular to C#. app.UseCors(); was missing from Programs.cs and anglular required me to import "provideHttpClient" into app.config.
	- At this point i started knocking out each task using Select dropdown menus to handle id's and FormDto for all other information aswell as databinding for form submissions.
	- I ended up creating more api endpoints in C# to make data manipulation in angular easier.
	- After my tasks where complete i started looking into client side validation.
	
### Notes

- I have some questions on design choices. 
		why is GetMissions() using a DB model rather than a DTO model?
		 why omit id from DTO model if its going to be sent in the dropdown DTO?
- My focus was on producing functionality over beauty so I ended up not using some functions in angular even though they work in swagger. 
- if I could do more I would implement some singleton services, getall... functions with pagination, and incorporate server side validation error messages within client side responses.

			
			
