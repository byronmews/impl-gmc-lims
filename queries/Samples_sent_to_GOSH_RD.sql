SELECT DEMOGRAPHICS.nhs_number, RD.genie_id, DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, RD.genie_family_id, RD.disease_type, RD.status_impl_to_gosh_dispatch_date, SWITCH
        (
        RD.genie_family_id LIKE 'RYJ*','ICHT',
        RD.genie_family_id LIKE 'RQM*','C&W',
(RD.genie_family_id NOT LIKE 'RYJ*' OR RD.genie_family_id NOT LIKE 'RQM*' OR RD.genie_family_id IS NULL),'NOT ON GENIE'
        ) AS LDP
FROM DEMOGRAPHICS INNER JOIN RD ON DEMOGRAPHICS.[nhs_number] = RD.[nhs_number]
WHERE RD.status_impl_to_gosh_dispatch_date IS NOT NULL;
