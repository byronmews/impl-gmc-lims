SELECT RD.genie_id, DEMOGRAPHICS.nhs_number, DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, RD.genie_family_ID, RD.status_consent_date, RD.received_date, RD.recruiter, RD.status_impl_to_gosh_dispatch_date, RD.comment, SWITCH
        (
        RD.genie_family_id LIKE 'RYJ*','ICHT',
        RD.genie_family_id
LIKE 'RQM*','C&W',
(RD.genie_family_id NOT LIKE 'RYJ*' OR RD.genie_family_id NOT LIKE 'RQM*' OR RD.genie_family_id IS NULL),'NOT ON GENIE'
        ) AS LDP
FROM RD INNER JOIN DEMOGRAPHICS ON RD.[nhs_number] = DEMOGRAPHICS.[nhs_number]
WHERE RD.status_impl_to_gosh_dispatch_date IS NOT NULL;
