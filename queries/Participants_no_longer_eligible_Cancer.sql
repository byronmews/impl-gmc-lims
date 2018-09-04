SELECT CANCER.[nhs_number], CANCER.[status_impl_to_gosh_dispatch_date], CANCER.[lab_number], CANCER.[mrn], CANCER.[genie_id], CANCER.[hospital], CANCER.[disease_type], CANCER.[status_consent_date], CANCER.[status_tissue], CANCER.[status_reason_for_withdrawal], CANCER.[copath_first_report_of_gel_dispatched_or_withdrawn]
FROM CANCER
WHERE CANCER.status_tissue <> 'PASS';
