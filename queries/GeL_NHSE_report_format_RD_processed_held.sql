SELECT RD.genie_id, DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, RD.genie_family_ID, RD.status_consent_date, RD.received_date, RD.recruiter, RD.status_impl_to_gosh_dispatch_date, RD.comment, SWITCH
        (
        RD.genie_family_id LIKE 'RYJ*','ICHT',
        RD.genie_family_id LIKE 'RQM*','C&W',
        (RD.genie_family_id NOT LIKE 'RYJ*' OR RD.genie_family_id NOT LIKE 'RQM*'),'NOT ON GENIE') AS LDP
FROM RD INNER JOIN DEMOGRAPHICS ON RD.[nhs_number] = DEMOGRAPHICS.[nhs_number]
WHERE RD.status_impl_to_gosh_dispatch_date Is Null AND (RD.comment NOT LIKE 'discarded' OR RD.comment Is NULL);
