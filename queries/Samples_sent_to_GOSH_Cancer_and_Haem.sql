SELECT
        DEMOGRAPHICS.nhs_number, CANCER.genie_id, DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, CANCER.disease_type, CANCER.status_impl_to_gosh_dispatch_date, SWITCH
         (
        CANCER.hospital = 'HH', 'ICHT',
        CANCER.hospital = 'QCH', 'ICHT',
        CANCER.hospital = 'CXH', 'ICHT',
        CANCER.hospital = 'SMH', 'ICHT',
        CANCER.hospital = 'ChelWest', 'C&W',
        CANCER.hospital = 'WESTMID', 'C&W',
        CANCER.hospital = 'WMH', 'C&W',
        CANCER.hospital = 'C&W', 'C&W'
        ) AS LDP
FROM
        CANCER INNER JOIN DEMOGRAPHICS ON CANCER.nhs_number = DEMOGRAPHICS.nhs_number
WHERE
        CANCER.status_impl_to_gosh_dispatch_date IS NOT NULL

UNION
SELECT
        DEMOGRAPHICS.nhs_number, HAEM.genie_id, DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, HAEM.disease_type, HAEM.status_impl_to_gosh_dispatch_date, SWITCH
         (
        HAEM.hospital = 'HH', 'ICHT',
        HAEM.hospital = 'QCH', 'ICHT',
        HAEM.hospital = 'CXH', 'ICHT',
        HAEM.hospital = 'SMH', 'ICHT',
        HAEM.hospital = 'ChelWest', 'C&W',
        HAEM.hospital = 'WESTMID', 'C&W',
        HAEM.hospital = 'WMH', 'C&W',
        HAEM.hospital = 'C&W', 'C&W'
        ) AS LDP
FROM
        HAEM INNER JOIN DEMOGRAPHICS ON HAEM.nhs_number = DEMOGRAPHICS.nhs_number
WHERE
        HAEM.status_impl_to_gosh_dispatch_date IS NOT NULL;
