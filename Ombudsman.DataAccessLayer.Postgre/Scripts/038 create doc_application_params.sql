CREATE TABLE ombudsman.doc_application_params
(
    id integer NOT NULL,
    parameter_id integer NOT NULL,
    parameter_value character varying NOT NULL,
    application_id integer NOT NULL,
    CONSTRAINT doc_params_pkey PRIMARY KEY (id),
    CONSTRAINT application FOREIGN KEY (application_id)
        REFERENCES ombudsman.doc_application (id),
    CONSTRAINT parameter FOREIGN KEY (parameter_id)
        REFERENCES ombudsman.info_parameters (id)
        )