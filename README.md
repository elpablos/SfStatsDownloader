# SfStatsDownloader #

Very simple WindowForms application for downloading statistics from web server:

[sfstats.net](http://www.sfstats.net/)

It can also export it in CSV format.

### What is this repository for? ###

* Just keep source codes online and save
* 1.3.0
* [Learn Markdown](https://bitbucket.org/tutorials/markdowndemo)

### How do I get set up? ###

* Open solution in VS2015+
* Rebuild application
* NuGet downloads - HttpAgilityPack library itself
* Just play 

### How to use it ###

* After start StsStatsDownloader application
* Click on textBox line, and set up webpages to download
    * you can do it easily with button "Parse links from clipboard"
    * just go to archive (for example [Hockey archive](http://www.sfstats.net/hockey/leagues/archive))
    * select table of your favourite team with mouse and copy to clipboard (CTRL+C)
    * now, just use "Parse links from clipboard" button
* Press "Process" button to parse main data
* If you need download tooltips of score, just press "Extend"
    * Skip checkbox is only for match where is goal difference = 1 
* After all, you can save results by "Export" button

### Who do I talk to? ###

* Repo owner or admin
* Other community or team contact