SELECT DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, DEMOGRAPHICS.nhs_number, RD.genie_family_id, RD.genie_id, RD.status_consent_date, RD.received_date, RD.recruiter, RD.status_impl_to_gosh_dispatch_date, RD.comment, SWITCH
        (
        RD.genie_family_id LIKE 'RYJ*','ICHT',
        RD.genie_family_id LIKE 'RQM*','C&W',
        (RD.genie_family_id NOT LIKE 'RYJ*' OR RD.genie_family_id NOT LIKE 'RQM*' OR RD.genie_family_id IS NULL),'NOT ON GENIE'
        ) AS LDP, SWITCH
        (
        RD.status_impl_to_gosh_dispatch_date Is Null AND
        (RD.comment NOT LIKE '*Discarded' OR RD.comment Is NULL), 'Total Sample numbers Processed & held at NHS GMC',
        RD.status_impl_to_gosh_dispatch_date IS NOT NULL, 'Total Sample Numbers sent to Biorep',
        RD.comment LIKE '*Discarded', 'RD discarded'
        ) AS GEL_QC_STAGE
FROM DEMOGRAPHICS INNER JOIN RD ON DEMOGRAPHICS.[nhs_number] = RD.[nhs_number]
WHERE RD.received_date <= #2018-08-24#;
