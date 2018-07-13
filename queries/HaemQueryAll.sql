SELECT DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, DEMOGRAPHICS.dob, DEMOGRAPHICS.nhs_number, HAEM.status_gosh_to_gel_date, HAEM.status_gosh_to_gel_consignment_number, DEMOGRAPHICS.gender, HAEM.nhs_number, HAEM.lab_number, HAEM.mrn, HAEM.genie_id, HAEM.hospital, HAEM.recruiter, HAEM.disease_type, HAEM.disease_subtype, HAEM.consultant, HAEM.status_consent_date, HAEM.status_saliva, HAEM.status_blood, HAEM.[status_stored_cell_in_stem_cell_lab/gtc], HAEM.[status_comments/actions], HAEM.status_impl_to_gosh_dispatch_date, HAEM.status_impl_to_gosh_consignment_number, HAEM.status_impl_to_gosh_delivery_reference, HAEM.saliva_pathology_received_date, HAEM.saliva_pathology_tissue_type, HAEM.saliva_storage_box_number, HAEM.saliva_storage_tube_coordinate, HAEM.[saliva_dna_qc_dna_ext#_date], HAEM.[saliva_dna_qc_molarity_(ng/ul)], HAEM.[saliva_dna_qc_molarity_(ng/ul)_to_send], HAEM.[saliva_dna_qc_volume_(ul)_to_send], HAEM.[saliva_dna_qc_260/280], HAEM.saliva_dna_storage_impl_fluidx_rack_id, HAEM.saliva_dna_storage_impl_fluidx_tube_barcode, HAEM.saliva_dna_storage_impl_fluidx_tube_coordinates, HAEM.[saliva_dna_storage_impl_-80_freezer], HAEM.saliva_dna_to_ukb_fluidx_rack_id, HAEM.saliva_dna_to_ukb_fluidx_tube_barcode, HAEM.saliva_dna_to_ukb_fluidx_tube_coordinates, HAEM.[saliva_dna_to_ukb_+4°c_freezer], HAEM.blood_pathology_received_date, HAEM.blood_pathology_tissue_type, HAEM.[blood_dna_qc_dna_ext#_date], HAEM.[blood_dna_qc_molarity_(ng/ul)], HAEM.[blood_dna_qc_molarity_(ng/ul)_to_send], HAEM.[blood_dna_qc_volume_(ul)_to_send], HAEM.[blood_dna_qc_260/280], HAEM.[blood_storage_impl_box_number_(gmc_blood_haem-onco_sample)], HAEM.blood_storage_impl_boxtube_location_1, HAEM.blood_storage_impl_boxtube_location_2, HAEM.[blood_storage_impl_box-80°c_freezer], HAEM.blood_storage_impl_boxfluidx_rack_id, HAEM.blood_storage_impl_box_fluidx_tube_barcode, HAEM.blood_storage_impl_boxfluidx_tube_coordinates, HAEM.[blood_storage_impl_box-80°c_freezer1], HAEM.blood_dna_to_ukb_fluidx_rack_id, HAEM.blood_dna_to_ukb_fluidx_tube_barcode, HAEM.blood_dna_to_ukb_fluidx_tube_coordinates, HAEM.[blood_dna_to_ukb_-80°c_freezer]
FROM DEMOGRAPHICS INNER JOIN HAEM ON DEMOGRAPHICS.[nhs_number] = HAEM.[nhs_number];
