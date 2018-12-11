Imperial GMC lab
========================

# About

Light weight MS Access DB tracking of samples within LDP pipelines, enabling quick deployment within existing nhs lab setup. All forms, sql queries and empty tables for sample tracking can be found in this repository. Provides standard operations for sample visibility and reporting, with tables and relationships  structured to enable easier conversion downstream.

See:
https://github.com/byronmews/impl-gmc-lims/wiki

Notes:
* Data entry via form New Participant.
* CRUD actions using forms, main entry from New Participant entry form (default on database load)
* Main VBA logic held within New Participant form, includes central SQL joins for main project disease arms, and reporting queries and export functions.
* Reporting links out to paths setup within local network environment, change as appropriate.


# Warning

* Code built and tested on MS Access 2010/2016. Compiled using 2010 for version compatibity, but YMMV.*

