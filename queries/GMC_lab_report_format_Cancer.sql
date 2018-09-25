SELECT CANCER.genie_id, DEMOGRAPHICS.nhs_number, CANCER.lab_number, CANCER.blood_dna_to_ukb_fluidx_tube_barcode, CANCER.tissue_dna_to_ukb_fluidx_tube_barcode, CANCER.hospital, CANCER.disease_type, CANCER.status_impl_to_gosh_dispatch_date, CANCER.status_gosh_to_gel_dispatch_date, CANCER.status_consent_date, CANCER.tissue_received_date, CANCER.[status_comments/actions_(tissue)], SWITCH
         (
        CANCER.hospital = 'HH', 'ICHT',
        CANCER.hospital = 'QCH', 'ICHT',
        CANCER.hospital = 'CXH', 'ICHT',
        CANCER.hospital = 'SMH', 'ICHT',
        CANCER.hospital = 'ChelWest', 'C&W',
        CANCER.hospital = 'WESTMID', 'C&W',
        CANCER.hospital = 'WMH', 'C&W',
        CANCER.hospital = 'C&W', 'C&W'
        ) AS LDP, Switch
        (
        CANCER.tissue_received_date IS NOT NULL 
        AND CANCER.status_impl_to_gosh_dispatch_date IS NULL 
        AND
        (CANCER.[status_comments/actions_(tissue)] NOT LIKE '*fail*' OR CANCER.[status_comments/actions_(tissue)] IS NULL),'Samples Pre tissue QC / In Process at GMC',

        CANCER.status_impl_to_gosh_dispatch_date IS NOT NULL,'Samples Passed tissue QC in GMC',

        CANCER.[status_comments/actions_(tissue)] LIKE '*fail*' OR CANCER.tissue_received_date IS NULL ,'Samples not paired or failed QC steps'
        ) AS GEL_QC_STAGE
FROM CANCER INNER JOIN DEMOGRAPHICS ON CANCER.[nhs_number] = DEMOGRAPHICS.[nhs_number];
