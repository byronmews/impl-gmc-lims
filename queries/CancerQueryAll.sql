SELECT CANCER.genie_id, DEMOGRAPHICS.first_name, DEMOGRAPHICS.surname, DEMOGRAPHICS.dob, DEMOGRAPHICS.nhs_number, DEMOGRAPHICS.gender, CANCER.nhs_number, CANCER.lab_number, CANCER.mrn, CANCER.hospital, CANCER.consultant, CANCER.recruiter, CANCER.disease_type, CANCER.disease_subtype, CANCER.status_consent_date, CANCER.status_tissue, CANCER.[status_comments/actions_(tissue)], CANCER.status_tissue_request_date, CANCER.[status_comments/actions_(blood)], CANCER.[status_eligible_(y/n)], CANCER.status_impl_to_gosh_dispatch_date, CANCER.status_impl_to_gosh_consignment_number, CANCER.status_impl_to_gosh_delivery_reference, CANCER.status_gosh_to_gel_dispatch_date, CANCER.status_gosh_to_gel_consignment_number, CANCER.status_reason_for_withdrawal, CANCER.copath_first_report_of_gel_dispatched_or_withdrawn, CANCER.copath_second_report_of_results, CANCER.tissue_received_date, CANCER.tissue_label_on_tube, CANCER.tissue_histology_number, CANCER.tissue_type, CANCER.tissue_assessement_date, CANCER.tissue_assessed_by, CANCER.tissue_tumour_type, CANCER.tissue_tumour_source, CANCER.tissue_tumour_sample_type, CANCER.tissue_cellularity, CANCER.tissue_pct_necrosis, CANCER.tissue_snomed_code, CANCER.tissue_topography, CANCER.tissue_tumour_content, CANCER.tissue_dna_qc_dna_ext_date, CANCER.[tissue_dna_qc_molarity_(ng/ul)], CANCER.[tissue_dna_qc_molarity_(ng/ul)_after_dilution], CANCER.[tissue_dna_qc_volume_sent_(ul)], CANCER.[tissue_dna_qc_260/280], CANCER.tissue_dna_storage_impl_fluidx_rack_id, CANCER.tissue_dna_storage_impl_fluidx_tube_barcode, CANCER.tissue_dna_storage_impl_fluidx_tube_coordinates, CANCER.tissue_dna_storage_impl_minus80_freezer, CANCER.tissue_dna_to_ukb_fluidx_rack_id, CANCER.tissue_dna_to_ukb_fluidx_tube_barcode, CANCER.tissue_dna_to_ukb_fluidx_tube_coordinates, CANCER.tissue_dna_to_ukb_plus4_freezer, CANCER.blood_received_date, CANCER.blood_tissue_type, CANCER.blood_dna_qc_dna_ext_date, CANCER.[blood_dna_qc_molarity_(ng/ul)], CANCER.[blood_dna_qc_molarity_(ng/ul)_after_dilution], CANCER.[blood_received_volume_sent_(ul)], CANCER.[blood_dna_qc_260/280], CANCER.[blood_storage_impl_box_id_(gmc_blood_cancer_sample)], CANCER.blood_storage_impl_tube_location_1, CANCER.blood_storage_impl_tube_location_2, CANCER.blood_storage_impl_minus80_freezer, CANCER.blood_dna_storage_impl_fluidx_rack_id, CANCER.blood_dna_storage_impl_fluidx_tube_barcode, CANCER.blood_dna_storage_impl_fluidx_tube_coordinates, CANCER.blood_dna_storage_impl_minus80_freezer, CANCER.blood_dna_to_ukb_fluidx_rack_id, CANCER.blood_dna_to_ukb_fluidx_tube_barcode, CANCER.blood_dna_to_ukb_fluidx_tube_coordinates, CANCER.blood_dna_to_ukb_minus80_freezer
FROM CANCER INNER JOIN DEMOGRAPHICS ON CANCER.[nhs_number] = DEMOGRAPHICS.[nhs_number]
ORDER BY CANCER.status_consent_date;
