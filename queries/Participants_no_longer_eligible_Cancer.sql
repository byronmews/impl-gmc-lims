SELECT CANCER.nhs_number, CANCER.genie_id, CANCER.lab_number, CANCER.mrn, CANCER.hospital, CANCER.status_consent_date, CANCER.disease_type, CANCER.tissue_received_date, CANCER.status_tissue, CANCER.status_impl_to_gosh_dispatch_date, CANCER.[status_comments/actions_(tissue)], CANCER.[copath_first_report_of_gel_dispatched_or_withdrawn]
FROM CANCER
WHERE CANCER.status_tissue LIKE 'FAIL*';
