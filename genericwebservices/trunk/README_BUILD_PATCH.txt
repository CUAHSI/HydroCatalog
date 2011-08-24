There is an error in the SP1 web deploy

http://support.microsoft.com/kb/2537134

Solution 2: Replace Microsoft.Web.Publishing.targets

In this solution you perform the following steps:

Backup your copy of Microsoft.Web.Publishing.targets file
Copy the new Microsoft.Web.Publishing.targets file to the correct location
Clean the impacted projects
Rebuild the package


Step 1 - Backup your copy of Microsoft.Web.Publishing.targets

Before you replace your version of Microsoft.Web.Publishing.targets file it is suggested that you backup the current version in case you ever need to revert back to it. This file is located at the following location by default:


Computer Architecture --- Location
x86 (32 bit) --- C:\Program Files\MSBuild\Microsoft\VisualStudio\v10.0\Web\Microsoft.Web.Publishing.targets
x64 (64 bit) --- C:\Program Files (x86)\MSBuild\Microsoft\VisualStudio\v10.0\Web\Microsoft.Web.Publishing.targets



2 : Use new targets provided by Microsoft

New Microsoft.Web.Publishing.targets are stored here: http://go.microsoft.com/fwlink/?LinkID=216789&clcid=0x409



 

 


