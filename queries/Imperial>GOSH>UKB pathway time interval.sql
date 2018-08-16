SELECT 
DEMOGRAPHICS.nhs_number, CANCER.genie_id, CANCER.status_impl_to_gosh_dispatch_date, CANCER.status_gosh_to_gel_dispatch_date, DateDiff("d", CANCER.status_impl_to_gosh_dispatch_date, CANCER.status_gosh_to_gel_dispatch_date) AS 'Number of days'
FROM 
CANCER INNER JOIN DEMOGRAPHICS ON CANCER.nhs_number =  DEMOGRAPHICS.nhs_number
WHERE 
CANCER.status_gosh_to_gel_dispatch_date Is Not NULL

UNION

SELECT 
DEMOGRAPHICS.nhs_number, HAEM.genie_id, HAEM.status_impl_to_gosh_dispatch_date, HAEM.status_gosh_to_gel_dispatch_date, DateDiff("d", HAEM.status_impl_to_gosh_dispatch_date, HAEM.status_gosh_to_gel_dispatch_date) AS 'Number of days'
FROM 
HAEM INNER JOIN DEMOGRAPHICS ON HAEM.nhs_number =  DEMOGRAPHICS.nhs_number
WHERE 
HAEM.status_gosh_to_gel_dispatch_date Is Not NULL

UNION SELECT
DEMOGRAPHICS.nhs_number, RD.genie_id, RD.status_impl_to_gosh_dispatch_date, RD.status_gosh_to_gel_dispatch_date, DateDiff("d", RD.status_impl_to_gosh_dispatch_date, RD.status_gosh_to_gel_dispatch_date)  AS 'Number of days'
FROM 
RD INNER JOIN DEMOGRAPHICS ON RD.nhs_number =  DEMOGRAPHICS.nhs_number
WHERE 
RD.status_gosh_to_gel_dispatch_date Is Not NULL;
