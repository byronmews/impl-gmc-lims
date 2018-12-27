Imperial GMC lab
========================

# About

Light weight MS Access DB tracking of samples within LDP pipelines, enabling quick deployment within existing nhs lab setup. All forms, sql queries and empty tables for sample tracking can be found in this repository. Provides standard operations for sample visibility and reporting, with tables and relationships structured to enable easier conversion downstream.

For more information see:
https://github.com/byronmews/impl-gmc-lims/wiki

Notes:
* Data entry via New Participant form.
* CRUD actions using forms, main entry from New Participant form (defaults to on database load).
* Main VBA logic held within New Participant form, includes central SQL joins for main project disease arms, and reporting queries and export functions.
* Reporting links out to paths setup within local network environment, for export and updating to exisiting pivot tables relevant to gmc requirements. Change as appropriate.

# Warning

* Code built and tested on MS Access 2010/2016. Compiled using 2010 for version compatibity, but YMMV.*

