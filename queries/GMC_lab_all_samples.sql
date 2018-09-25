    SELECT
        DEMOGRAPHICS.nhs_number, CANCER.genie_id, CANCER.disease_type, CANCER.status_impl_to_gosh_dispatch_date, CANCER.copath_first_report_of_gel_dispatched_or_withdrawn, CANCER.lab_number, CANCER.status_impl_to_gosh_consignment_number, CANCER.consultant, CANCER.recruiter, CANCER.status_consent_date, CANCER.disease_subtype, 'cancer' AS disease_group
    FROM
        CANCER INNER JOIN DEMOGRAPHICS ON CANCER.nhs_number = DEMOGRAPHICS.nhs_number

UNION

    SELECT
        DEMOGRAPHICS.nhs_number, HAEM.genie_id, HAEM.disease_type, HAEM.status_impl_to_gosh_dispatch_date, HAEM.copath_first_report_of_gel_dispatched_or_withdrawn, HAEM.lab_number, HAEM.status_impl_to_gosh_consignment_number, HAEM.consultant, HAEM.recruiter, HAEM.status_consent_date, HAEM.disease_subtype, 'haemonc' AS disease_group

    FROM
        HAEM INNER JOIN DEMOGRAPHICS ON HAEM.nhs_number = DEMOGRAPHICS.nhs_number

UNION
    SELECT
        DEMOGRAPHICS.nhs_number, RD.genie_id, RD.disease_type, RD.status_impl_to_gosh_dispatch_date, RD.copath_first_report_of_gel_dispatched_or_withdrawn, RD.lab_number, RD.status_impl_to_gosh_consignment_number, RD.consultant, RD.recruiter, RD.status_consent_date, RD.disease_subtype, 'raredisease' AS disease_group

    FROM
        RD INNER JOIN DEMOGRAPHICS ON RD.nhs_number = DEMOGRAPHICS.nhs_number;
