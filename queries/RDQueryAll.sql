SELECT DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, DEMOGRAPHICS.dob, DEMOGRAPHICS.nhs_number, RD.nhs_number, DEMOGRAPHICS.gender, RD.[temp_participant/gel_id], RD.genie_id, RD.genie_family_id, RD.consultant, RD.pedigree_attached, RD.pho, RD.mrn, RD.recruiter, RD.received_date, RD.status_consent_date, RD.[#_of_tubes], RD.comment, RD.status_impl_to_gosh_dispatch_date, RD.status_impl_to_gosh_consignment_number, RD.status_impl_to_gosh_delivery_reference, RD.status_gosh_to_gel_dispatch_date, RD.status_gosh_to_gel_consignment_number, RD.[80_freezer_number], RD.[80_freezer_shelf], RD.box_storage_at_80, RD.[dna_ext#_date], RD.[molarity_(ng/ul)], RD.[260/280], RD.impl_storage_fluidx_rack_id, RD.impl_storage_fluidx_tube_barcode, RD.impl_storage_fluidx_tube_coordinates, RD.[impl_storage_volume_(µl)], RD.to_send_fluidx_rack_id, RD.to_send_impl_storage_fluidx_tube_barcode, RD.to_send_fluidx_tube_coordinates, RD.[to_send_original_volume_(µl)], RD.[to_send_molarity_(ng/ul)_sent], RD.[to_send_volume_to_send_(µl)], RD.temporary_storage_fluidx_rack_id, RD.temporary_storage_fluidx_tube_barcode, RD.temporary_storage_fluidx_tube_coordinates, RD.disease_type, RD.disease_subtype, RD.hospital
FROM DEMOGRAPHICS INNER JOIN RD ON DEMOGRAPHICS.[nhs_number] = RD.[nhs_number];
