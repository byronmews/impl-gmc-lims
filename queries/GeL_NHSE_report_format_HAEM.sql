SELECT HAEM.genie_id, DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, HAEM.hospital, HAEM.germline_pathology_received_date, HAEM.cancer_pathology_received_date, HAEM.[status_tissue], HAEM.disease_type, HAEM.status_impl_to_gosh_dispatch_date, SWITCH
        (         
        HAEM.hospital = 'HH', 'ICHT',         
        HAEM.hospital = 'QCH', 'ICHT',         
        HAEM.hospital = 'CXH', 'ICHT',         
        HAEM.hospital = 'SMH', 'ICHT',         
        HAEM.hospital = 'ChelWest', 'C&W',         
        HAEM.hospital = 'WESTMID', 'C&W',         
        HAEM.hospital = 'WMH', 'C&W',
        HAEM.hospital = 'C&W', 'C&W'
        ) AS LDP, SWITCH
(
        HAEM.germline_pathology_received_date IS NOT NULL 
        AND HAEM.cancer_pathology_received_date IS NOT NULL
        AND HAEM.status_impl_to_gosh_dispatch_date IS NULL
        AND HAEM.status_tissue IS NULL,'Samples Pre tissue QC / In Process at GMC',

       HAEM.status_impl_to_gosh_dispatch_date IS NOT NULL
       OR HAEM.status_tissue LIKE "PASS", 'Samples Passed tissue QC in GMC',

        HAEM.germline_pathology_received_date IS NULL
        OR HAEM.cancer_pathology_received_date IS NULL
        OR HAEM.status_tissue LIKE "FAIL*",'Samples not paired or failed QC steps'

        ) AS GEL_QC_stage
FROM HAEM INNER JOIN DEMOGRAPHICS ON HAEM.[nhs_number] = DEMOGRAPHICS.[nhs_number];
