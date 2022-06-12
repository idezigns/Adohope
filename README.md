### Adohope

### IT IS UNDER DEVELOPMENT. USE AT YOUR RISK.
### TinyTool has been tested with iPhone backup, iPod backup and iPod backup, it works fine but with some problems in the extracted data.

Adohope is a free Apple Backup Extractor. It can extract data from iPhone backup, iPad backup and iPod backup.


### Project structre

- Root
---- IBackup
---- Backup
---- Modules
---- Shared

## Backup class

This class is the main class where we will pass the backup path to its constructor and start using all the functionality of the library.

## Modules folder

Here all the modules that are used to parse the backup data. Modules like, ManifestDb, Photos, Contacts, etc..

## Shared folder

Here are all the classes that are shared in the project.


TODO:

##
-- Write one factory for each module, the factory should be responsible for all creations such as (Services, Context, etc).
Re-write factory classes to be general factory classes as the following, (ContextFactory, ServiceFactory, RepositoryFactory, etc).

##
-- Remove EntitiesConfigurations classes and replace them with a methods in context class instead.

##
-- Move Context class to the root directory of the module and remove Contexts folder.

##
Create module main class that will focus on clear naming.

##
In MBFileRepositoryFactory class, move the guessing methods to BackupCheckerUtils class.

##
Re-write extractor lib.

##
In shared folder, change PList folder name to DynamicPList, and PListExtensions to DynamicPListExtensions.

##
In Backup class, remove services getters and replace them with the main class for each module after creating it.

##
In Backup class, create dictionary variable and put the main modules classes on it instead of storing each one indivually.
Same for PList files.