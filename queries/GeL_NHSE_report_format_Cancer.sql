SELECT CANCER.genie_id, DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, CANCER.status_consent_date, CANCER.hospital, CANCER.[status_comments/actions_(blood)], CANCER.[status_comments/actions_(tissue)], CANCER.disease_type, CANCER.status_impl_to_gosh_dispatch_date, CANCER.status_tissue, Switch
        (
        CANCER.hospital = 'HH', 'ICHT',
        CANCER.hospital = 'QCH', 'ICHT',
        CANCER.hospital = 'CXH', 'ICHT',
        CANCER.hospital = 'SMH', 'ICHT',
        CANCER.hospital = 'Western Eye Hospital', 'ICHT',
        CANCER.hospital = 'ChelWest', 'C&W',
        CANCER.hospital = 'WESTMID', 'C&W',
        CANCER.hospital = 'WMH', 'C&W',
        CANCER.hospital = 'C&W', 'C&W'
        ) AS LDP, Switch
        (
        CANCER.tissue_received_date IS NOT NULL
        AND CANCER.status_impl_to_gosh_dispatch_date IS NULL
        AND CANCER.status_tissue IS NULL ,'Samples Pre tissue QC / In Process at GMC',

        CANCER.status_impl_to_gosh_dispatch_date IS NOT NULL
        OR CANCER.status_tissue LIKE "PASS",'Samples Passed tissue QC in GMC',

       CANCER.tissue_received_date IS NULL
       OR (CANCER.status_tissue LIKE "FAIL*" OR CANCER.status_tissue IS NULL) ,'Samples not paired or failed QC steps'

        ) AS GEL_QC_STAGE
FROM CANCER INNER JOIN DEMOGRAPHICS ON CANCER.[nhs_number] = DEMOGRAPHICS.[nhs_number];
