# Hackernews web scraping app

This command line app has been developer used .Net Core C#, and unit tests are written using xUnit. 


# Libraries used

* HtmlAgilityPack - used to parse html straight from a web page via it's xpath. I chose this library as I had never used this before and  wanted to try it out! 
* Newtonsoft.Json - used to convert my list of results to output a json format. I used this as it is a simple and straight forward library that does what is says on the tin, a reliable industry standard! 

# To Run

* cd hackernews.exe/bin/Debug/netcoreapp3.1
* enter 'hackernews.exe --post n' (n refers to the number of posts you want to gather, e.g 'hackernews.exe --post 10'
