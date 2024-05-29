A simple C# .Net8 Console Application that reads names from a text File, Sorts the names alphabetically and saves it to a text file.

To run this application place create a text file called unsorted-names-list.txt in your working directory (Same location as your ".exe") name-sorter ./unsorted-names-list.txt

The application will sort the names, Display it in the Console and save the sorted list to a text file sorted-names-list.txt.

Rules:
1. a valid Name Must have at minumum a Surname and first name
2. A valid Name may have at most 2 middle names.

Keeping in line with Solid Principles and programming best practices I have split that application up into a 
Data Layer, this handles reading and writing from the text file
Logic layer, This does the name sorting.
Test Layer, All logic Test.

The application makes use of OOP, Interfaces, Dependacy injection and async where needed.




