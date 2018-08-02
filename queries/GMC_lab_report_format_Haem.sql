SELECT DEMOGRAPHICS.nhs_number, HAEM.genie_id, HAEM.lab_number, HAEM.saliva_dna_to_ukb_fluidx_tube_barcode, HAEM.blood_dna_to_ukb_fluidx_tube_barcode, HAEM.hospital, HAEM.disease_type, HAEM.status_impl_to_gosh_dispatch_date, HAEM.status_consent_date, HAEM.[status_saliva], HAEM.[status_blood], HAEM.[status_Stored_cell_in_stem_cell_lab/GTC], SWITCH
        (
        HAEM.hospital = 'HH', 'ICHT',
        HAEM.hospital
= 'QCH', 'ICHT',
        HAEM.hospital = 'CXH', 'ICHT',
        HAEM.hospital = 'SMH', 'ICHT',
        HAEM.hospital = 'ChelWest', 'C&W',
        HAEM.hospital = 'WESTMID', 'C&W',
        HAEM.hospital = 'WMH', 'C&W'
        ) AS LDP, SWITCH
(
        HAEM.[status_saliva] = 'Y' AND HAEM.status_impl_to_gosh_dispatch_date IS NULL 
        AND
(
                HAEM.[status_blood] LIKE 'Y*' OR HAEM.[status_Stored_cell_in_stem_cell_lab/GTC] LIKE 'Y*'
                ), 'Samples Pre tissue QC / In Process at GMC',

        HAEM.[status_saliva] = 'Y' AND HAEM.status_impl_to_gosh_dispatch_date IS NOT NULL 
        AND
(
                HAEM.[status_blood] LIKE 'Y*' OR HAEM.[status_Stored_cell_in_stem_cell_lab/GTC] LIKE 'Y*'
                ), 'Samples Passed tissue QC in GMC',

        HAEM.status_impl_to_gosh_dispatch_date IS NULL
        AND
(
                HAEM.[status_Stored_cell_in_stem_cell_lab/GTC] IS NULL OR HAEM.[status_saliva] = 'N'
                )
        OR
(
                HAEM.[status_Stored_cell_in_stem_cell_lab/GTC] IS NULL OR HAEM.[status_Stored_cell_in_stem_cell_lab/GTC] <> 'Y'
                ), 'Samples not paired or failed QC steps'
        ) AS GEL_QC_stage
FROM HAEM INNER JOIN DEMOGRAPHICS ON HAEM.[nhs_number] = DEMOGRAPHICS.[nhs_number];
