SELECT demographics.nhs_number, cancer.genie_id, demographics.first_name, demographics.surname, cancer.hospital, cancer.status_blood, cancer.[status_comments/actions_(blood)], cancer.status_tissue, cancer.[status_comments/actions_(tissue)], cancer.cancer_type, cancer.[status_eligible_(Y/N)], cancer.[status_impl_to_gosh_dispatch_(date)], SWITCH
        (
        CANCER.hospital = 'HH', 'ICHT',
        CANCER.hospital = 'QCH', 'ICHT',
        CANCER.hospital = 'CXH', 'ICHT',
        CANCER.hospital = 'SMH', 'ICHT',
        CANCER.hospital = 'ChelWest', 'C&W',
        CANCER.hospital = 'WESTMID', 'C&W',
        CANCER.hospital = 'WMH', 'C&W'
        ) AS LDP, SWITCH
        (
        CANCER.status_blood ='Y' AND CANCER.status_tissue ='Y' 
        AND cancer.[status_impl_to_gosh_dispatch_(date)] IS NULL 
        AND CANCER.[status_comments/actions_(tissue)] NOT LIKE 'extracted'
        AND CANCER.[status_comments/actions_(tissue)] NOT LIKE '*failed*', 'Samples Pre tissue QC / In Process at GMC',
        
        CANCER.status_blood = 'Y' AND CANCER.status_tissue = 'Y' 
        AND CANCER.[status_comments/actions_(tissue)] NOT LIKE 'to QC'
        AND 
                (
                cancer.[status_impl_to_gosh_dispatch_(date)] IS NOT NULL OR CANCER.[status_comments/actions_(tissue)] LIKE 'extracted*'
                ), 'Samples Passed tissue QC in GMC',

        CANCER.[status_comments/actions_(tissue)] LIKE '*fail*' OR
        CANCER.status_blood = 'N' OR CANCER.status_blood IS NULL 
        OR CANCER.status_tissue = 'N' OR CANCER.status_tissue IS NULL, 'Samples not paired or failed QC steps',
        ) AS GEL_QC_STAGE, SWITCH
        (
        cancer.cancer_type = 'Breast', 'Breast',
        cancer.cancer_type = 'Ovarian', 'Ovarian',
        cancer.cancer_type = 'Prostate', 'Prostate',
        cancer.cancer_type = 'Lung', 'Lung',
        cancer.cancer_type = 'Colorectal', 'Colorectal',
        cancer.cancer_type = 'Sarcoma', 'Sarcoma',
        cancer.cancer_type = 'Renal', 'Renal',
        cancer.cancer_type = 'Brain' OR CANCER.cancer_type = 'Adult Glioma', 'Adult Brain Tumour',
        cancer.cancer_type = 'Bladder', 'Bladder',
        cancer.cancer_type = 'Endometrial', 'Endometrial',
        cancer.cancer_type = 'Melanoma', 'Melanoma',
        cancer.cancer_type = 'Testicular', 'Testicular',
        cancer.cancer_type = 'Hepatopancreatobiliary', 'Upper GI Tumours (inc. Heptobiliary)',
        cancer.cancer_type = 'Hepatoparv', 'Upper GI Tumours (inc. Heptobiliary)',
        ) AS GEL_CA_TYPE
FROM CANCER INNER JOIN demographics ON cancer.nhs_number = demographics.nhs_number;
