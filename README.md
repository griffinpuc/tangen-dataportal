# tangen-dataportal
&nbsp;&nbsp;&nbsp;&nbsp;Data portal for Tangen Biosciences functioning as a simple but functional UI for organizing and filtering datasets. Works in conjunction with the database updater and a SQLExpress server.
For usage and build instructions, see below. For all other information refer to the Wiki. Please note that this is designed to work in a specific environment for specific usages.
<br />

## Usage & Build Instructions

### Requirements:
1. Cloned repository
2. Visual Studio 2017 or 2019
3. IIS Services Enabled
4. IIS Manager
5. SQLExpress Server (Or equivalent)


### Structuring Database
1. This is handled by EntityFramework Core. First set your connection string in <code>appsettings.json</code>
2. Open <code>View > Other Windows > Pakcage Manager Console</code>
3. Enter <code>add-migration MyMigrationName</code>, replacing 'MyMigrationName' with whatever you'd like
4. Enter <code>update-database</code> and observe as it works flawlessly or fails epically.


### Running Server
1. After built and tested successfully in Visual Studio Debug publish to the base directory of the site you created in IIS Server Manager.
2. For any troubleshooting, refer to <code>web.config</code>, enable stdout logs, and create the 'logs' directory in your site's base directory. All logs will now be dumped here for troubleshooting.

<br />

### Troubleshooting
For all issues regarding this software, and I don't know why anyone would because no one would use it, create an issue in this repo. Merci.

<br />

Copyright &copy; Tangen Biosciences 2019
