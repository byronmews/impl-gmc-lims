SELECT DEMOGRAPHICS.nhs_number, HAEM.genie_id, HAEM.lab_number, HAEM.germline_dna_to_ukb_fluidx_tube_barcode, HAEM.cancer_dna_to_ukb_fluidx_tube_barcode, HAEM.hospital, HAEM.disease_type, HAEM.status_impl_to_gosh_dispatch_date, HAEM.status_gosh_to_gel_dispatch_date, HAEM.status_consent_date, HAEM.germline_pathology_received_date, HAEM.cancer_pathology_received_date, SWITCH
        (         
        HAEM.hospital = 'HH', 'ICHT',         
        HAEM.hospital = 'QCH', 'ICHT',         
        HAEM.hospital = 'CXH', 'ICHT',         
        HAEM.hospital = 'SMH', 'ICHT',         
        HAEM.hospital = 'ChelWest', 'C&W',         
        HAEM.hospital = 'WESTMID', 'C&W',         
        HAEM.hospital = 'WMH', 'C&W'
        ) AS LDP, SWITCH
        (
        HAEM.germline_pathology_received_date IS NOT NULL AND HAEM.cancer_pathology_received_date IS NOT NULL AND
        (HAEM.status_impl_to_gosh_dispatch_date IS NULL OR HAEM.status_tissue <> 'PASS'),'Samples Pre tissue QC / In Process at GMC',

        HAEM.status_germline_dna_qc_passed=-1 AND HAEM.status_tissue = 'PASS', 'Samples Passed tissue QC in GMC',

        HAEM.germline_pathology_received_date IS NULL OR HAEM.cancer_pathology_received_date IS NULL OR HAEM.status_tissue LIKE 'FAIL','Samples not paired or failed QC steps'
        ) AS GEL_QC_stage
FROM HAEM INNER JOIN DEMOGRAPHICS ON HAEM.[nhs_number] = DEMOGRAPHICS.[nhs_number];
