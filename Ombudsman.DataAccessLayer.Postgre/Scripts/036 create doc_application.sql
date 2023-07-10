CREATE TABLE ombudsman.doc_application
(
    id integer NOT NULL,
    doc_number character varying(10) NOT NULL,
    doc_date date NOT NULL,
    application_type_id integer NOT NULL,
    business_sector_id integer NOT NULL,
    base_application_classification_id integer NOT NULL,
    application_classification_2_id integer NOT NULL,
    application_classification_3_id integer NOT NULL,
    application_classification_4_id integer NOT NULL,
    CONSTRAINT doc_application_pkey PRIMARY KEY (id),
    CONSTRAINT fk_application_classification_2 FOREIGN KEY (application_classification_2_id)
        REFERENCES ombudsman.info_application_classification (id),
    CONSTRAINT fk_application_classification_3 FOREIGN KEY (application_classification_3_id)
        REFERENCES ombudsman.info_application_classification (id),
    CONSTRAINT fk_application_classification_4 FOREIGN KEY (application_classification_4_id)
        REFERENCES ombudsman.info_application_classification (id),
    CONSTRAINT fk_application_type FOREIGN KEY (application_type_id)
        REFERENCES ombudsman.enum_application_type (id),
    CONSTRAINT fk_base_application_classification FOREIGN KEY (base_application_classification_id)
        REFERENCES ombudsman.info_application_classification (id)
)